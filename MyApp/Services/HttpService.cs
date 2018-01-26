using MyApp.Helpers;
using MyApp.Services.API;
using System.Threading.Tasks;
using System.Net.Http;
using MyApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using ModernHttpClient;
using System.Dynamic;
using Newtonsoft.Json.Converters;

namespace MyApp.Services
{
    public class HttpService: IHttpService
    {
        public HttpService(IAppSettingsService appSettingsService) {
            AppSettingsService = appSettingsService;
        }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        public async Task<T> PostAsync<T>(string url, Dictionary<string, string> parameters, bool refreshToken = true)
        {
            var response = await PostAsyncBase(url, parameters, refreshToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<dynamic> PostAsync(string url, Dictionary<string, string> parameters, bool refreshToken = true)
        {
            var response = await PostAsyncBase(url, parameters, refreshToken);

            var content = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject<ExpandoObject>(content, new ExpandoObjectConverter());

            return result;
        }

        private async Task<HttpResponseMessage> PostAsyncBase(string url, Dictionary<string, string> parameters, bool refreshToken) {
            var client = new HttpClient(new NativeMessageHandler());

            AddAuthorizationHeader(client);

            var formEncodedContent = new FormUrlEncodedContent(parameters ?? new Dictionary<string, string>());

            var response = await client.PostAsync(url, formEncodedContent);

            response.EnsureSuccessStatusCode();

            HandleRefreshToken(response, refreshToken);

            return response;
        }

        public async Task<T> GetAsync<T>(string url, Dictionary<string, object> queryParameters = null, bool refreshToken = true) {
            var client = new HttpClient(new NativeMessageHandler());

            var response = await GetAsyncBase(url, queryParameters, refreshToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<dynamic> GetAsync(string url, Dictionary<string, object> queryParameters = null, bool refreshToken = true)
        {
            var response = await GetAsyncBase(url, queryParameters, refreshToken);

            var content = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject<ExpandoObject>(content, new ExpandoObjectConverter());

            return result;
        }

        private async Task<HttpResponseMessage> GetAsyncBase(string url, Dictionary<string, object> queryParameters, bool refreshToken) {
            var client = new HttpClient(new NativeMessageHandler());

            AddAuthorizationHeader(client);

            if (queryParameters != null && queryParameters.Count > 0)
            {
                url += queryParameters.ToQueryString(url.Contains("?") ? "&" : "?");
            }

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

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
            var appSettings = AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);

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
            return AppSettingsService.Get<string>(MyAppConstants.Token);
        }

        public virtual void SetToken(string token) {
            AppSettingsService.Set(MyAppConstants.Token, token);
        }
    }
}
