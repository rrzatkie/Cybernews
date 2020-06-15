using System.Collections.Generic;

namespace Cybernews.CybernewsApi.Dtos.Search
{
    public class SuggestResultDto
    {
        public IEnumerable<SuggestDto> Suggestions { get; set; }
    }

    public class SuggestDto
    {
        public string Name { get; set; }
        public double Score { get; set; }  
    }
}