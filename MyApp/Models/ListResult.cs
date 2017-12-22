using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public class ListResult<T>
    {
        public string RecordIds { get; set; }

        public int TotalCount { get; set; }

        public int SecondaryCount { get; set; }

        public IEnumerable<ListRecord<T>> Records { get; set; }
    }
}
