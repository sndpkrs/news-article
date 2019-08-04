using MoralesLarios.Data.Dapper;
using NewsArticle.Domain;
using NewsArticle.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using DapperExtensions;
using System.Data.SqlClient;

namespace NewsArticle.Repository.Classes
{
    public class NewsArticleRepository: GenericRepository<Domain.NewsArticle>, INewsArticleRepository
    {
        public NewsArticleRepository(SqlConnection conn):base(conn)
        {
            this.con = conn;
        }

        public int BulkInsert(List<Domain.NewsArticle> newsArticles)
        {
            var query = $@"INSERT INTO NewsArticle (ID,TITLE,URL,PUBLISHER,CATEGORY,HOSTNAME,TIMESTAMP,TIMESTAMPDATE) values (@ID,@TITLE,@URL,@PUBLISHER,@CATEGORY,@HOSTNAME,@TIMESTAMP,@TIMESTAMPDATE)";
            con.Open();
            con.Execute(query, newsArticles);
            con.Close();
            return 1;
        }
    }
}
