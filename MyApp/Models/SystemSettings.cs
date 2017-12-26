using System;
namespace MyApp.Models
{
    public class SystemSettings
    {
        public string CompanyName { get; set; }

        public int PortalAuthenticationMethod { get; set; }

        public bool PortalDisableMyRecords { get; set; }

        public bool PortalDisableMyWork { get; set; }

        public bool PortalDisableIncidents { get; set; }

        public string WhiteLabellingLogo { get; set; }
    }
}
