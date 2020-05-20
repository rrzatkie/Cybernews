using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Microsoft.AspNetCore.Mvc;
//using Cybernews.CybernewsApi.Models;

namespace Cybernews.CybernewsApi.Controllers
{
    [Route("api/ui")]
    [ApiController]
    public class ArticlesUIController : ControllerBase
    {
        private readonly Services.IArticlesUIService service;
        public ArticlesUIController(Services.IArticlesUIService service)
        {
            this.service = service;

        }

        [HttpGet("articleCards")]
        public async Task<ActionResult> GetArticleCards([FromQuery] PaginationOptionsDto paginationOptions, [FromQuery] QueryDto query)
        {
            return Ok(await service.GetArticleCards(paginationOptions, query));
        }

        [HttpGet("articles/top")]
        public async Task<ActionResult> GetTopArticles([FromQuery] QueryDto query)
        {
            return Ok(await service.GetTopArticles(query));
        }

        [HttpGet("articles/archive")]
        public async Task<ActionResult> GetArticlesArchive([FromQuery] QueryDto query)
        {
            return Ok(await service.GetArticlesArchive(query));
        }


        [HttpGet("articleDetails/{id}")]
        public async Task<ActionResult> GetArtcleDetails(int id)
        {
            return Ok(await service.GetArticleDetails(id));
        }


        [HttpGet("categories/all")]
        public async Task<ActionResult> GetAllCategories()
        {
            return Ok(await service.GetAllCategories());
        }

        [HttpGet("categories/top")]
        public async Task<ActionResult> GetTopCategories([FromQuery] QueryDto query)
        {
            return Ok(await service.GetTopCategories(query));
        }


        [HttpGet("keywords/all")]
        public async Task<ActionResult> GetKeywords()
        {
            return Ok(await service.GetAllKeywords());
        }

        [HttpGet("keywords/top")]
        public async Task<ActionResult> GetTopKeywords([FromQuery] QueryDto query)
        {
            return Ok(await service.GetTopKeywords(query));
        }
    }
}