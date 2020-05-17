using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class UpdateKeywordDto
    {
        public string ArticleUrl { get; set; }
        public List<PipelineKeywordDto> Keywords{ get; set; }
    }
}