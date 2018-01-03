using MyApp.Models;
using MyApp.Services.API;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyApp.Services
{
    public abstract class AbstractService<T> : IService<T>
    {
        public AbstractService(ICoreServiceDependencies coreServiceDependencies) {
            HttpService = coreServiceDependencies.HttpService;
            AppSettingsService = coreServiceDependencies.AppSettingsService;
        }

        protected internal IHttpService HttpService { get; set; }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        protected internal virtual AppSettings AppSettings {
            get
            {
                return AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);
            }
        }

        public async Task<ListResult<T>> Get(GetOptions options) {
            var url = $"{AppSettings.Api}/api/";

            url += !string.IsNullOrEmpty(options.Controller) ? options.Controller : typeof(T).Name;

            if (!string.IsNullOrEmpty(options.Action)) {
                url += "/" + options.Action;
            }

            var response = await HttpService.GetAsync(url, options.QueryParameters);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResult<T>>(content);
            }
            return null;
        }
    }
}
