using MyApp.Models;

namespace MyApp.Services.API
{
    public interface IAppSettingsService
    {
        AppSettings GetSettings();

        T Get<T>(string key);

        void Set<T>(string key, T value);
    }
}
