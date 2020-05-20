using System.Collections.Generic;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Models;
using Cybernews.DAL.Data.Entities;

namespace Cybernews.CybernewsApi.Services
{
    public interface IArticlesPipelineService
    {
        Task<ServiceResponse<List<Article>>> GetArticles();
        Task<ServiceResponse<List<Article>>> AddArticles(List<ArticleDto> articles);
        Task<ServiceResponse<Article>> UpdateArticle(Article article);
        Task<ServiceResponse<List<ArticlesSimilarity>>> AddSimilarity(ArticlesSimilarityDto articles);
        Task<ServiceResponse<List<ArticleKeyword>>> UpdateKeywords(UpdateKeywordDto updateKeywordDto);
        Task<ServiceResponse<List<ArticleCategory>>> UpdateCategories(UpdateCategoryDto updateCategoryDto);

    }
}