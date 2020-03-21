using System;
using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class ArticleCardDto
    {
        public int ArticleId { get; set; }
        public string ArticleImgUrl { get; set; }
        public string ArticleTitle { get; set; }

        public string ArticleUrl { get; set; }
        public DateTime ArticleDate { get; set; }
        public ICollection<CategoryDto> ArticleCategory { get; set; }
    }
}