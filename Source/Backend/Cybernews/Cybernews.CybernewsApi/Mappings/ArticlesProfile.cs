using AutoMapper;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.DAL.Data.Entities;

namespace Cybernews.CybernewsApi.Mappings
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            CreateMap<Article, ArticleCardDto>();
        }
        
    }
}