using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cybernews.DAL.Data.Entities
{
    public class ArticlesSimilarity
    {
        public int Id { get; set; }
        public float Value { get; set; }
                    
        [ForeignKey("Article_1")]
        public int ArticleId_1 { get; set; }
        public virtual Article Article_1 { get; set; }
                    
        [ForeignKey("Article_2")]
        public int ArticleId_2 { get; set; }
        public virtual Article Article_2 { get; set; }
    }
}