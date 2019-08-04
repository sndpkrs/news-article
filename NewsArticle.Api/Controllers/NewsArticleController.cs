using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DapperExtenderRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticle.Api.CustomExceptions;
using NewsArticle.Api.Services;
using NewsArticle.Repository.Interfaces;

namespace NewsArticle.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticleController : ControllerBase
    {
        public INewsArticleRepository newsRepo;
        public IFetchService fetchService;
        public NewsArticleController(INewsArticleRepository newsRepo, IFetchService fetchService)
        {
            this.newsRepo = newsRepo;
            this.fetchService = fetchService;
        }
        // GET: api/NewsArticle
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        [Route("getdatafromapi")]
        public string GetDataFromApi()
        {
            var newsArticles = fetchService.GetDataFromApi().Result;
            try
            {
                newsRepo.BulkInsert(newsArticles.ToList());
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new InsertingDuplicateEntriesException();
            }
            return "Successfully Fetched and Inserted";
        }
        [HttpGet]
        [Route("getfromdb")]
        public async Task<ActionResult<IEnumerable<string>>> GetFromDb()
        {
            var newsArticles = await newsRepo.GetAll();
            return Ok(newsArticles);
        }
        [HttpGet]
        [Route("getfromdbfordaterange")]
        public async Task<ActionResult<IEnumerable<string>>> GetFromDbForDateRange([FromQuery] string fromDate, string toDate)
        {
            var finalArticles = new List<NewsArticle.Domain.NewsArticle>();
            var predicateGroup = new PredicateGroup()
            {
                Operator = GroupOperator.And,
                Predicates = new List<IPredicate>()
            }; 
            predicateGroup.Predicates.Add(Predicates.Field<Domain.NewsArticle>(f => f.TIMESTAMPDATE, Operator.Ge, Convert.ToDateTime(fromDate)));
            predicateGroup.Predicates.Add(Predicates.Field<Domain.NewsArticle>(f => f.TIMESTAMPDATE, Operator.Le, Convert.ToDateTime(toDate)));

            var dateFilteredArticles = await newsRepo.GetByPredicateAsync(predicateGroup);
            return Ok(dateFilteredArticles);
        }
        [HttpGet]
        [Route("getfromdbbyfilterfield")]
        public async Task<ActionResult<IEnumerable<string>>> GetFromDbByFilterField([FromQuery] Domain.NewsArticle newsArticle)
        {
            var predicateGroup = new PredicateGroup()
            {
                Operator = GroupOperator.Or,
                Predicates = new List<IPredicate>()
            };
            if(!string.IsNullOrEmpty( newsArticle.PUBLISHER))
            predicateGroup.Predicates.Add(Predicates.Field<Domain.NewsArticle>(f => f.PUBLISHER, Operator.Like, newsArticle.PUBLISHER ));
            if (!string.IsNullOrEmpty(newsArticle.CATEGORY))
                predicateGroup.Predicates.Add(Predicates.Field<Domain.NewsArticle>(f => f.CATEGORY, Operator.Like, newsArticle.CATEGORY));

            var filteredArticles = await newsRepo.GetByPredicateAsync(predicateGroup);
            return Ok(filteredArticles);
        }
        // GET: api/NewsArticle/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NewsArticle
        [HttpPost]
        public void Post([FromBody] string value)
        {
            if(value == "fetch")
            {
                fetchService.GetDataFromApi();
            }
        }

        // PUT: api/NewsArticle/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
