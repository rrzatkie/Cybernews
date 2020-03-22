using Cybernews.CybernewsApi.Models.Enums;

namespace Cybernews.CybernewsApi.Dtos
{
    public class QueryDto
    {
        public ArticleCardType Type { get; set; }
        public int ItemId { get; set; }
    }
}