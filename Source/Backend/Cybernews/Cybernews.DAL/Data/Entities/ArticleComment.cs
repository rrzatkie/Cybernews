namespace Cybernews.DAL.Data.Entities
{
    public class ArticleComment
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public string Text { get; set; }

    }
}