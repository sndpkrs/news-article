//using DapperExtensions;
using DapperExtenderRepository;
using MoralesLarios.Data.Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticle.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>: IDisposable where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> GetByPredicate(IPredicateGroup predicateGroup);
        Task<IEnumerable<TEntity>> GetByPredicateAsync(IPredicateGroup predicateGroup);
    }
}
