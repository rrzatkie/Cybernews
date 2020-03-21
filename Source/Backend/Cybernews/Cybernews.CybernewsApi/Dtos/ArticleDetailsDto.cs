namespace Cybernews.CybernewsApi.Dtos
{
    public class ArticleDetailsDto
    {
        public int ArticleId { get; set; }
        public string ArticleImgUrl { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleUrl { get; set; }
        public CategoryDto[] ArticleKeywords { get; set; }
    }
}