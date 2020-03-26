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
        public DateTime ArticleDateCreated { get; set; }
        public List<CategoryDto> ArticleCategories { get; set; }
        public List<KeywordDto> ArticleKeywords { get; set; }
    }
}