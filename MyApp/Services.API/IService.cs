using MyApp.Models;
using System.Threading.Tasks;

namespace MyApp.Services.API
{
    public interface IService<T>
    {
        Task<ListResult<T>> Get(GetOptions options);
    }
}
