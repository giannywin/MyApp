using MyApp.Models;
using System.ComponentModel;
using MyApp.Services.API;

namespace MyApp.PageModels
{
    public class DashboardPageModel : FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        public DashboardPageModel(ICoreServiceDependencies coreServiceDependencies)
        {
            HttpService = coreServiceDependencies.HttpService;
            AppSettingsService = coreServiceDependencies.AppSettingsService;
        }

        protected internal IHttpService HttpService { get; set; }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        public User User { get; set; }

        public AppSettings AppSettings { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            User = initData as User;
            AppSettings = AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);
        }
    }
}
