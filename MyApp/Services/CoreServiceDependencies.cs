using MyApp.Services.API;

namespace MyApp.Services
{
    public class CoreServiceDependencies : ICoreServiceDependencies
    {
        public CoreServiceDependencies(IHttpService httpService, IAppSettingsService appSettingsService)
        {
            HttpService = httpService;
            AppSettingsService = appSettingsService;
        }

        public IHttpService HttpService { get; set; }

        public IAppSettingsService AppSettingsService { get; set; }
    }
}
