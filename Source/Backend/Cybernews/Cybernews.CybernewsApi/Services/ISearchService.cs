using System.Collections.Generic;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos.Search;
using Cybernews.CybernewsApi.Models;
using Cybernews.CybernewsApi.Models.Enums;

namespace Cybernews.CybernewsApi.Services
{
    public interface ISearchService
    {
        Task<ServiceResponse<SearchResultDto>> Search(string keyword, SearchType type);
        Task<ServiceResponse<int>> IndexArticles(List<SearchArticleDto> articles);
        Task<ServiceResponse<int>> IndexKeywords(List<SearchKeywordDto> keywords);
        Task<ServiceResponse<int>> IndexCategories(List<SearchCategoryDto> categories);
    }
}