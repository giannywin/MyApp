using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Models.Login;
using MyApp.Services.API;

namespace MyApp.Services
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(ICoreServiceDependencies coreServiceDependencies): base(coreServiceDependencies) {
        }

        public async Task<LoginResult> Login(string username, string password)
        {
            var appSettings = AppSettings;

            var tokenResponse = await HttpService.PostAsync<TokenResponse>($"{appSettings?.Api}/api/token",
                                                       new Dictionary<string, string> {{"username", username}, {"password", password}},
                                                       false);
            var loginResult = new LoginResult();

            HttpService.SetToken(tokenResponse.Access_Token);

            loginResult.User = await LoadLoginInfo(appSettings);

            if (loginResult.User == null) {
                loginResult.Error = "Login failed";
            }

            return loginResult;
        }

        public async Task<User> LoadLoginInfo(AppSettings appSettings) {
            var loginInfo = await HttpService.GetAsync<LoginInfo>($"{appSettings?.Api}/api/security/loadlogininfo");

            AppSettingsService.Set(MyAppConstants.CurrentUser, loginInfo.User);

            return loginInfo.User;
        }

        public async Task<SystemSettings> GetSystemSettings() {
            var appSettings = AppSettings;

            var systemSettings = await HttpService.GetAsync<SystemSettings>($"{appSettings?.Api}/api/portal/getportalsettings", null, false);

            AppSettingsService.Set(MyAppConstants.SystemSettings, systemSettings);

            return systemSettings;
        }
    }
}
