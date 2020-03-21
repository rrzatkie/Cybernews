using System;
using System.Collections.Generic;

namespace Cybernews.DAL.Data.Entities
{
    public class Keyword
    {
        public int Id { get; set; }
        public string NameToDisplay { get; set; }
        public string Slug { get; set; }
        public ICollection<ArticleKeyword> ArticleKeywords { get; set; }
    }
}