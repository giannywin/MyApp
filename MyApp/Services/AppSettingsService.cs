using MyApp.Models;
using MyApp.Services.API;
using Newtonsoft.Json;

namespace MyApp.Services
{
    public class AppSettingService : IAppSettingsService
    {
        public AppSettingService(ICoreServiceDependencies coreServiceDependencies)
        {
            FileStorage = coreServiceDependencies.FileStorage;
        }

        protected internal IFileStorage FileStorage { get; set; }

        public AppSettings GetSettings()
        {
            var json = FileStorage.ReadAsString(MyAppConstants.AppSettingsFilename);

            var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);

            return appSettings;
        }
    }
}
