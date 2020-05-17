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

namespace Cybernews.CybernewsApi.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IMapper mapper;
        private readonly CybernewsContext context; 

        public ArticlesService(IMapper mapper, CybernewsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ServiceResponse<List<ArtriclesArchiveDto>>> GetArticlesArchive(QueryDto query)
        {
            var serviceResponse = new ServiceResponse<List<ArtriclesArchiveDto>>()
            {
                Data = new List<ArtriclesArchiveDto>()
            };

            var articlesQuery = this.context.Articles;

            var articles = await articlesQuery.Where(x=>x.DateCreated > query.DateCreatedFrom && x.DateCreated < query.DateCreatedTo).Select(x => new {Year=x.DateCreated.ToString("yyyy"), Month=x.DateCreated.ToString("MMM")}).ToListAsync();

            serviceResponse.Data = articles.GroupBy(x=>x).Select(group=> new ArtriclesArchiveDto(){Year=group.Key.Year.ToString(), Month=group.Key.Month, Count=group.Count()}).ToList();

            return serviceResponse; 
        }

        public async Task<ServiceResponse<List<ArticleCardDto>>> GetTopArticles(QueryDto query)
        {
            var serviceResponse = new ServiceResponse<List<ArticleCardDto>>()
            {
                Data = new List<ArticleCardDto>()
            };

            var categoriesQuery = this.context.Categories;
            var categoryIds = await categoriesQuery.Select(x=>x.Id).ToListAsync();

            foreach (var categoryId in categoryIds)
            {
                var paginationOptions = new PaginationOptionsDto()
                {
                    PageNumber = 1, 
                    Limit = 10
                };
                query.ItemId = categoryId;
                var articles = await GetSlides(paginationOptions, query);

                serviceResponse.Data.AddRange(articles.Data);
            }

            serviceResponse.Data = serviceResponse.Data.OrderByDescending(x => x.LikesCount+x.CommentsCount).Take(4).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ArticleCardDto>>> GetSlides(PaginationOptionsDto paginationOptions, QueryDto query)
        {
            var serviceResponse = new ServiceResponse<List<ArticleCardDto>>();
            
            var articleCategoriesQuery = this.context.ArticleCategories;
            var articles = await articleCategoriesQuery.Where(x => x.CategoryId == query.ItemId).Select(x=>x.Article).ToListAsync();

            // var articles = new List<Article>();
            var articleQuery = this.context.Articles;

            // foreach (var articleCategory in articleCategories)
            // {
            //     articles.Add(await articleQuery.SingleOrDefaultAsync(x => x.Id == articleCategory.ArticleId));
            // }
            
            var nToSkip = (paginationOptions.PageNumber - 1) * paginationOptions.Limit;

            articles = articles
                .OrderByDescending(x=>x.DateCreated)
                .Where(x => x.DateCreated > query.DateCreatedFrom && x.DateCreated < query.DateCreatedTo)
                .Skip(nToSkip)
                .Take(paginationOptions.Limit)
                .ToList();

            serviceResponse.Data = this.mapper.Map<List<Article>, List<ArticleCardDto>>(articles);

            return serviceResponse;
        }

        public async Task<ServiceResponse<ArticleCardsListDto>> GetArticleCards(PaginationOptionsDto paginationOptions, QueryDto query)
        {
            var serviceResponse = new ServiceResponse<ArticleCardsListDto>()
            {
                Data = new ArticleCardsListDto()
            };

            var nToSkip = (paginationOptions.PageNumber - 1) * paginationOptions.Limit;
            var articleKeywordsQuery = this.context.ArticleKeywords;
            var articleCategoriesQuery = this.context.ArticleCategories;
            var articlesQuery = this.context.Articles;
            var articles = new List<Article>();
            IQueryable<Article> q;

            switch (query.Type)
            {
                case ArticleCardType.Category:
                    q = articleCategoriesQuery
                        .Where(x => x.CategoryId == query.ItemId)
                        .Select(x => x.Article)
                        .Where(x => x.DateCreated>query.DateCreatedFrom &&
                                    x.DateCreated<query.DateCreatedTo);
                    serviceResponse.Data.QueryItemNameToDisplay = await this.context.Categories.Where(x => x.Id == query.ItemId).Select(x=>x.NameToDisplay).FirstAsync();

                    break;
                case ArticleCardType.Keyword:
                    q = articleKeywordsQuery
                        .Where(x => x.KeywordId == query.ItemId)
                        .Select(x => x.Article)
                        .Where(x => x.DateCreated>query.DateCreatedFrom &&
                                    x.DateCreated<query.DateCreatedTo);
                    serviceResponse.Data.QueryItemNameToDisplay = await this.context.Keywords.Where(x => x.Id == query.ItemId).Select(x=>x.NameToDisplay).FirstAsync();
                    break;
                default:
                    q = articlesQuery
                        .Where(x => x.DateCreated>query.DateCreatedFrom &&
                                    x.DateCreated<query.DateCreatedTo);
                    break;
            }

            
            articles = await q
                        .Skip(nToSkip).Take(paginationOptions.Limit)
                        .ToListAsync();
            var articleCategories = new Dictionary<int, List<Category>>();
            var articleKeywords = new Dictionary<int, List<Tuple<Keyword,float>>>();
            foreach (var article in articles)
            {
                var categories = await articleCategoriesQuery
                    .Where(x => x.Article == article)
                    .Select(x => x.Category)
                    .ToListAsync();
                var keywordsValuePairs = await articleKeywordsQuery.Where(x => x.Article == article).Select(x => new Tuple<Keyword,float>(x.Keyword, x.Value)).ToListAsync();


                articleCategories[article.Id] = categories; 
                articleKeywords[article.Id] = keywordsValuePairs;
            }
            serviceResponse.Data.ArticleCards = this.mapper.Map<List<Article>, List<ArticleCardDto>>(articles);

            foreach (var article in serviceResponse.Data.ArticleCards)
            {
                article.ArticleCategories = this.mapper.Map<List<Category>, List<CategoryDto>>(articleCategories[article.ArticleId]);
                article.ArticleKeywords = this.mapper.Map<List<Tuple<Keyword,float>>, List<KeywordDto>>(articleKeywords[article.ArticleId]);
            }

            serviceResponse.Data.QueryItemId = query.ItemId;
            serviceResponse.Data.Count = await q.CountAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<ArticleDetailsDto>> GetArticleDetails(int articleId)
        {
            var serviceResponse = new ServiceResponse<ArticleDetailsDto>()
            {
                Data = new ArticleDetailsDto()
            };
            var articleQuery = context.Articles;
            var article = await articleQuery.SingleOrDefaultAsync(x => x.Id == articleId);

            var articleKeywords = new Dictionary<int, List<Tuple<Keyword,float>>>();
            var articleKeywordsQuery = this.context.ArticleKeywords;

            var articleCategories = new Dictionary<int, List<Category>>();
            var articleCategoriesQuery = this.context.ArticleCategories;

            var id = article.Id;
            var articleCategoriesIds = await articleCategoriesQuery.Where(x => x.ArticleId == id).Select(x => x.CategoryId).ToListAsync();
            IQueryable<Category> categoriesQuery = this.context.Categories; 
            var categories = await categoriesQuery.Where(x => articleCategoriesIds.Contains(x.Id)).ToListAsync();
            articleCategories[id] = categories;

            var keywordsIdValuePairs = await articleKeywordsQuery.Where(x => x.ArticleId == id).Select(x => new {x.KeywordId, x.Value}).ToListAsync();
            IQueryable<Keyword> keywordsQuery = this.context.Keywords;
            var keywordIds = keywordsIdValuePairs.Select(x=> x.KeywordId).ToList();
            var keywordValues = keywordsIdValuePairs.Select(x=> x.Value).ToList();

            var keywords = await keywordsQuery.Where(x => keywordIds.Contains(x.Id)).ToListAsync();
            var keywordsValuePairs = keywords.Zip(keywordValues, Tuple.Create).ToList();
            articleKeywords[id] = keywordsValuePairs;

            serviceResponse.Data.Article = this.mapper.Map<ArticleCardDto>(article);
            serviceResponse.Data.Article.ArticleKeywords = this.mapper.Map<List<Tuple<Keyword,float>>, List<KeywordDto>>(articleKeywords[id]);
            serviceResponse.Data.Article.ArticleCategories = this.mapper.Map<List<Category>, List<CategoryDto>>(articleCategories[id]);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<KeywordSummaryDto>>> GetTopKeywords(QueryDto query)
        {
            var serviceResponse = new ServiceResponse<List<KeywordSummaryDto>>()
            {
                Data = new List<KeywordSummaryDto>()
            };

            var keywords = await GetKeywords(query);
            var keywordGroupCounts = keywords.Data
                .GroupBy(x=>x.KeywordId)
                .Select(group => 
                    new {
                        Key=group.Key,
                        Count=group.Count(), 
                        Keyword=group.First()
                    }
                )
                .OrderByDescending(x=>x.Count)
                .Take(10)
                .ToList();
            
            // foreach (var k in keywordGroupCounts)
            // {
            //     serviceResponse.Data.Add(new KeywordSummaryDto()
            //     {
            //         Keyword = k.Keyword,
            //         Count = k.Count
            //     });
            // }

            serviceResponse.Data = keywordGroupCounts
                .Select(x => 
                    new KeywordSummaryDto()
                    {
                        Keyword=x.Keyword, Count=x.Count
                    }
                ).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<KeywordDto>>> GetAllKeywords()
        {
            var serviceResponse = new ServiceResponse<List<KeywordDto>>()
            {
                Data = new List<KeywordDto>()
            };

            var query = new QueryDto();
            var keywords = await GetKeywords(query);

            var keywordsDistinct = keywords.Data.GroupBy(x=>x.KeywordId).Select(group=>group.First()).ToList();
 
            serviceResponse.Data.AddRange(keywordsDistinct);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategories()
        {
            var serviceResponse = new ServiceResponse<List<CategoryDto>>()
            {
                Data = new List<CategoryDto>()
            };

            var query = new QueryDto();
            var categories = await GetCategories(query);

            serviceResponse.Data = categories.Data
                .GroupBy(x=>x.CategoryId)
                .Select(group=>group.First())
                .ToList();

            return serviceResponse;
        }

        private async Task<ServiceResponse<List<KeywordDto>>> GetKeywords(QueryDto query)
        {
            var serviceResponse = new ServiceResponse<List<KeywordDto>>();
            
            var articleKeywordsQuery = this.context.ArticleKeywords;
            var keywordsQuery = this.context.Keywords;
            
            var articlesQuery = this.context.Articles;
            var articles = await articlesQuery
                .Where(x => 
                    x.DateCreated > query.DateCreatedFrom && 
                    x.DateCreated < query.DateCreatedTo
                )
                .ToListAsync();
            
            var keywords = await articleKeywordsQuery
                .Where(x=> articles.Contains(x.Article))
                .Select(x=>x.Keyword)
                .ToListAsync();

            serviceResponse.Data = mapper.Map<List<Keyword>,List<KeywordDto>>(keywords);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CategorySummaryDto>>> GetTopCategories(QueryDto query)
        {
            
            var serviceResponse = new ServiceResponse<List<CategorySummaryDto>>()
            {
                Data = new List<CategorySummaryDto>()
            };

            var categories = await GetCategories(query);
            var keywordGroupCounts = categories.Data
                .GroupBy(x=>x.CategoryId)
                .Select(group => 
                    new {
                        Key=group.Key,
                        Count=group.Count(), 
                        Category=group.First()
                    }
                )
                .OrderByDescending(x=>x.Count)
                .Take(5)
                .ToList();

            serviceResponse.Data = keywordGroupCounts
                .Select(x => 
                    new CategorySummaryDto()
                    {
                        Category=x.Category, Count=x.Count
                    }
                ).ToList();

            return serviceResponse;
        }

        private async Task<ServiceResponse<List<CategoryDto>>> GetCategories(QueryDto query)
        {
            var serviceResponse = new ServiceResponse<List<CategoryDto>>();
            
            var articleCategoriesQuery = this.context.ArticleCategories;
            var categoriesQuery = this.context.Categories;
            
            var articlesQuery = this.context.Articles;
            var articles = await articlesQuery
                .Where(x => 
                    x.DateCreated > query.DateCreatedFrom && 
                    x.DateCreated < query.DateCreatedTo
                )
                .ToListAsync();
            
            var categories = await articleCategoriesQuery
                .Where(x=> articles.Contains(x.Article))
                .Select(x=>x.Category)
                .ToListAsync();

            serviceResponse.Data = mapper.Map<List<Category>,List<CategoryDto>>(categories);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<int>>> AddArticles(ArticleDto[] articleDtos)
        {
            var serviceResponse = new ServiceResponse<List<int>>()
            {
                Data = new List<int>()
            };
            
            var articleQuery = this.context.Articles;
            
            var r = 0;
            var alreadyExists = false;
            foreach (var articleDto in articleDtos)
            {
                var article = this.mapper.Map<Article>(articleDto);
                alreadyExists = await articleQuery.AnyAsync(x => (x.Url == article.Url) || (x.Title == article.Title)); 
                
                if(!alreadyExists) await articleQuery.AddAsync(article); else continue;
                
                var categoryQuery = this.context.Categories;
                var articleCategoriesQuery = this.context.ArticleCategories;
                if(articleDto.Categories.Count > 0){
                    var categories = this.mapper.Map<List<string>, List<Category>>(articleDto.Categories);
                    foreach (var category in categories)
                    {
                        var categoryEntity = category; 
                        alreadyExists = await categoryQuery.AnyAsync(x => x.Slug == category.Slug); 
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
                    }
                }

                var keywordQuery = this.context.Keywords;
                var articleKeywordsQuery = this.context.ArticleKeywords;
                if(articleDto.Keywords.Count > 0){
                    var keywordDtos = articleDto.Keywords;
                    foreach (var keywordDto in keywordDtos)
                    {
                        var keywordEntity = this.mapper.Map<PipelineKeywordDto, Keyword>(keywordDto);
                        alreadyExists = await keywordQuery.AnyAsync(x => (x.Slug == keywordEntity.Slug) && (x.NameToDisplay == keywordEntity.NameToDisplay)); 
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
                    }
                }

                try {
                    r = await this.context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(article);
                }
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<int>>> AddSimilarity(ArticlesSimilarityDto articlesSimilarityDto)
        {
            var serviceResponse = new ServiceResponse<List<int>>()
            {
                Data = new List<int>()
            };

            var articleQuery = this.context.Articles;

            var article_1 = await articleQuery.SingleOrDefaultAsync(x => x.Url==articlesSimilarityDto.Url_1);
            var article_2 = await articleQuery.SingleOrDefaultAsync(x => x.Url==articlesSimilarityDto.Url_2);
            
            if(article_1!=null && article_2!=null){
                var articlesSimilarityQuery = this.context.ArticlesSimilarities;
                var articlesSimilarity = new ArticlesSimilarity()
                {
                    Article_1 = article_1,
                    Article_2 = article_2,
                    Value = articlesSimilarityDto.Value
                };

                await articlesSimilarityQuery.AddAsync(articlesSimilarity);
            
                serviceResponse.Data.Add(this.context.SaveChangesAsync().Result);
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
                        this.context.ArticleCategories.RemoveRange(currentCategories);
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
}