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

        public async Task<ServiceResponse<List<ArticleCardDto>>> GetArticleCards(PaginationOptionsDto paginationOptions, QueryDto query)
        {
            switch (query.Type)
            {
                case ArticleCardType.Category:
                    return await GetArticleCardsByCategory(paginationOptions, query.ItemId);
                case ArticleCardType.Keyword:
                    return await GetArticleCardsByKeyword(paginationOptions, query.ItemId);
                default:
                    var serviceResponse = new ServiceResponse<List<ArticleCardDto>>();
                    serviceResponse.Message = "Unknown card type!";
                    return serviceResponse;
            }
        }

        private async Task<ServiceResponse<List<ArticleCardDto>>> GetArticleCardsByCategory(PaginationOptionsDto paginationOptions, int categoryId)
        {
            var serviceResponse = new ServiceResponse<List<ArticleCardDto>>();

            var articleCategoriesQuery = this.context.ArticleCategories;
            var articleIds = await articleCategoriesQuery.Where(x => x.CategoryId == categoryId).Select(x => x.ArticleId).ToListAsync();

            var articleCategories = new Dictionary<int, List<Category>>();
            foreach (var id in articleIds)
            {
                var articleCategoriesIds = await articleCategoriesQuery.Where(x => x.ArticleId == id).Select(x => x.CategoryId).ToListAsync();
                IQueryable<Category> categoriesQuery = this.context.Categories; 
                var categories = await categoriesQuery.Where(x => articleCategoriesIds.Contains(x.Id)).ToListAsync();
                articleCategories[id] = categories;
            }

            IQueryable<Article> articleQuery = this.context.Articles;
            articleQuery = articleQuery.Where(x => articleIds.Contains(x.Id)).OrderByDescending(x => x. DateCreated);                    

            var nToSkip = (paginationOptions.PageNumber - 1) * paginationOptions.Limit;
            var articles = await articleQuery.Skip(nToSkip).Take(paginationOptions.Limit).ToListAsync();
            
            serviceResponse.Data = this.mapper.Map<List<Article>, List<ArticleCardDto>>(articles);

            foreach (var article in serviceResponse.Data)
            {
                article.ArticleCategories = this.mapper.Map<List<Category>, List<CategoryDto>>(articleCategories[article.ArticleId]);
            }

            return serviceResponse;
        }

        private async Task<ServiceResponse<List<ArticleCardDto>>> GetArticleCardsByKeyword(PaginationOptionsDto paginationOptions, int keywordId)
        {
            var serviceResponse = new ServiceResponse<List<ArticleCardDto>>();

            var articleKeywordsQuery = this.context.ArticleKeywords;
            var articleIds = await articleKeywordsQuery.Where(x => x.KeywordId == keywordId).Select(x => x.ArticleId).ToListAsync();

            var articleKeywords = new Dictionary<int, List<Keyword>>();
            foreach (var id in articleIds)
            {
                var articleKeywordsIds = await articleKeywordsQuery.Where(x => x.ArticleId == id).Select(x => x.KeywordId).ToListAsync();
                IQueryable<Keyword> keywordsQuery = this.context.Keywords; 
                var keywords = await keywordsQuery.Where(x => articleKeywordsIds.Contains(x.Id)).ToListAsync();
                articleKeywords[id] = keywords;
            }

            IQueryable<Article> articleQuery = this.context.Articles;
            articleQuery = articleQuery.Where(x => articleIds.Contains(x.Id)).OrderByDescending(x => x. DateCreated);                    

            var nToSkip = (paginationOptions.PageNumber - 1) * paginationOptions.Limit;
            var articles = await articleQuery.Skip(nToSkip).Take(paginationOptions.Limit).ToListAsync();
            
            serviceResponse.Data = this.mapper.Map<List<Article>, List<ArticleCardDto>>(articles);

            foreach (var article in serviceResponse.Data)
            {
                article.ArticleKeywords = this.mapper.Map<List<Keyword>, List<KeywordDto>>(articleKeywords[article.ArticleId]);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ArticleDetailsDto>> GetArticleDetails(int articleId)
        {
            var serviceResponse = new ServiceResponse<ArticleDetailsDto>();
            var articleQuery = context.Articles;
            var article = await articleQuery.SingleOrDefaultAsync(x => x.Id == articleId);

            IQueryable<ArticleKeyword> articleKeywordsQuery = context.ArticleKeywords;
            var keywordIds = await articleKeywordsQuery.Where(x => x.ArticleId == articleId).Select(x => x.KeywordId).ToListAsync();

            var keywordsQuery = context.Keywords;            
            var keywords = await keywordsQuery.Where(x => keywordIds.Contains(x.Id)).ToListAsync();

            serviceResponse.Data = this.mapper.Map<ArticleDetailsDto>(article);
            serviceResponse.Data.ArticleKeywords = this.mapper.Map<List<Keyword>,List<KeywordDto>>(keywords);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CategoryDto>>> GetCategories()
        {
            var serviceResponse = new ServiceResponse<List<CategoryDto>>();
            
            var categoriesQuery = this.context.Categories;
            var categories = await categoriesQuery.ToListAsync();

            serviceResponse.Data = mapper.Map<List<Category>,List<CategoryDto>>(categories);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SlideDto>>> GetSlides(int categoryId)
        {
            var serviceResponse = new ServiceResponse<List<SlideDto>>();
            
            var articleCategoriesQuery = this.context.ArticleCategories;
            var articleCategories = await articleCategoriesQuery.Where(x => x.CategoryId == categoryId).ToListAsync();

            var articles = new List<Article>();
            var articleQuery = this.context.Articles;

            foreach (var articleCategory in articleCategories)
            {
                articles.Add(await articleQuery.SingleOrDefaultAsync(x => x.Id == articleCategory.ArticleId));
            }

            articles = articles.OrderByDescending(x => x. DateCreated).Take(5).ToList();
            serviceResponse.Data = this.mapper.Map<List<Article>, List<SlideDto>>(articles);

            return serviceResponse;
        }
    }
}