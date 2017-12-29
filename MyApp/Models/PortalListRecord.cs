using System;
namespace MyApp.Models
{
    public class PortalListRecord : BaseModel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string SubTitleLabel { get; set; }

        public string SubDetail { get; set; }

        public string Detail { get; set; }

        public string DetailLabel { get; set; }

        public string Summary { get; set; }

        public DateTime? DateSortValue { get; set; }

        public DateTime? SecondDateSortValue { get; set; }

        public MyTaskRecordType? RecordType { get; set; }
    }
}
