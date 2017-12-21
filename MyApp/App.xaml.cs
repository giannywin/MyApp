using MyApp.PageModels;
using Xamarin.Forms;
using MyApp.Models;
using MyApp.Services;
using MyApp.Services.API;
using FreshMvvm;

namespace MyApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterDependencies();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginPageModel>());
        }

        protected override void OnStart()
        {
            var appSettingsService = FreshIOC.Container.Resolve<IAppSettingsService>();

            var settings = appSettingsService.GetSettings();

            Properties[MyAppConstants.AppSettings] = settings;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected void RegisterDependencies() {
            FreshIOC.Container.Register<ICoreServiceDependencies, CoreServiceDependencies>();
            FreshIOC.Container.Register<IAppSettingsService, AppSettingService>();
            FreshIOC.Container.Register<ILoginService, LoginService>();
        }
    }
}
