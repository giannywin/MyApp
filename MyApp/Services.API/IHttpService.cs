using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Services.API
{
    public interface IHttpService
    {
        Task<T> PostAsync<T>(string url, Dictionary<string, string> parameters, bool refreshToken = true);

        Task<dynamic> PostAsync(string url, Dictionary<string, string> parameters, bool refreshToken = true);

        Task<T> GetAsync<T>(string url, Dictionary<string, object> queryParameters = null, bool refreshToken = true);

        Task<dynamic> GetAsync(string url, Dictionary<string, object> queryParameters = null, bool refreshToken = true);

        string GetToken();

        void SetToken(string token);
    }
}
