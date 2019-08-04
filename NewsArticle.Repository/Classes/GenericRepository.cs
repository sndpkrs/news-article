//using DapperExtensions;
using MoralesLarios.Data.Dapper;
using NewsArticle.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Data.Common;
using System.Linq;
using NewsArticle.Domain;
using System.Threading.Tasks;
using DapperExtenderRepository;

namespace NewsArticle.Repository.Classes
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public string TableName = typeof(TEntity).Name.ToString();
        private IList<ISort> PageSort { get; set; }
        private int PageOffset { get; set; }
        private int PageLimit { get; set; }
        public SqlConnection con;
        public GenericRepository(SqlConnection conn)
        {
            con = conn;
            PageSort = new List<ISort>
            {
                Predicates.Sort<TEntity>(entity => entity.ID)
            };
            PageOffset = 0;
            PageLimit = 1000;
        }

        public IEnumerable<TEntity> GetByPredicate(IPredicateGroup predicateGroup)
        {
            con.Open();
                return con.GetPage<TEntity>(predicateGroup, PageSort, PageOffset, PageLimit).ToList();
        }
        public async Task<IEnumerable<TEntity>> GetByPredicateAsync(IPredicateGroup predicateGroup)
        {
            con.Open();
            return await con.GetPageAsync<TEntity>(predicateGroup, PageSort, PageOffset, PageLimit);
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GenericRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> entities;
            var query = $@"SELECT * FROM {TableName}";
            con.Open();
            entities = await con.QueryAsync<TEntity>(query);
            con.Close();
            return entities;
        }

        #endregion
    }
}
