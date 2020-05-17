using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos
{
    public class UpdateCategoryDto
    {
        public string ArticleUrl { get; set; }
        public List<string> CategoryNames{ get; set; }
    }
}