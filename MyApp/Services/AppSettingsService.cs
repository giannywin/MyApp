using MyApp.Models;
using MyApp.Services.API;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyApp.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        public AppSettingsService(IFileStorage fileStorage)
        {
            FileStorage = fileStorage;
        }

        protected internal IFileStorage FileStorage { get; set; }

        public AppSettings GetSettings()
        {
            var json = FileStorage.ReadAsString(MyAppConstants.AppSettingsFilename);

            var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);

            return appSettings;
        }

        public T Get<T>(string key) {
            if (Application.Current.Properties.ContainsKey(key))
                return (T) Application.Current.Properties[key];

            return default(T);
        }

        public void Set<T>(string key, T value) {
            Application.Current.Properties[key] = value;
        }
    }
}
