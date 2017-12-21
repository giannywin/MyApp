using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Services.API;

namespace MyApp.Services
{
    public class LoginService : ILoginService
    {
        public async Task<User> Login(string username, string password)
        {
            return await Task.Run(() => new User{Id = 1, Username = username, Password = password});
        }
    }
}
