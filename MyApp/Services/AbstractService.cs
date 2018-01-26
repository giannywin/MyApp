using MyApp.Models;
using MyApp.Services.API;
using System.Threading.Tasks;
using MyApp.Models.Widgets;

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

            return await HttpService.GetAsync<ListResult<T>>(url, options.QueryParameters);
        }

        public async Task<ListOptions<T>> ListOptions(Widget widget) {
            var url = GetListOptionsUrl(widget.ListId);

            return await HttpService.GetAsync<ListOptions<T>>(url);
        }

        private string GetListOptionsUrl(string listId) {
            var url = $"{AppSettings.Api}";

            url = url + (listId.EndsWith(".json", System.StringComparison.OrdinalIgnoreCase)
                        ? "/assets/json/list-configs/" + listId
                         : "/api/" + listId + "/listoptions");

            return url;
        }

        public async Task<dynamic> GetForm(Widget widget)
        {
            var url = GetFormUrl(widget.FormUrl);

            return await HttpService.GetAsync(url);
        }

        private string GetFormUrl(string formUrl) {
            var url = $"{AppSettings.Api}";

            url = url + (formUrl.EndsWith(".json", System.StringComparison.OrdinalIgnoreCase)
                         ? "/assets/json/form-configs/" + formUrl
                         : "/api/" + formUrl + "/getform");

            return url;
        }
    }
}
