using System.Collections;
using System.Collections.Generic;

namespace Cybernews.DAL.Data.Entities
{
public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<ArticleLike> ArticleLikes { get; set; } = new List<ArticleLike>();

        public ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();
}
}