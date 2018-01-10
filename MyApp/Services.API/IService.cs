using MyApp.Models;
using System.Threading.Tasks;
using MyApp.Models.WidgetConfiguration;

namespace MyApp.Services.API
{
    public interface IService<T>
    {
        Task<ListResult<T>> Get(GetOptions options);

        Task<ListOptions<T>> ListOptions(Widget widget);
    }
}
