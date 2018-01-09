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
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

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

            WidgetOptions = new NotifyObservableCollection<object>();
        }
         
        protected internal IHttpService HttpService { get; set; }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        protected internal IGenericService<PortalListRecord> PortalService { get; set; }

        public User User { get; set; }

        public AppSettings AppSettings { get; set; }

        private NotifyObservableCollection<object> _widgetOptions;
        public NotifyObservableCollection<object> WidgetOptions { 
            get {
                return _widgetOptions;
            }
            set {
                    NotifyCollectionChangedEventHandler cceh = (sender, args) => NotifyPropertyChanged();
                if (_widgetOptions != null) _widgetOptions.CollectionChanged -= cceh;
                _widgetOptions = value;
                _widgetOptions.CollectionChanged += cceh;
            }
        }

        public WidgetConfiguration WidgetConfiguration { get; set; }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            WidgetConfiguration = initData as WidgetConfiguration;
            User = new User { FullName = WidgetConfiguration.PageTitle };
            AppSettings = AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);

            WidgetOptions.Add(new WidgetOptions<PortalListRecord>
            {
                ListOptions = new ListOptions<PortalListRecord>
                {
                    IsLoading = false,
                    Loaded = false,
                    ListResults = new ListResult<PortalListRecord>(),
                    ListNavigateCommand = new Command<ListRecord<PortalListRecord>>(ListNavigate),
                    Title = "Incomplete"
                }
            });
            WidgetOptions.Add(new WidgetOptions<PortalListRecord>
            {
                ListOptions = new ListOptions<PortalListRecord>
                {
                    IsLoading = false,
                    Loaded = false,
                    ListResults = new ListResult<PortalListRecord>(),
                    ListNavigateCommand = new Command<ListRecord<PortalListRecord>>(ListNavigate),
                    Title = "Complete"
                }
            });
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
            if (WidgetOptions.Count == 0)
                return;

            foreach(var widgetOptions in WidgetOptions) {
                var widgetOptionsTemp = widgetOptions as WidgetOptions<PortalListRecord>;
                if (widgetOptionsTemp != null) {
                    var b = GetListResults(widgetOptionsTemp);
                }
            }
        }

        public async Task GetListResults<T>(WidgetOptions<T> widgetOptions) {
            if (!widgetOptions.ListOptions.IsLoading && !widgetOptions.ListOptions.Loaded)
            {
                widgetOptions.ListOptions.IsLoading = true;

                var service = FreshTinyIOCBuiltIn.Current.Resolve<IGenericService<T>>();

                widgetOptions.ListOptions.ListResults = await service.Get(new GetOptions
                {
                    Controller = "portal",
                    Action = "mytasks",
                    PageIndex = 1,
                    PageSize = 10,
                    ViewId = "1",
                    QueryParameters = new Dictionary<string, object>{
                        {"AssignedTo", 7},
                        {"status", 1}
                    }
                });

                widgetOptions.ListOptions.IsLoading = false;
                widgetOptions.ListOptions.Loaded = true;
            }
        }
    }
}
