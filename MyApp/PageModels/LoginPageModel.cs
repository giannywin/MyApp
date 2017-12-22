using Xamarin.Forms;
using MyApp.Services.API;
using System.Windows.Input;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.PageModels
{
    public class LoginPageModel : BasePageModel
    {
        public LoginPageModel(ILoginService loginService)
        {
            LoginService = loginService;

            OnLoginCommand = new Command(async () => { await Login(); });
        }

        protected internal ILoginService LoginService { get; set; }

        public override void Init(object initData) {
            base.Init(initData);

            Title = AppSettings?.AppName;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Title { get; set; }

        public ICommand OnLoginCommand { get; set; }

        public User User { get; set; }

        public async Task Login()
        {
            var user = await LoginService?.Login(Username, Password);

            if (Application.Current.Properties.ContainsKey(MyAppConstants.CurrentUser))
            {
                Application.Current.Properties[MyAppConstants.CurrentUser] = user;
            }
            else
            {
                Application.Current.Properties.Add(MyAppConstants.CurrentUser, user);
            }

            await CoreMethods.PushPageModel<DashboardPageModel>(user);
        }

    }
}
