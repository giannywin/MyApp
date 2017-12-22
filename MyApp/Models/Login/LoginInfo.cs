namespace MyApp.Models.Login
{
    public class LoginInfo
    {
        public User User { get; set; }

        public int? LoginStatus { get; set; }

        public LoginUserSettings UserSettings { get; set; }
    }
}
