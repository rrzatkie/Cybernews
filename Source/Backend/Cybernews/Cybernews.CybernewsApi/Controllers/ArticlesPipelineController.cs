using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.DAL.Data.Entities;
using Microsoft.AspNetCore.Mvc;
//using Cybernews.CybernewsApi.Models;

namespace Cybernews.CybernewsApi.Controllers
{
    [Route("api/pipeline")]
    [ApiController]
    public class ArticlesPipelineController : ControllerBase
    {

        private readonly Services.IArticlesPipelineService service;
        public ArticlesPipelineController(Services.IArticlesPipelineService service)
        {
            this.service = service;

        }

        [HttpGet("articles")]
        public async Task<ActionResult> GetArticles()
        {
            return Ok(await service.GetArticles());
        }

        [HttpPost("articles/add")]
        public async Task<ActionResult> AddArticles(List<ArticleDto> articles)
        {
            return Ok(await service.AddArticles(articles));
        }

        [HttpPost("articles/")]
        public async Task<ActionResult> UpdateArticle(Article article)
        {
            return Ok(await service.UpdateArticle(article));
        }

        [HttpPost("articles/category")]
        public async Task<ActionResult> UpdateCategories([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            return Ok(await service.UpdateCategories(updateCategoryDto));
        }


        [HttpPost("articles/keyword")]
        public async Task<ActionResult> UpdateKeyword([FromBody] UpdateKeywordDto updateKeywordDto)
        {
            return Ok(await service.UpdateKeywords(updateKeywordDto));
        }


        [HttpPost("similarities/add")]
        public async Task<ActionResult> AddSimilarity([FromBody] ArticlesSimilarityDto articlesSimilarity)
        {
            return Ok(await service.AddSimilarity(articlesSimilarity));
        }
    }
}