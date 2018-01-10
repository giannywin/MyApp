using MyApp.Models;
using MyApp.Services.API;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyApp.Models.WidgetConfiguration;

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

            url += !string.IsNullOrEmpty(options.Url) ? options.Url : (!string.IsNullOrEmpty(options.Controller) ? options.Controller : typeof(T).Name);

            if (!string.IsNullOrEmpty(options.Action) && string.IsNullOrEmpty(options.Url)) {
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

        public async Task<ListOptions<T>> ListOptions(Widget widget) {
            var url = GetListOptionsUrl(widget.ListId);

            var response = await HttpService.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListOptions<T>>(content);
            }
            return null;
        }

        private string GetListOptionsUrl(string listId) {
            var url = $"{AppSettings.Api}";

            url = url + (listId.EndsWith(".json", System.StringComparison.OrdinalIgnoreCase)
                        ? "/assets/json/list-configs/" + listId
                         : "/api/" + listId + "/listoptions");

            return url;
        }
    }
}
