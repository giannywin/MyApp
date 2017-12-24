using MyApp.Models;
using MyApp.Services.API;

namespace MyApp.Services
{
    public abstract class BaseService
    {
        public BaseService(ICoreServiceDependencies coreServiceDependencies) {
            AppSettingsService = coreServiceDependencies.AppSettingsService;
            HttpService = coreServiceDependencies.HttpService;
        }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        protected internal IHttpService HttpService { get; set; }


        protected internal virtual AppSettings AppSettings
        {
            get
            {
                return AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);
            }
        }

        protected internal virtual User CurrentUser
        {
            get
            {
                return AppSettingsService.Get<User>(MyAppConstants.CurrentUser);
            }
        }
    }
}
