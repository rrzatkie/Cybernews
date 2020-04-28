using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.DAL.Data.Entities;

namespace Cybernews.CybernewsApi.Mappings
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            CreateMap<Article, ArticleCardDto>()
            .ForMember(x => x.ArticleDateCreated, y => y.MapFrom( z =>  z.DateCreated))
            .ForMember(x => x.ArticleId, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ArticleImgUrl, y => y.MapFrom(z => z.ImageUrl))
            .ForMember(x => x.ArticleTitle, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.ArticleUrl, y => y.MapFrom(z => z.Url))
            .ForMember(x => x.ArticleCategories, y => y.MapFrom(z => new List<ArticleCategory>()));

            CreateMap<Article, SlideDto>()
            .ForMember(x => x.ArticleId, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ArticleImgUrl, y => y.MapFrom(z => z.ImageUrl))
            .ForMember(x => x.ArticleTitle, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.ArticleUrl, y => y.MapFrom(z => z.Url));

            CreateMap<Article, ArticleDetailsDto>()
            .ForMember(x => x.ArticleId, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ArticleImgUrl, y => y.MapFrom(z => z.ImageUrl))
            .ForMember(x => x.ArticleTitle, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.ArticleUrl, y => y.MapFrom(z => z.Url))
            .ForMember(x => x.ArticleKeywords, y => y.MapFrom(z => new List<ArticleKeyword>()));
            
            CreateMap<Category, CategoryDto>()
            .ForMember(x => x.CategoryId, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.CategoryNameToDisplay, y => y.MapFrom(z => z.NameToDisplay))
            .ForMember(x => x.CategorySlug, y => y.MapFrom(z => z.Slug));

            CreateMap<Keyword, KeywordDto>()
            .ForMember(x => x.KeywordId, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.KeywordNameToDisplay, y => y.MapFrom(z => z.NameToDisplay))
            .ForMember(x => x.KeywordSlug, y => y.MapFrom(z => z.Slug));

            CreateMap<ArticleDto, Article>()
            .ForMember(x => x.Author, y => y.MapFrom(z => z.Author))
            .ForMember(x => x.DateCreated, y => y.MapFrom(z => UnixToDatetimeConverter(z.DateCreatedUnix)))
            .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
            .ForMember(x => x.Url, y => y.MapFrom(z => z.Url))
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.DateAdded, y => y.MapFrom(z => DateTime.UtcNow));

            CreateMap<string, Category>()
            .ForMember(x => x.NameToDisplay, y => y.MapFrom(z => z))
            .ForMember(x => x.Slug, y => y.MapFrom(z => Slugify(z)));

            CreateMap<string, Keyword>()
            .ForMember(x => x.NameToDisplay, y => y.MapFrom(z => z))
            .ForMember(x => x.Slug, y => y.MapFrom(z => Slugify(z)));
        
        }
        private DateTime UnixToDatetimeConverter(System.Int32 date)
        {
            return new DateTime(1970, 1,1,0,0,0,0, System.DateTimeKind.Utc).AddSeconds(date);
        }

        private string Slugify(string input)
        {

            var slug = RemoveDiacritics(input).ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = slug.Substring(0, slug.Length <=45 ? slug.Length : 45).Trim();
            slug = Regex.Replace(slug, @"\s", "-");

            return slug;
        }

        private string RemoveDiacritics(string text) 
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
}