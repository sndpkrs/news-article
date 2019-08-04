using System;
using System.Collections.Generic;
using System.Text;

namespace NewsArticle.Domain
{
    public class NewsArticleResponseModel
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string URL { get; set; }
        public string PUBLISHER { get; set; }
        public string CATEGORY { get; set; }
        public string HOSTNAME { get; set; }
        public string TIMESTAMP { get; set; }
    }
}
