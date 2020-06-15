using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos.Search
{
    public class SearchResultDto
    {
        public List<SlideDto> Articles { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<KeywordDto> Keywords { get; set; }
    }
}