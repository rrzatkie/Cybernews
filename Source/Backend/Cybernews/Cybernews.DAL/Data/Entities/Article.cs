using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cybernews.DAL.Data.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateAdded { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public DateTime? PipelineRunAt { get; set; }
        public DateTime? IndexRunAt { get; set; }
        public ICollection<ArticleKeyword> ArticleKeywords { get; set; } = new List<ArticleKeyword>();
        public ICollection<ArticleCategory> ArticleCategories { get; set; } = new List<ArticleCategory>();    
        public ICollection<ArticleLike> ArticleLikes { get; set; } = new List<ArticleLike>();
        public ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();
        [InverseProperty("Article_1")]
        public ICollection<ArticlesSimilarity> ArticleSimilaritiesAsFirst { get; set; }
        [InverseProperty("Article_2")]
        public ICollection<ArticlesSimilarity> ArticleSimilaritiesAsSecond { get; set; }
    }
}