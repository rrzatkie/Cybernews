using System.Threading.Tasks;
using Cybernews.CybernewsApi.Models;

namespace Cybernews.CybernewsApi.Services
{
    public interface IArticlesService
    {
        Task<ServiceResponse<Dtos.ArticleCardDto>> GetArticleCard(int articleId);
        Task<ServiceResponse<Dtos.ArticleDetailsDto>> GetArticleDetails(int articleId);
        Task<ServiceResponse<Dtos.SlidesListDto>> GetSlides(int categoryId);
        Task<ServiceResponse<Dtos.CategoryDto[]>> GetCategories();

    }
}