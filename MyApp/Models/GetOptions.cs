using System.Collections.Generic;

namespace MyApp.Models
{
    public class GetOptions
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public Dictionary<string, object> QueryParameters { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string ViewId { get; set; }
    }
}
