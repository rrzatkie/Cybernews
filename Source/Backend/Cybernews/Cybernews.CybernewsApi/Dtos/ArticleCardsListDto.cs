using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class ArticleCardsListDto
    {
        private List<ArticleCardDto> articleCards;
        public List<ArticleCardDto> ArticleCards 
        { 
            get
            {
                return this.articleCards ?? new List<ArticleCardDto>();
            }
            set
            {
                this.articleCards = value;
            } 
        }
        public int Count { get; set; }
        public int QueryItemId { get; set; }
    }
}