using System.Text.RegularExpressions;
using System;
using Microsoft.EntityFrameworkCore;
using Cybernews.DAL.Data.Entities;
using System.Text;
using System.Globalization;

namespace Cybernews.DAL.Data
{
    public static class Helper
    {
        public static string Slugify(string txt)
        {
            var slug = txt.RemoveDiacritics().ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = slug.Substring(0, slug.Length <=45 ? slug.Length : 45).Trim();
            slug = Regex.Replace(slug, @"\s", "-");

            return slug;
        }

        public static string RemoveDiacritics(this string text) 
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

    }

    public class CybernewsContext : DbContext
    {
        public CybernewsContext(DbContextOptions options)
            : base(options)
        {
        }
        

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<ArticleKeyword> ArticleKeywords { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleCategory>()
                .HasKey(ac => new { ac.ArticleId, ac.CategoryId });  
            modelBuilder.Entity<ArticleCategory>()
                .HasOne(ac => ac.Article)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.ArticleId);  
            modelBuilder.Entity<ArticleCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(c => c.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId);

            modelBuilder.Entity<ArticleKeyword>()
                .HasKey(ak => new { ak.ArticleId, ak.KeywordId });  
            modelBuilder.Entity<ArticleKeyword>()
                .HasOne(ak => ak.Article)
                .WithMany(a => a.ArticleKeywords)
                .HasForeignKey(ak => ak.ArticleId);  
            modelBuilder.Entity<ArticleKeyword>()
                .HasOne(ak => ak.Keyword)
                .WithMany(k => k.ArticleKeywords)
                .HasForeignKey(ak => ak.KeywordId);

            // var random = new Random(Seed: 123);
            // var now = DateTime.UtcNow;
            // var nowUnix = (Int32) now.Subtract(new DateTime(1970,1,1)).TotalSeconds;

            // var articles = new System.Collections.Generic.List<Article>();
            // var categories = new System.Collections.Generic.List<Category>();
            // var keywords = new System.Collections.Generic.List<Keyword>();

            // var articleKeywords = new System.Collections.Generic.List<ArticleKeyword>();
            // var articleCategories = new System.Collections.Generic.List<ArticleCategory>();

            // for (int articleId = 1; articleId < 151; articleId++)
            // { 
            //     var timeCreated = random.Next(1561635315, nowUnix);
            //     var title = $"Random title Lorem ipsum aaAA BBbb asdasdas({articleId})!!! ??? %$^&";
                
            //     var slug = Helper.Slugify(title);

            //     articles.Add(
            //         new Article
            //         {
            //             Id = articleId,
            //             Author= "Jan Kowalski",
            //             Title = title,
            //             DateAdded = now,
            //             DateCreated = new DateTime(1970, 1,1,0,0,0,0, System.DateTimeKind.Utc).AddSeconds(timeCreated),
            //             ImageUrl = $"https:i.picsum.photos/id/{articleId}/900/500.jpg",
            //             NoOfLikes = random.Next(0, 1000),
            //             Slug = slug,
            //             Url = $"https://randomwebsite.com/{slug}"
            //         }
            //     );
            // }

            // for (int categoryId = 1; categoryId < 11; categoryId++)
            // {
            //     var categoryName = $"Random category name #{categoryId} !?$#";
            //     var slug = Helper.Slugify(categoryName);

            //     categories.Add(
            //         new Category
            //         {
            //             Id = categoryId,
            //             NameToDisplay = categoryName,
            //             Slug = slug
            //         }
            //     );
            // }

            // for (int keywordId = 1; keywordId < 101; keywordId++)
            // {
            //     var keywordName = $"Random Keyword #{keywordId} !?$#";
            //     var slug = Helper.Slugify(keywordName);

            //     keywords.Add(
            //         new Keyword
            //         {
            //             Id = keywordId,
            //             NameToDisplay = keywordName,
            //             Slug = slug
            //         }
            //     );
            // }

            // foreach (var article in articles)
            // {
            //     var nOfCategories = random.Next(1, 4);
            //     var alreadyChosen = new System.Collections.Generic.List<int>();
                
            //     for (int i = 0; i < nOfCategories; i++)
            //     {
            //         var index = random.Next(0, categories.Count-1);
                    
            //         while(alreadyChosen.Contains(index))
            //         {
            //             index = random.Next(0, categories.Count-1);
            //         }

            //         int categoryId = categories[index].Id;
            //         articleCategories.Add(
            //             new ArticleCategory
            //             {
            //                 ArticleId = article.Id,
            //                 CategoryId = categoryId
            //             }
            //         );

            //         alreadyChosen.Add(index);
            //     }
            // }
            
            // foreach (var article in articles)
            // {
            //     var nOfKeywords = random.Next(1, 10);
            //     var alreadyChosen = new System.Collections.Generic.List<int>();

            //     for (int i = 0; i < nOfKeywords; i++)
            //     {
            //         var index = random.Next(0, keywords.Count-1);
                    
            //         while(alreadyChosen.Contains(index))
            //         {
            //             index = random.Next(0, keywords.Count-1);
            //         }

            //         int keywordId = keywords[index].Id;
                    
            //         articleKeywords.Add(
            //             new ArticleKeyword
            //             {
            //                 ArticleId = article.Id,
            //                 KeywordId = keywordId
            //             }
            //         );

            //         alreadyChosen.Add(index);
            //     }
            // }

            // modelBuilder.Entity<Article>().HasData(articles);
            // modelBuilder.Entity<Category>().HasData(categories);
            // modelBuilder.Entity<Keyword>().HasData(keywords);
            // modelBuilder.Entity<ArticleKeyword>().HasData(articleKeywords);
            // modelBuilder.Entity<ArticleCategory>().HasData(articleCategories);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }   
    }
}