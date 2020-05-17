using System;
using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class ArticleCardDto
    {
        private List<CategoryDto> articleCategories;
        private List<KeywordDto> articleKeywords;

        public int ArticleId { get; set; }
        public string ArticleImgUrl { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleUrl { get; set; }
        public string ArticleAuthor { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public string ArticleDateCreated { get; set; }
        public List<CategoryDto> ArticleCategories  
        {
            get
            {
                return this.articleCategories ?? new List<CategoryDto>();
            }
            set
            {
                if(value != null)
                {
                    this.articleCategories = value;
                }
            } 
        }
        public List<KeywordDto> ArticleKeywords  
        {
            get
            {
                return this.articleKeywords ?? new List<KeywordDto>();
            }
            set
            {
                if(value != null)
                {
                    this.articleKeywords = value;
                }
            } 
        }
    }
}