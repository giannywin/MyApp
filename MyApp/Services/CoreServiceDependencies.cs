using MyApp.Services.API;

namespace MyApp.Services
{
    public class CoreServiceDependencies : ICoreServiceDependencies
    {
        public CoreServiceDependencies(IHttpService httpService)
        {
            HttpService = httpService;
        }

        public IHttpService HttpService { get; set; }
    }
}
