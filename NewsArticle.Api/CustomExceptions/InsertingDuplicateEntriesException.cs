using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsArticle.Api.CustomExceptions
{
    public class InsertingDuplicateEntriesException: Exception
    {
        public InsertingDuplicateEntriesException()
           : base($"You are trying to make a duplicate entries which already exists in the database")
        {
        }
    }
}
