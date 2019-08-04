using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NewsArticle.Domain;
using Newtonsoft.Json;

namespace NewsArticle.Api.Services
{
    public class FetchService : IFetchService
    {
        public async Task<IEnumerable<Domain.NewsArticle>> GetDataFromApi()
        {
            IEnumerable<NewsArticle.Domain.NewsArticle> parseData = new List<Domain.NewsArticle>();
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri( $"https://api.myjson.com/bins/10ijyt");
                var jsonData = await client.GetAsync($"https://api.myjson.com/bins/10ijyt");
                var example = await jsonData.Content.ReadAsStringAsync();
                try
                {
                    parseData = JsonConvert.DeserializeObject<IEnumerable<Domain.NewsArticle>>(example);
                }
                catch (Exception e)
                {

                    throw;
                }
                return parseData;
            }
        }
    }
}
