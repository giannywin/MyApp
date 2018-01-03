using MyApp.Models;
using MyApp.Models.WidgetConfiguration;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Services.API;
using Newtonsoft.Json;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;

namespace MyApp.PageModels
{
    public class DashboardPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public DashboardPageModel(ICoreServiceDependencies coreServiceDependencies,
                                  IGenericService<PortalListRecord> portalService)
        {
            HttpService = coreServiceDependencies.HttpService;
            AppSettingsService = coreServiceDependencies.AppSettingsService;
            PortalService = portalService;

            ListNavigateCommand = new Command<ListRecord<PortalListRecord>>(ListNavigate);
        }
         
        protected internal IHttpService HttpService { get; set; }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        protected internal IGenericService<PortalListRecord> PortalService { get; set; }

        public User User { get; set; }

        public AppSettings AppSettings { get; set; }

        public ListResult<PortalListRecord> ListResult { get; set; } = new ListResult<PortalListRecord>();

        public string ListTitle { get; set; }

        public ICommand ListNavigateCommand { get; set; }

        public bool IsLoading { get; set; }

        public bool IsLoaded { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            User = initData as User;
            AppSettings = AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);

            ListTitle = "Incomplete";
        }

        public void ListNavigate(ListRecord<PortalListRecord> record)
        {
            App.NavigationPage.PushAsync(FreshPageModelResolver.ResolvePageModel<MainTabPageModel>());
        }

        public async Task<ListWidget> GetListWidget() {

            var appSettings = AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);
            var response = await HttpService.GetAsync($"{appSettings?.Api}/assets/json/list-configs/my-tasks-incomplete-config.json");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listWidget = JsonConvert.DeserializeObject<ListWidget>(content);

                return listWidget;
            }
            return null;
        }

        public async Task Get()
        {
            if (!IsLoaded) {
                IsLoading = true;
                
                ListResult = await PortalService.Get(new GetOptions{
                    Controller = "portal",
                    Action = "mytasks",
                    PageIndex = 1,
                    PageSize = 10,
                    ViewId = "1",
                    QueryParameters = new Dictionary<string, object>{
                        {"AssignedTo", 7},
                        {"status", 1}
                    }});

                IsLoading = false;
            }
        }
    }
}
