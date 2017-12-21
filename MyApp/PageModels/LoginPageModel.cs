using Xamarin.Forms;
using MyApp.Services.API;
using System.Windows.Input;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.PageModels
{
    public class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        public LoginPageModel(ILoginService loginService)
        {
            LoginService = loginService;

            OnLoginCommand = new Command(async () => { await Login(); });
        }

        protected internal ILoginService LoginService { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Title { get; set; } = "MyApp";

        public ICommand OnLoginCommand { get; set; }

        public User User { get; set; }

        public async Task Login()
        {
            var user = await LoginService?.Login(Username, Password);

            await CoreMethods.PushPageModel<DashboardPageModel>(user);

            CoreMethods.RemoveFromNavigation<LoginPageModel>();
        }

    }
}
