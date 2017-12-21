using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IAppSettingsService
    {
        Task AppSettings GetSettings();
    }
}
