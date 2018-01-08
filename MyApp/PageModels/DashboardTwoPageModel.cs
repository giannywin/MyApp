using MyApp.Models;
using MyApp.Services.API;

namespace MyApp.PageModels
{
    public class DashboardTwoPageModel : DashboardPageModel
    {
        public DashboardTwoPageModel(ICoreServiceDependencies coreServiceDependencies,
                                IGenericService<PortalListRecord> portalService) :
        base(coreServiceDependencies, portalService)
        {
        }
    }
}
