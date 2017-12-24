using Xamarin.Forms;
using MyApp.Services.API;
using System.Windows.Input;
using System.Threading.Tasks;
using MyApp.Models;
using System.ComponentModel;

namespace MyApp.PageModels
{
    public class LoginPageModel : FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        public LoginPageModel(ILoginService loginService, IAppSettingsService appSettingsService)
        {
            LoginService = loginService;
            AppSettingsService = appSettingsService;

            OnLoginCommand = new Command(async () => { await Login(); });
        }

        protected internal ILoginService LoginService { get; set; }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        public override void Init(object initData) {
            base.Init(initData);
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string CompanyName { get; set; }

        public string Message { get; set; }

        public ICommand OnLoginCommand { get; set; }

        public User User { get; set; }

        public async Task Login()
        {
            var loginResult = await LoginService?.Login(Username, Password);

            if (loginResult.User != null)
            {
                await CoreMethods.PushPageModel<DashboardPageModel>(loginResult.User);
                Message = null;
            } else {
                Message = loginResult.Error;
            }
        }

        public async Task GetSystemSettings() {
            var systemSettings = await LoginService?.GetSystemSettings();

            CompanyName = systemSettings?.CompanyName;
        }
    }
}
