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

        public async Task<ServiceResponse<List<Article>>> GetArticles()
        {
            var serviceResponse = new ServiceResponse<List<Article>>()
            {
                Data=new List<Article>()
            };

            var articlesQuery = this.context.Articles;

            var articles = await articlesQuery.Where(x => !x.PipelineRunAt.HasValue).Take(1).ToListAsync();

            serviceResponse.Data = articles;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Article>> UpdateArticle(Article article)
        {
            var serviceResponse = new ServiceResponse<Article>(); 
            
            var articleQuery = this.context.Articles;

            articleQuery.Update(article);

            var res = await this.context.SaveChangesAsync();

            if(res > 0) 
            {
                serviceResponse.Data = await articleQuery.SingleOrDefaultAsync(x => x.Id == article.Id);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to update article.";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Article>>> AddArticles(List<ArticleDto> articleDtos)
        {
            var serviceResponse = new ServiceResponse<List<Article>>()
            {
                Data = new List<Article>()
            }; 
            
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
            
            var i = 0;
            await articleQuery.AddRangeAsync(articlesCatKeyDict.Keys);
            foreach (var key in articlesCatKeyDict.Keys)
            {
                foreach (var cat in articlesCatKeyDict[key].Item1)
                {
                    var category = await categoryQuery.SingleOrDefaultAsync(x => x.Slug == cat.Slug);
                    if(category==null)
                    {
                        category = cat;
                    }

                    await articleCategoriesQuery.AddAsync(new ArticleCategory(){Article=key, Category=category});
                    this.logger.LogInformation($"Added new ArticleCategory: {key.Title} - {category.Slug}");
                }

                foreach (var kwd in articlesCatKeyDict[key].Item2)
                {
                    var keyword = await keywordQuery.SingleOrDefaultAsync(x => x.Slug == kwd.Keyword.Slug);
                    if(keyword==null)
                    {
                        keyword = kwd.Keyword;
                    }
                    await articleKeywordsQuery.AddAsync(new ArticleKeyword(){Article=key, Keyword=keyword, Value=kwd.Value});
                    this.logger.LogInformation($"Added new ArticleKeyword: {key.Title} - {keyword.Slug}");
                }


                this.logger.LogInformation("Saving changes.");
                var res = await this.context.SaveChangesAsync();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ArticlesSimilarity>>> AddSimilarity(ArticlesSimilarityDto articlesSimilarityDto)
        {
            var serviceResponse = new ServiceResponse<List<ArticlesSimilarity>>()
            {
                Data = new List<ArticlesSimilarity>()
            };

            var articleQuery = this.context.Articles;

            var article_1 = await articleQuery.SingleOrDefaultAsync(x => x.Url==articlesSimilarityDto.Url_1);
            var article_2 = await articleQuery.SingleOrDefaultAsync(x => x.Url==articlesSimilarityDto.Url_2);
            
            if
            (
                article_1!=null && 
                article_2!=null
            ){
                var articlesSimilarityQuery = this.context.ArticlesSimilarities;
                var articlesSimilarity = new ArticlesSimilarity()
                {
                    Article_1 = article_1,
                    Article_2 = article_2,
                    Value = articlesSimilarityDto.Value
                };

                await articlesSimilarityQuery.AddAsync(articlesSimilarity);
            
                // serviceResponse.Data.Add(this.context.SaveChangesAsync().Result);
            }
            else
            {
                serviceResponse.Message = "One of given URLs does not reference article in Cybernews DB.";
                serviceResponse.Success = false;
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