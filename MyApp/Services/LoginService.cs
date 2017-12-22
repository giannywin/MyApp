using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Services.API;
using Newtonsoft.Json;

namespace MyApp.Services
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(ICoreServiceDependencies coreServiceDependencies) {
            HttpService = coreServiceDependencies.HttpService;
        }

        public IHttpService HttpService { get; set; }

        public async Task<User> Login(string username, string password)
        {
            var appSettings = AppSettings;

            var response = await HttpService.PostAsync($"{appSettings?.Api}/api/token",
                                                       new Dictionary<string, string> {{"username", username}, {"password", password}},
                                                       true);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);

                HttpService.SetToken(tokenResponse.Access_Token);
            }

            return await Task.Run(() => new User { Id = 1, Username = username, Password = password });
        }
    }
}
