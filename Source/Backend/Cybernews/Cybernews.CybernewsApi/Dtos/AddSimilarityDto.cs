using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class AddSimilarityDto
    {
        public int ArticleId_1 { get; set; }
        public int ArticleId_2 { get; set; }
        public float Value { get; set; }
    }
}