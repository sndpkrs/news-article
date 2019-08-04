using FluentMigrator;

namespace NewsArticle.Migration
{
    [Migration(20180430121801)]
    public class AddLogTable : Migration
    {
        public override void Up()
        {
             Execute.Sql(@"CREATE TABLE NewsArticle 
                (
                    ID INT Primary Key,
                     TITLE Varchar(1000),
                     URL Varchar(1000),
                     PUBLISHER varchar(1000),
                     HOSTNAME varchar(1000),
                     TIMESTAMP varchar(1000),
                    CATEGORY varchar(1000)

                )");
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS NewsArticle");
        }
    }
}