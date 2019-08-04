using NewsArticle.Domain;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace NewsArticleCustomRepository
{
    public class CustomRepository
    {
        public async Task CustomAdd(NewsArticle.Domain.NewsArticle newsArticle)
        {
            var query = "INSERT INTO NewsArticle (Title) Values ('Huhu')";
            using (SqlConnection connn = new SqlConnection("server=localhost;uid=dxdev;pwd=dXd3v;database=NewsDb;"))
            {
                //connn.ExecuteAsync
            }
        }
    }
}
