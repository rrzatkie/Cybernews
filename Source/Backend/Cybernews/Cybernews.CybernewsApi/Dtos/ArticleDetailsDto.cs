using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class ArticleDetailsDto
    {
        private List<SimilarArticleDto> similarArticles;
        public ArticleCardDto Article { get; set; }
        public List<SimilarArticleDto> SimilarArticles 
        {
            get
            {
                return this.similarArticles ?? new List<SimilarArticleDto>();
            }
            set
            {
                if(value != null)
                {
                    this.similarArticles = value;
                }
            } 
        }

    }
}