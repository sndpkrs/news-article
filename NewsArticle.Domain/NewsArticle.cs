using System;

namespace NewsArticle.Domain
{
    public class NewsArticle: BaseEntity
    {
        public string TITLE { get; set; }
        public string URL { get; set; }
        public string PUBLISHER { get; set; }
        public string CATEGORY { get; set; }
        public string HOSTNAME { get; set; }
        public DateTime? TIMESTAMPDATE { get { return new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddMilliseconds(Convert.ToDouble(TIMESTAMP)).ToLocalTime(); } set { } }
        public string TIMESTAMP { get; set; } 
    }
}
