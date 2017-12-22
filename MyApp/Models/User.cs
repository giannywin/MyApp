using MyApp.Models.Demographics;

namespace MyApp.Models
{
    public class User : BaseModel
    {
        public string LoginName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public Employee Employee { get; set; }
    }
}
