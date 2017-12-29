﻿namespace MyApp.Models
{
    public class ListResult<T>
    {
        public string RecordIds { get; set; }

        public int TotalCount { get; set; }

        public int SecondaryCount { get; set; }

        public ListRecord<T>[] Records { get; set; }
    }
}
