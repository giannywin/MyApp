using MyApp.Models;
using MyApp.Services.API;

namespace MyApp.PageModels
{
    public class MyTasksPageModel : DashboardPageModel
    {
        public MyTasksPageModel(ICoreServiceDependencies coreServiceDependencies,
                                IGenericService<PortalListRecord> portalService) :
        base(coreServiceDependencies, portalService)
        {
        }
    }
}
