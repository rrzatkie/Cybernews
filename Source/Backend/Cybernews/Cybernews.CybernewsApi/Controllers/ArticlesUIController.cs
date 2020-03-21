using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Cybernews.CybernewsApi.Models;

namespace Cybernews.CybernewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesUIController : ControllerBase
    {
        private readonly Services.IArticlesService articlesService;
        public ArticlesUIController(Services.IArticlesService articlesService)
        {
            this.articlesService = articlesService;

        }

        [HttpGet("articleCard/{id}")]
        public async Task<ActionResult> GetArticleCard(int id)
        {
            return Ok(await articlesService.GetArticleCard(id));
        }


        [HttpGet("articleDetails/{articleId}")]
        public async Task<ActionResult> GetArtcleDetails(int id)
        {
            return Ok(await articlesService.GetArticleDetails(id));
        }


        [HttpGet("categories")]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await articlesService.GetCategories());
        }


        [HttpGet("slides/{id}")]
        public async Task<ActionResult> GetSlides(int id)
        {
            return Ok(await articlesService.GetSlides(id));
        }
    }
}