namespace Cybernews.CybernewsApi.Dtos
{
    public class SimilarArticleDto
    {
        public ArticleCardDto Article { get; set; }
        public float Similarity { get; set; }
    }
}