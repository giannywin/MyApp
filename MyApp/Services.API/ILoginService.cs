using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Services.API
{
    public interface ILoginService
    {
        Task<User> Login(string username, string password);
    }
}
