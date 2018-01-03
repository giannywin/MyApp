using MyApp.Services.API;

namespace MyApp.Services
{
    public class GenericService<T> : AbstractService<T>, IGenericService<T>
    {
        public GenericService(ICoreServiceDependencies coreServiceDependencies)
            : base(coreServiceDependencies)
        {
        }
    }
}
