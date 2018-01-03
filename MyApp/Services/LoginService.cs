using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Models.Login;
using MyApp.Services.API;
using Newtonsoft.Json;

namespace MyApp.Services
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(ICoreServiceDependencies coreServiceDependencies): base(coreServiceDependencies) {
        }

        public async Task<LoginResult> Login(string username, string password)
        {
            var appSettings = AppSettings;

            var response = await HttpService.PostAsync($"{appSettings?.Api}/api/token",
                                                       new Dictionary<string, string> {{"username", username}, {"password", password}},
                                                       false);

            var loginResult = new LoginResult();
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);

                HttpService.SetToken(tokenResponse.Access_Token);

                loginResult.User = await LoadLoginInfo(appSettings);
            }

            if (loginResult.User == null) {
                loginResult.Error = "Login failed";
            }

            return loginResult;
        }

        public async Task<User> LoadLoginInfo(AppSettings appSettings) {
            var response = await HttpService.GetAsync($"{appSettings?.Api}/api/security/loadlogininfo");

            User user = null;
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var loginInfo = JsonConvert.DeserializeObject<LoginInfo>(content);

                AppSettingsService.Set(MyAppConstants.CurrentUser, loginInfo.User);

                user = loginInfo.User;
            }
            return user;
        }

        public async Task<SystemSettings> GetSystemSettings() {
            var appSettings = AppSettings;

            var response = await HttpService.GetAsync($"{appSettings?.Api}/api/portal/getportalsettings", null, false);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var systemSettings = JsonConvert.DeserializeObject<SystemSettings>(content);

                AppSettingsService.Set(MyAppConstants.SystemSettings, systemSettings);

                return systemSettings;
            }

            return null;
        }
    }
}
