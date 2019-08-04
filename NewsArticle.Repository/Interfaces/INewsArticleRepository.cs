using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsArticle.Domain;

namespace NewsArticle.Repository.Interfaces
{
    public interface INewsArticleRepository: IGenericRepository<NewsArticle.Domain.NewsArticle>
    {
        int BulkInsert(List<NewsArticle.Domain.NewsArticle> newsArticles);
        Task<IEnumerable<Domain.NewsArticle>> GetAll();
    }
}
