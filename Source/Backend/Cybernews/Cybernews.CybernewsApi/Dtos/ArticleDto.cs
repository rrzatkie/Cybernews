using System;
using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class ArticleDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public System.Int32 DateCreatedUnix { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public List<PipelineKeywordDto> Keywords { get; set; }
        public List<string> Categories { get; set; }
    }
}