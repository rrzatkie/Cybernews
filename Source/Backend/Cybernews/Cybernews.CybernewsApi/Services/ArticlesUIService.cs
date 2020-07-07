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
    public class ArticlesUIService : IArticlesUIService
    {
        private readonly IMapper mapper;
        private readonly CybernewsContext context; 

        public ArticlesUIService(IMapper mapper, CybernewsContext context)
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

            serviceResponse.Data = serviceResponse.Data.OrderByDescending(x => x.LikesCount+x.CommentsCount).Take(5).ToList();

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
                .OrderByDescending(x => x.DateCreated)
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

            var articlesSimilaritiesQuery = this.context.ArticlesSimilarities;
            var similarArticles = await articlesSimilaritiesQuery
                .Where(x => x.ArticleId_1 == id)
                .Select(x => new SimilarArticleDto{ Article = this.mapper.Map<ArticleCardDto>(x.Article_2), Similarity = x.Value })
                .ToListAsync();

            serviceResponse.Data.Article = this.mapper.Map<ArticleCardDto>(article);
            serviceResponse.Data.Article.ArticleKeywords = this.mapper.Map<List<Tuple<Keyword,float>>, List<KeywordDto>>(articleKeywords[id]);
            serviceResponse.Data.Article.ArticleCategories = this.mapper.Map<List<Category>, List<CategoryDto>>(articleCategories[id]);
            serviceResponse.Data.SimilarArticles = similarArticles;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<KeywordSummaryDto>>> GetTopKeywords(QueryDto query)
        {
            var serviceResponse = new ServiceResponse<List<KeywordSummaryDto>>()
            {
                Data = new List<KeywordSummaryDto>()
            };

            query.DateCreatedFrom = DateTime.UtcNow.AddDays(-7);
            query.DateCreatedTo = DateTime.UtcNow;

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
                .Take(10)
                .OrderByDescending(x=>x.Count)
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
                .Include(x => x.ArticleKeywords)
                .ThenInclude(x => x.Keyword)
                .ToListAsync();
            
            var articleKeywords = articles.SelectMany(x => x.ArticleKeywords).OrderByDescending(x=>x.Value);

            var keywords = articleKeywords.Select(x => x.Keyword).ToList();

            serviceResponse.Data = mapper.Map<List<Keyword>,List<KeywordDto>>(keywords);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CategorySummaryDto>>> GetTopCategories(QueryDto query)
        {
            
            var serviceResponse = new ServiceResponse<List<CategorySummaryDto>>()
            {
                Data = new List<CategorySummaryDto>()
            };

            query.DateCreatedFrom = DateTime.UtcNow.AddDays(-7);
            query.DateCreatedTo = DateTime.UtcNow;

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
                .Include(x => x.ArticleCategories)
                .ThenInclude(x => x.Category)
                .ToListAsync();
            
            var articleCategories = articles
                .SelectMany(x => x.ArticleCategories);

            var categories = articleCategories.Select(x => x.Category).ToList();

            serviceResponse.Data = mapper.Map<List<Category>,List<CategoryDto>>(categories);

            return serviceResponse;
        }

    }
}