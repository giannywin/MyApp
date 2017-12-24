using MyApp.Services.API;

namespace MyApp.Services
{
    public class DashboardService : BaseService, IDashboardService
    {
        public DashboardService(ICoreServiceDependencies coreServiceDependencies) : base(coreServiceDependencies)
        {
        }
    }
}
