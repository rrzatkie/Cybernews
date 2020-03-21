using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Models;
using Cybernews.DAL.Data;
using Cybernews.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cybernews.CybernewsApi.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IMapper mapper;
        private readonly CybernewsContext context;

        public ArticlesService(IMapper mapper, CybernewsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ServiceResponse<ArticleCardDto>> GetArticleCard(int articleId)
        {
            var serviceResponse = new ServiceResponse<ArticleCardDto>();
            var articleQuery = context.Articles;
            var article = await articleQuery.SingleOrDefaultAsync(x => x.Id == articleId);

            var categoriesQuery = context.Art;
            var articleCategories = await categoriesQuery.SingleOrDefaultAsync(x => x. == articleId);


            // serviceResponse.Data = mapper.Map<Dtos.ArticleCardDto>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<ArticleDetailsDto>> GetArticleDetails(int articleId)
        {
            var serviceResponse = new ServiceResponse<ArticleDetailsDto>();
            // TODO!
            //serviceResponse.Data =

            return serviceResponse;
        }

        public async Task<ServiceResponse<CategoryDto[]>> GetCategories()
        {
            var serviceResponse = new ServiceResponse<CategoryDto[]>();
            // TODO!
            //serviceResponse.Data =

            return serviceResponse;
        }

        public async Task<ServiceResponse<SlidesListDto>> GetSlides(int categoryId)
        {
            var serviceResponse = new ServiceResponse<SlidesListDto>();
            // TODO!
            //serviceResponse.Data =

            return serviceResponse;
        }
    }
}