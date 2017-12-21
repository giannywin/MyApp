using MyApp.Services.API;

namespace MyApp.Services
{
    public class CoreServiceDependencies : ICoreServiceDependencies
    {
        public CoreServiceDependencies(IFileStorage fileStorage)
        {
            FileStorage = fileStorage;
        }

        public IFileStorage FileStorage { get; set; }
    }
}
