using System.Collections.Generic;
using System.IO.Compression;
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
        }
        
    }
}