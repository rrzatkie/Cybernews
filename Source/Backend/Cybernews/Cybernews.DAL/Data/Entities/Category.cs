using System;
using System.Collections.Generic;

namespace Cybernews.DAL.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string NameToDisplay { get; set; }
        public string Slug { get; set; }
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}