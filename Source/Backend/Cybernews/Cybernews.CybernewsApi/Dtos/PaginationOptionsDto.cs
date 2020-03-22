namespace Cybernews.CybernewsApi.Dtos
{
    public class PaginationOptionsDto
    {
        public int Limit { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}