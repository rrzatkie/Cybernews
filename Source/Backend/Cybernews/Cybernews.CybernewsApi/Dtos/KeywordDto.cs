namespace Cybernews.CybernewsApi.Dtos
{
    public class KeywordDto
    {
        public int KeywordId { get; set; }
        public string KeywordNameToDisplay { get; set; }
        public string KeywordSlug { get; set; }
        public float KeywordValue { get; set; }
    }
}