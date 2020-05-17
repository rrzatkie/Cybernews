using System.Collections.Generic;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Models;
using Cybernews.DAL.Data.Entities;

namespace Cybernews.CybernewsApi.Services
{
    public interface IArticlesService
    {
        Task<ServiceResponse<Dtos.ArticleCardsListDto>> GetArticleCards(PaginationOptionsDto paginationOptions, QueryDto query);
        Task<ServiceResponse<List<Dtos.ArticleCardDto>>> GetTopArticles(QueryDto query);
        Task<ServiceResponse<List<Dtos.ArtriclesArchiveDto>>> GetArticlesArchive(QueryDto query);
        Task<ServiceResponse<Dtos.ArticleDetailsDto>> GetArticleDetails(int articleId);
        Task<ServiceResponse<List<Dtos.ArticleCardDto>>> GetSlides(PaginationOptionsDto paginationOptions, QueryDto query);
        Task<ServiceResponse<List<Dtos.KeywordSummaryDto>>> GetTopKeywords(QueryDto query);
        Task<ServiceResponse<List<Dtos.CategorySummaryDto>>> GetTopCategories(QueryDto query);
        Task<ServiceResponse<List<Dtos.KeywordDto>>> GetAllKeywords();
        Task<ServiceResponse<List<Dtos.CategoryDto>>> GetAllCategories();
        Task<ServiceResponse<List<int>>> AddArticles(ArticleDto[] articles);
        Task<ServiceResponse<List<int>>> AddSimilarity(ArticlesSimilarityDto articles);
        Task<ServiceResponse<List<ArticleKeyword>>> UpdateKeywords(UpdateKeywordDto updateKeywordDto);
        Task<ServiceResponse<List<ArticleCategory>>> UpdateCategories(UpdateCategoryDto updateCategoryDto);

    }
}