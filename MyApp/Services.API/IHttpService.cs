using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Services.API
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> parameters, bool refreshToken = true);

        Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, object> queryParameters = null, bool refreshToken = true);

        string GetToken();

        void SetToken(string token);
    }
}
