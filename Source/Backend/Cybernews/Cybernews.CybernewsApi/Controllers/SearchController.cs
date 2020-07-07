using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Dtos.Search;
using Cybernews.CybernewsApi.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Cybernews.CybernewsApi.Controllers
{    
    [Route("search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly Services.ISearchService service;
        public SearchController(Services.ISearchService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Search([FromQuery] string keyword, [FromQuery] SearchType type)
        {
            return Ok(await service.Search(keyword, type));
        }

        [HttpPost("/es/index/articles")]
        public async Task<ActionResult> IndexArticles()
        {
            return Ok(await service.IndexArticles());
        }

        [HttpPost("/es/index/keywords")]
        public async Task<ActionResult> IndexKeywords()
        {
            return Ok(await service.IndexKeywords());
        }

        [HttpPost("/es/index/categories")]
        public async Task<ActionResult> IndexCategories()
        {
            return Ok(await service.IndexCategories());
        }
    }
}