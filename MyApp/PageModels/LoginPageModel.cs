using Xamarin.Forms;
using MyApp.Services.API;
using System.Windows.Input;
using System.Threading.Tasks;
using MyApp.Models;
using System.ComponentModel;
using FreshMvvm;

namespace MyApp.PageModels
{
    public class LoginPageModel : FreshBasePageModel, INotifyPropertyChanged
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

        public string WhiteLabellingLogo { get; set; }

        public string Message { get; set; }

        public bool IsBusy { get; set; }

        public ICommand OnLoginCommand { get; set; }

        public User User { get; set; }

        public async Task Login()
        {
            IsBusy = true;

            var loginResult = await LoginService?.Login(Username, Password);

            if (loginResult.User != null)
            {
                var masterDetailPage = (MasterDetailPage) FreshPageModelResolver.ResolvePageModel<MainPageModel>();

                await App.NavigationPage.PushAsync(FreshPageModelResolver.ResolvePageModel<DashboardPageModel>(loginResult.User));

                masterDetailPage.Detail = App.NavigationPage;

                Application.Current.MainPage = masterDetailPage;

                Message = null;
            } else {
                Message = loginResult.Error;
            }

            IsBusy = false;
        }

        public async Task GetSystemSettings() {
            var systemSettings = await LoginService?.GetSystemSettings();

            CompanyName = systemSettings?.CompanyName;
            WhiteLabellingLogo = systemSettings?.WhiteLabellingLogo;
        }
    }
}
