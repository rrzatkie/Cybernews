using System.Globalization;
using System.IO.Compression;
using System.Data;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Models;
using Cybernews.CybernewsApi.Models.Enums;
using Cybernews.DAL.Data;
using Cybernews.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cybernews.CybernewsApi.Services
{
    public class ArticlesPipelineService : IArticlesPipelineService
    {
        private readonly IMapper mapper;
        private readonly CybernewsContext context;
        private readonly ILogger<ArticlesPipelineService> logger; 
        public ArticlesPipelineService(IMapper mapper, CybernewsContext context, ILogger<ArticlesPipelineService> logger)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResponse<List<Article>>> GetArticles(PaginationOptionsDto paginationOptions)
        {
            var serviceResponse = new ServiceResponse<List<Article>>()
            {
                Data=new List<Article>()
            };

            var articlesQuery = this.context.Articles;

            var nToSkip = (paginationOptions.PageNumber - 1) * paginationOptions.Limit;
            var articles = await articlesQuery
                .Where(x => !x.PipelineRunAt.HasValue)
                // .Skip(nToSkip)
                // .Take(3)
                .ToListAsync();

            serviceResponse.Data = articles;

            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> InsertOrUpdateArticles(List<ArticleDto> articleDtos)
        {
            var serviceResponse = new ServiceResponse<int>();
            
            var articleQuery = this.context.Articles;
            var categoryQuery = this.context.Categories;
            var articleCategoriesQuery = this.context.ArticleCategories;
            var keywordQuery = this.context.Keywords;
            var articleKeywordsQuery = this.context.ArticleKeywords;

            var articlesList = this.mapper.Map<List<ArticleDto>, List<Article>>(articleDtos);
            
            var categoriesList = this.mapper.Map<List<List<string>>, List<List<Category>>>(articleDtos.Select(x=>x.Categories).ToList());
            
            var keywordsList = this.mapper.Map<List<List<PipelineKeywordDto>>, List<List<ArticleKeyword>>>(articleDtos.Select(x=>x.Keywords.Distinct(new DistinctItemComparer()).ToList()).ToList());

            var articlesCatKeyDict = articlesList
                .Zip(categoriesList.Zip(keywordsList, Tuple.Create), (k, v) => new { k, v })
                .ToDictionary(x => x.k, x => x.v);

            foreach (var pair in articlesCatKeyDict)
            {
                Article article = await articleQuery
                    .Include(x=>x.ArticleCategories)
                    .Include(x=>x.ArticleKeywords)
                    .SingleOrDefaultAsync(x => x.Url == pair.Key.Url);

                if(article == null){
                    await articleQuery.AddAsync(pair.Key);
                    article = pair.Key;
                }
                else {
                    articleCategoriesQuery.RemoveRange(article.ArticleCategories);
                    articleKeywordsQuery.RemoveRange(article.ArticleKeywords);
                }

                if(pair.Key.PipelineRunAt != null) {
                    article.PipelineRunAt = pair.Key.PipelineRunAt;
                }

                foreach (var cat in pair.Value.Item1)
                {
                    var category = await categoryQuery.SingleOrDefaultAsync(x => x.Slug == cat.Slug);
                    if(category==null)
                    {
                        category = cat;
                    }

                    await articleCategoriesQuery.AddAsync(new ArticleCategory(){Article=article, Category=category});
                    this.logger.LogInformation($"Added new ArticleCategory: {article.Title} - {category.Slug}");
                }

                foreach (var kwd in pair.Value.Item2)
                {
                    var keyword = await keywordQuery.SingleOrDefaultAsync(x => x.Slug == kwd.Keyword.Slug && x.NameToDisplay==kwd.Keyword.NameToDisplay);
                    if(keyword==null)
                    {
                        keyword = kwd.Keyword;
                    }
                    await articleKeywordsQuery.AddAsync(new ArticleKeyword(){Article=article, Keyword=keyword, Value=kwd.Value});
                    this.logger.LogInformation($"Added new ArticleKeyword: {article.Title} - {keyword.Slug}");
                }

                this.logger.LogInformation("Saving changes.");
                var res = await this.context.SaveChangesAsync();
            }

            return serviceResponse;
        }

        public ServiceResponse<List<ArticlesSimilarity>> AddSimilarity(List<ArticlesSimilarityDto> articlesSimilarities)
        {
            var serviceResponse = new ServiceResponse<List<ArticlesSimilarity>>()
            {
                Data = new List<ArticlesSimilarity>()
            };

            var articleQuery = this.context.Articles;
            var articlesSimilarityQuery = this.context.ArticlesSimilarities;

            var result = new List<ArticlesSimilarity>();
            foreach (var articlesSimilarityDto in articlesSimilarities)
            {
                var article_1 =  articleQuery.FirstOrDefault(x => x.Url==articlesSimilarityDto.Url_1);
                var article_2 =  articleQuery.FirstOrDefault(x => x.Url==articlesSimilarityDto.Url_2);
                
                var articlesSimilarity = articlesSimilarityQuery
                    .FirstOrDefault(x => 
                        x.ArticleId_1==article_1.Id && x.ArticleId_2==article_2.Id
                    );      

                
                // bool alreadyAdded = this.context.ChangeTracker.Entries()
                //     .FirstOrDefault(x => x.State == EntityState.Added && x.Entity is ArticlesSimilarity && 
                //         (
                //             (x.Entity as ArticlesSimilarity).ArticleId_1 == article_1.Id && 
                //             (x.Entity as ArticlesSimilarity).ArticleId_2 == article_2.Id)
                //         ) != null;

                if
                (
                    articlesSimilarity == null //&& !alreadyAdded
                ){
                    this.logger.LogInformation($"Creating ArticleSimilarity for {article_1.Url} and {article_2.Url}");
                    articlesSimilarity = new ArticlesSimilarity()
                    {
                        Article_1 = article_1,
                        Article_2 = article_2,
                        Value = articlesSimilarityDto.Value
                    };
                    articlesSimilarityQuery.Add(articlesSimilarity);
                }
                else
                {
                    this.logger.LogInformation($"Already exists. ArticleId1: {article_1.Id}, ArticleId_2: {article_2.Id}. Updating value: {articlesSimilarityDto.Value}");
                    articlesSimilarity.Value = articlesSimilarityDto.Value;
                }

                result.Add(articlesSimilarity);
            }

            this.logger.LogInformation("Saving changes.");
            int r = 0;
            try
            {         
                r = this.context.SaveChanges();

                this.logger.LogInformation("Success!");
            }
            catch (DbUpdateException)
            {
                var message = "Failure while saving changes to db.";

                this.logger.LogError(message);
            }
            
            return serviceResponse;
        }  

        public async Task<ServiceResponse<List<ArticleCategory>>> UpdateCategories(UpdateCategoryDto updateCategoryDto)
        {
            var serviceResponse = new ServiceResponse<List<ArticleCategory>>()
            {
                Data = new List<ArticleCategory>()
            };

            var articleQuery = this.context.Articles;

            var article = await articleQuery.FirstOrDefaultAsync(x => x.Url==updateCategoryDto.ArticleUrl);

            if(article!=null)
            {
                var currentCategories = await this.context.ArticleCategories.Where(x => x.ArticleId==article.Id).ToListAsync();
                this.context.ArticleCategories.RemoveRange(currentCategories);
                
                var categoryQuery = this.context.Categories;
                var articleCategoriesQuery = this.context.ArticleCategories;

                var categoryDtos = updateCategoryDto.CategoryNames; 
                if(categoryDtos.Count > 0)
                {
                    var categories = this.mapper.Map<List<string>, List<Category>>(categoryDtos);

                    foreach (var category in categories)
                    {
                        var categoryEntity = category;

                        var alreadyExists = await categoryQuery.AnyAsync(x => x.Slug == category.Slug); 
                        if(!alreadyExists)
                        {
                            await categoryQuery.AddAsync(category);
                        }
                        else
                        {
                            categoryEntity = await categoryQuery.FirstOrDefaultAsync(x => x.Slug == category.Slug); 
                        }

                        var articleCategory = new ArticleCategory()
                        {
                            Article = article,
                            Category = categoryEntity 
                        };
                        
                        await articleCategoriesQuery.AddAsync(articleCategory);
                        serviceResponse.Data.Add(articleCategory);
                    }

                    var result = await this.context.SaveChangesAsync();

                    if(result > 0)
                    {
                        await this.context.SaveChangesAsync();
                    }
                }
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ArticleKeyword>>> UpdateKeywords(UpdateKeywordDto updateKeywordDto)
        {
            var serviceResponse = new ServiceResponse<List<ArticleKeyword>>()
            {
                Data = new List<ArticleKeyword>()
            };

            var articleQuery = this.context.Articles;

            var article = await articleQuery.FirstOrDefaultAsync(x => x.Url==updateKeywordDto.ArticleUrl);

            if(article!=null)
            {             
                var currentKeywords = await this.context.ArticleKeywords.Where(x => x.ArticleId==article.Id).ToListAsync();
                var keywordQuery = this.context.Keywords;
                var articleKeywordsQuery = this.context.ArticleKeywords;
                if(updateKeywordDto.Keywords.Count > 0){
                    var keywordDtos = updateKeywordDto.Keywords;
                    foreach (var keywordDto in keywordDtos)
                    {
                        var keywordEntity = this.mapper.Map<PipelineKeywordDto, Keyword>(keywordDto);
                        var alreadyExists = await keywordQuery.AnyAsync(x => (x.Slug == keywordEntity.Slug) && (x.NameToDisplay == keywordEntity.NameToDisplay)); 
                        if(!alreadyExists)
                        {
                            await keywordQuery.AddAsync(keywordEntity);
                        }
                        else
                        {
                            keywordEntity = await keywordQuery.FirstOrDefaultAsync(x => x.Slug == keywordEntity.Slug);
                        }

                        var articleKeyword = new ArticleKeyword()
                        {
                            Article = article,
                            Keyword = keywordEntity,
                            Value = keywordDto.Value
                        };

                        if(!article.ArticleKeywords.Any(x => x.Keyword == articleKeyword.Keyword)) await articleKeywordsQuery.AddAsync(articleKeyword); else continue;
                        serviceResponse.Data.Add(articleKeyword);
                    }

                    var result = await this.context.SaveChangesAsync();

                    if(result > 0)
                    {
                        this.context.ArticleKeywords.RemoveRange(currentKeywords);
                        await this.context.SaveChangesAsync();
                    }
                }
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<string>>> GetPendingArticles(string url, PaginationOptionsDto paginationOptions)
        {
            var serviceResponse = new ServiceResponse<List<string>>()
            {
                Data = new List<string>()
            };

            var articleQuery = this.context.Articles;
            var article = articleQuery.SingleOrDefaultAsync(x => x.Url == url);

            var articlesSimilarityQuery = this.context.ArticlesSimilarities;
            if(article != null)
            {
                var urls = await articlesSimilarityQuery
                    .Where(x => x.Article_1.Url == url)
                    .Select(x=>x.Article_2.Url)
                    .ToListAsync();

                urls.AddRange(
                    await articlesSimilarityQuery
                        .Where(x => x.Article_2.Url == url)
                        .Select(x=> x.Article_1.Url)
                        .ToListAsync()
                );
                
                var nToSkip = (paginationOptions.PageNumber - 1) * paginationOptions.Limit;
                serviceResponse.Data = await articleQuery
                    .Where(x => !urls.Contains(x.Url))
                    .Select(x => x.Url)
                    .Skip(nToSkip)
                    .Take(paginationOptions.Limit)
                    .ToListAsync();  
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to find Article with given url"; 
            }

            return serviceResponse;
        }
    }

    class DistinctItemComparer : IEqualityComparer<PipelineKeywordDto> {

    public bool Equals(PipelineKeywordDto x, PipelineKeywordDto y) {
        return x.Name == y.Name;
    }

    public int GetHashCode(PipelineKeywordDto obj) {
        return obj.Name.GetHashCode();
    }
}

}