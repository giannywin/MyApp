using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Services
{
    public interface ILoginService
    {
        Task<User> Login(string username, string password);
    }
}
