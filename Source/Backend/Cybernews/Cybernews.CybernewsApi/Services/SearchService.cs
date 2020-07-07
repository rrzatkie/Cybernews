using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cybernews.CybernewsApi.Dtos;
using Cybernews.CybernewsApi.Dtos.Search;
using Cybernews.CybernewsApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using Cybernews.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Cybernews.CybernewsApi.Models.Enums;

namespace Cybernews.CybernewsApi.Services
{
    public class SearchService : ISearchService
    {
        private readonly ElasticClient client;
        private readonly IConfiguration config;
        private readonly CybernewsContext context;
        private readonly IMapper mapper;
        private readonly ILogger<SearchService> logger; 
        public SearchService(CybernewsContext context, IConfiguration config, IMapper mapper, ILogger<SearchService> logger)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            var settings = new ConnectionSettings(new Uri(config["ElasticSearch:Uri"]))
                .DefaultIndex(config["ElasticSearch:DefaultIndex"]);
            this.client = new ElasticClient(settings);
        }

        public async Task<ServiceResponse<int>> IndexArticles()
        {
            var serviceResponse = new ServiceResponse<int>();
            
            var indexName = config["ElasticSearch:ArticlesIndex"];
            var existResponse = await this.client.Indices.ExistsAsync(indexName);
            if(existResponse.Exists)
            {
                this.client.Indices.Delete(indexName.ToLowerInvariant());
                await this.context.Articles.ForEachAsync(x => x.IndexRunAt=null);
                await this.context.SaveChangesAsync();
            }

            logger.LogInformation($"Index: {indexName} exists. Deleting.");
            var createIndexResponse = this.client.Indices.Create(indexName, c => c
                .Settings(s => s
                    .Analysis(als => als
                        .Analyzers(alz => alz
                            .Custom("autocomplete", c1 => c1
                                .Tokenizer("autocomplete")
                                .Filters(new string[]{"lowercase"})
                            )
                            .Custom("autocomplete_search", c2 => c2
                                .Tokenizer("standard") 
                                .Filters(new string[]{"lowercase"})
                            )
                        )
                        .Tokenizers(t => t
                            .EdgeNGram("autocomplete", eg => eg
                                .MinGram(2)
                                .MaxGram(20)
                                .TokenChars(
                                    TokenChar.Letter,
                                    TokenChar.Digit
                                )
                            )
                        )
                    )
                )
                .Map<SearchArticleDto>(m => m
                    .AutoMap()
                    .Properties(ps => ps
                        .Text(t => t
                            .Name(n => n.Title)
                            .Analyzer("autocomplete")
                            .SearchAnalyzer("autocomplete_search")
                        )
                    )
                )
            );
            
            var articlesQuery = this.context.Articles;
            var count = await articlesQuery.CountAsync();
            
            for(var i=0; i<count; i+=512){
                var articlesEntities = await articlesQuery
                    .Where(x=>x.IndexRunAt == null)
                    .Skip(i)
                    .Take(512)
                    .ToListAsync();
                var articles = this.mapper.Map<List<SearchArticleDto>>(articlesEntities);

                logger.LogInformation("Indexing articles:");
                logger.LogInformation(string.Join("\n ", articles.Select(x => x.Title).ToList()));
                
                var indexResponse = await this.client.IndexManyAsync(articles, indexName);

                if(indexResponse.IsValid)
                {
                    serviceResponse.Data += indexResponse.Items.Count;
                }
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> IndexCategories()
        {
            var serviceResponse = new ServiceResponse<int>();
            
            var indexName = config["ElasticSearch:CategoriesIndex"];
            var existResponse = await this.client.Indices.ExistsAsync(indexName);
            if(existResponse.Exists)
            {
                this.client.Indices.Delete(indexName.ToLowerInvariant());
            }

            logger.LogInformation($"Index: {indexName} exists. Deleting.");
            var createIndexResponse = this.client.Indices.Create(indexName, c => c
                .Settings(s => s
                    .Analysis(als => als
                        .Analyzers(alz => alz
                            .Custom("autocomplete", c1 => c1
                                .Tokenizer("autocomplete")
                                .Filters(new string[]{"lowercase"})
                            )
                            .Custom("autocomplete_search", c2 => c2
                                .Tokenizer("standard") 
                                .Filters(new string[]{"lowercase"})
                            )
                        )
                        .Tokenizers(t => t
                            .EdgeNGram("autocomplete", eg => eg
                                .MinGram(2)
                                .MaxGram(20)
                                .TokenChars(
                                    TokenChar.Letter,
                                    TokenChar.Digit
                                )
                            )
                        )
                    )
                )
                .Map<SearchCategoryDto>(m => m
                    .AutoMap()
                    .Properties(ps => ps
                        .Text(t => t
                            .Name(n => n.Name)
                            .Analyzer("autocomplete")
                            .SearchAnalyzer("autocomplete_search")
                        )
                    )
                )
            );
            
            var categoriesQuery = this.context.Categories;
            var count = await categoriesQuery.CountAsync();
            
            var categoriesEntities = await categoriesQuery.ToListAsync();
            var categories = this.mapper.Map<List<SearchCategoryDto>>(categoriesEntities);

            logger.LogInformation("Indexing categorties:");
            logger.LogInformation(string.Join("\n ", categories.Select(x => x.Name).ToList()));
            
            var indexResponse = await this.client.IndexManyAsync(categories, indexName);

            if(indexResponse.IsValid)
            {
                serviceResponse.Data += indexResponse.Items.Count;
            }
        
            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> IndexKeywords()
        {
            var serviceResponse = new ServiceResponse<int>();
            
            var indexName = config["ElasticSearch:KeywordsIndex"];
            var existResponse = await this.client.Indices.ExistsAsync(indexName);
            if(existResponse.Exists)
            {
                this.client.Indices.Delete(indexName.ToLowerInvariant());
            }

            logger.LogInformation($"Index: {indexName} exists. Deleting.");
            var createIndexResponse = this.client.Indices.Create(indexName, c => c
                .Settings(s => s
                    .Analysis(als => als
                        .Analyzers(alz => alz
                            .Custom("autocomplete", c1 => c1
                                .Tokenizer("autocomplete")
                                .Filters(new string[]{"lowercase"})
                            )
                            .Custom("autocomplete_search", c2 => c2
                                .Tokenizer("whitespace")
                                .Filters(new string[]{"lowercase"})
                            )
                        )
                        .Tokenizers(t => t
                            .EdgeNGram("autocomplete", eg => eg
                                .MinGram(2)
                                .MaxGram(20)
                                .TokenChars(
                                    TokenChar.Letter,
                                    TokenChar.Digit
                                )
                            )
                        )
                    )
                )
                .Map<SearchKeywordDto>(m => m
                    .AutoMap()
                    .Properties(ps => ps
                        .Text(t => t
                            .Name(n => n.Name)
                            .Analyzer("autocomplete")
                            .SearchAnalyzer("autocomplete_search")
                        )
                    )
                )
            );
            
            var keywordsQuery = this.context.Keywords;
            var count = await keywordsQuery.CountAsync();
            
            var keywordsEntities = await keywordsQuery.ToListAsync();
            var keywords = this.mapper.Map<List<SearchKeywordDto>>(keywordsEntities);

            logger.LogInformation("Indexing keywords:");
            logger.LogInformation(string.Join("\n ", keywords.Select(x => x.Name).ToList()));
            
            var indexResponse = await this.client.IndexManyAsync(keywords, indexName);

            if(indexResponse.IsValid)
            {
                serviceResponse.Data += indexResponse.Items.Count;
            }
        
            return serviceResponse;
        }

        public async Task<ServiceResponse<SearchResultDto>> Search(string keyword, SearchType type)
        {
            var serviceResponse = new ServiceResponse<SearchResultDto>()
            {
                Data = new SearchResultDto
                {
                    Articles = new List<SlideDto>(),
                    Categories = new List<CategoryDto>(),
                    Keywords = new List<KeywordDto>()
                }
            };
            var indexName = config["ElasticSearch:ArticlesIndex"];

            if(type == SearchType.Articles){
                var articlesQuery = this.context.Articles;

                var responseArticles = await this.client.SearchAsync<SearchArticleDto>( s => s
                    .Index(indexName)
                    .From(0)
                    .Size(10)
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.Title)
                            .Query(keyword)
                        )
                    )
                );
                this.logger.LogDebug(responseArticles.ApiCall.DebugInformation);

                var articles = await articlesQuery
                    .Where(x => 
                        responseArticles.Documents
                            .Select(y => y.Id)
                            .Contains(x.Id)
                    ).ToListAsync();

                serviceResponse.Data.Articles = this.mapper.Map<List<SlideDto>>(articles);
            }

            if(type == SearchType.Keywords){
                var keywordsQuery = this.context.Keywords;

                indexName = config["ElasticSearch:KeywordsIndex"];
                var responseKeywords = await this.client.SearchAsync<SearchKeywordDto>(s => s
                    .Index(indexName)
                    .From(0)
                    .Size(10)
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.Name)
                            .Query(keyword)
                        )
                    )
                );
                this.logger.LogDebug(responseKeywords.ApiCall.DebugInformation);

                var keywords = await keywordsQuery
                    .Where(x => 
                        responseKeywords.Documents
                            .Select(y => y.Id)
                            .Contains(x.Id)
                    ).ToListAsync();

                serviceResponse.Data.Keywords = this.mapper.Map<List<KeywordDto>>(keywords);
            }

            if(type == SearchType.Categories){
                var categoriesQuery = this.context.Categories;

                indexName = config["ElasticSearch:CategoriesIndex"];
                var responseCategories = await this.client.SearchAsync<SearchCategoryDto>(s => s
                    .Index(indexName)
                    .From(0)
                    .Size(10)
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.Name)
                            .Query(keyword)
                        )
                    )
                );
                this.logger.LogDebug(responseCategories.ApiCall.DebugInformation);

                var categories = await categoriesQuery
                    .Where(x => 
                        responseCategories.Documents
                            .Select(y => y.Id)
                            .Contains(x.Id)
                    ).ToListAsync();
                                    
                serviceResponse.Data.Categories = this.mapper.Map<List<CategoryDto>>(categories);
            }
    
            return serviceResponse;
        }
    }
}