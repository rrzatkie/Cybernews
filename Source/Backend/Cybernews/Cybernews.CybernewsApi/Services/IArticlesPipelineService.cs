using System.Collections.Generic;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Models;
using Cybernews.DAL.Data.Entities;

namespace Cybernews.CybernewsApi.Services
{
    public interface IArticlesPipelineService
    {
        Task<ServiceResponse<List<Article>>> GetArticles(PaginationOptionsDto paginationOptions);
        Task<ServiceResponse<int>> InsertOrUpdateArticles(List<ArticleDto> articles);
        ServiceResponse<List<ArticlesSimilarity>> AddSimilarity(List<ArticlesSimilarityDto> articlesSimilarities);
        Task<ServiceResponse<List<ArticleKeyword>>> UpdateKeywords(UpdateKeywordDto updateKeywordDto);
        Task<ServiceResponse<List<ArticleCategory>>> UpdateCategories(UpdateCategoryDto updateCategoryDto);
        Task<ServiceResponse<List<string>>> GetPendingArticles(string url, PaginationOptionsDto paginationOptions);

    }
}