using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsArticle.Api.Services
{
    public interface IFetchService
    {
        Task<IEnumerable<Domain.NewsArticle>> GetDataFromApi();
    }
}
