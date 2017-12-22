using MyApp.Services.API;
using System.Threading.Tasks;
using System.Net.Http;
using MyApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyApp.Services
{
    public class HttpService : BaseService, IHttpService
    {

        public async Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> parameters, bool refreshToken = true)
        {
            var client = new HttpClient();

            AddAuthorizationHeader(client);

            var formEncodedContent = new FormUrlEncodedContent(parameters ?? new Dictionary<string, string>());

            var response = await client.PostAsync(url, formEncodedContent);

            HandleRefreshToken(response, refreshToken);

            return response;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, bool refreshToken = true) {
            var client = new HttpClient();

            AddAuthorizationHeader(client);

            var response = await client.GetAsync(url);

            HandleRefreshToken(response, refreshToken);

            return response;
        }

        protected internal void AddAuthorizationHeader(HttpClient client) {
            var token = GetToken();

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        protected internal void HandleRefreshToken(HttpResponseMessage result, bool refreshToken) {
            if (refreshToken && result.IsSuccessStatusCode)
            {
                var refresh = RefreshToken();
            }
        }

        protected internal async Task RefreshToken() {
            var appSettings = AppSettings;

            var token = GetToken();

            if (!string.IsNullOrEmpty(token))
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.PostAsync($"{appSettings?.Api}/api/refresh-token", new FormUrlEncodedContent(new Dictionary<string, string>()));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);

                    SetToken(tokenResponse.Access_Token);
                }
            }
        }

        public virtual string GetToken() {
            return Application.Current.Properties.ContainsKey(MyAppConstants.Token)
                                    ? Application.Current.Properties[MyAppConstants.Token] as string
                                    : null;
        }

        public virtual void SetToken(string token) {
            Application.Current.Properties[MyAppConstants.Token] = token;
        }
    }
}
