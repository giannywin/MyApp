namespace MyApp.Models.Demographics
{
    public class Employee : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string EmployeeNumber { get; set; }
    }
}
