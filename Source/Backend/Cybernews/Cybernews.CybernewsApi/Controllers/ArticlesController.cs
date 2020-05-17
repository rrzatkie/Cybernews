using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Microsoft.AspNetCore.Mvc;
//using Cybernews.CybernewsApi.Models;

namespace Cybernews.CybernewsApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ArticlesUIController : ControllerBase
    {
        private readonly Services.IArticlesService articlesService;
        public ArticlesUIController(Services.IArticlesService articlesService)
        {
            this.articlesService = articlesService;

        }

        [HttpGet("articleCards")]
        public async Task<ActionResult> GetArticleCards([FromQuery] PaginationOptionsDto paginationOptions, [FromQuery] QueryDto query)
        {
            return Ok(await articlesService.GetArticleCards(paginationOptions, query));
        }

        [HttpGet("articles/top")]
        public async Task<ActionResult> GetTopArticles([FromQuery] QueryDto query)
        {
            return Ok(await articlesService.GetTopArticles(query));
        }

        [HttpGet("articles/archive")]
        public async Task<ActionResult> GetArticlesArchive([FromQuery] QueryDto query)
        {
            return Ok(await articlesService.GetArticlesArchive(query));
        }


        [HttpGet("articleDetails/{id}")]
        public async Task<ActionResult> GetArtcleDetails(int id)
        {
            return Ok(await articlesService.GetArticleDetails(id));
        }


        [HttpGet("categories/all")]
        public async Task<ActionResult> GetAllCategories()
        {
            return Ok(await articlesService.GetAllCategories());
        }

        [HttpGet("categories/top")]
        public async Task<ActionResult> GetTopCategories([FromQuery] QueryDto query)
        {
            return Ok(await articlesService.GetTopCategories(query));
        }


        [HttpGet("keywords/all")]
        public async Task<ActionResult> GetKeywords()
        {
            return Ok(await articlesService.GetAllKeywords());
        }

        [HttpGet("keywords/top")]
        public async Task<ActionResult> GetTopKeywords([FromQuery] QueryDto query)
        {
            return Ok(await articlesService.GetTopKeywords(query));
        }

        [HttpPost("article/add")]
        public async Task<ActionResult> AddArticles(ArticleDto[] articles)
        {
            return Ok(await articlesService.AddArticles(articles));
        }


        [HttpPut("article/category")]
        public async Task<ActionResult> UpdateCategories(UpdateCategoryDto updateCategoryDto)
        {
            return Ok(await articlesService.UpdateCategories(updateCategoryDto));
        }


        [HttpPut("article/keyword")]
        public async Task<ActionResult> UpdateKeyword(UpdateKeywordDto updateKeywordDto)
        {
            return Ok(await articlesService.UpdateKeywords(updateKeywordDto));
        }


        [HttpPost("similarity/add")]
        public async Task<ActionResult> AddSimilarity(ArticlesSimilarityDto articlesSimilarity)
        {
            return Ok(await articlesService.AddSimilarity(articlesSimilarity));
        }
    }
}