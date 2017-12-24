using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Models.Login;

namespace MyApp.Services.API
{
    public interface ILoginService
    {
        Task<LoginResult> Login(string username, string password);

        Task<SystemSettings> GetSystemSettings();
    }
}
