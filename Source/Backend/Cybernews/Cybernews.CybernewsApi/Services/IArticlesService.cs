using System.Collections.Generic;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Models;

namespace Cybernews.CybernewsApi.Services
{
    public interface IArticlesService
    {
        Task<ServiceResponse<Dtos.ArticleCardsListDto>> GetArticleCards(PaginationOptionsDto paginationOptions, QueryDto query);
        Task<ServiceResponse<Dtos.ArticleDetailsDto>> GetArticleDetails(int articleId);
        Task<ServiceResponse<List<Dtos.SlideDto>>> GetSlides(int categoryId);
        Task<ServiceResponse<List<Dtos.CategoryDto>>> GetCategories();
        Task<ServiceResponse<List<int>>> AddArticles(ArticleDto[] articles);
    }
}