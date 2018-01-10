using MyApp.Models;
using MyApp.Models.WidgetConfiguration;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using MyApp.Services.API;
using Xamarin.Forms;
using FreshMvvm;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using MyApp.Helpers;
using System;
using System.Linq;

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

            InitWidgets();
        }

        public void InitWidgets() {
            var widgets = WidgetConfiguration?.Tabs?[0]?.Widgets;
            if (widgets != null) {
                for (var i = 0; i < widgets.Length; ++i) {
                    var widget = widgets[i];

                    switch(widget.WidgetType) {
                        case WidgetType.List:
                            InitListWidget(widget);
                            break;
                        case WidgetType.Form:
                            break;
                    }
                }
            }
        }

        private void InitListWidget(Widget widget) {
            var type = widget.ListType ?? ModelUtils.ResolveType(widget.ListId);

            var widgetOptionsType = typeof(WidgetOptions<>).MakeGenericType(type);
            var listOptionsType = typeof(ListOptions<>).MakeGenericType(type);
            var listResultType = typeof(ListResult<>).MakeGenericType(type);
            var listRecordType = typeof(ListRecord<>).MakeGenericType(type);
            var listNavigateCommandType = typeof(Command<>).MakeGenericType(listRecordType);

            var widgetOptions = Activator.CreateInstance(widgetOptionsType);
            var listOptions = Activator.CreateInstance(listOptionsType);
            var listResults = Activator.CreateInstance(listResultType);

            var listOptionsIsLoadingProperty = listOptionsType.GetTypeInfo().GetDeclaredProperty("IsLoading");
            listOptionsIsLoadingProperty?.SetValue(listOptions, false);

            var listOptionsLoadedProperty = listOptionsType.GetTypeInfo().GetDeclaredProperty("Loaded");
            listOptionsLoadedProperty?.SetValue(listOptions, false);

            var listOptionsListResultsProperty = listOptionsType.GetTypeInfo().GetDeclaredProperty("ListResults");
            listOptionsListResultsProperty?.SetValue(listOptions, listResults);

            var widgetOptionslistOptionsProperty = widgetOptionsType.GetTypeInfo().GetDeclaredProperty("ListOptions");
            widgetOptionslistOptionsProperty?.SetValue(widgetOptions, listOptions);

            WidgetOptions.Add(widgetOptions);
        }

        public async Task LoadWidgets() {
            var widgets = WidgetConfiguration?.Tabs?[0]?.Widgets;
            if (widgets != null)
            {
                for (var i = 0; i < widgets.Length; ++i)
                {
                    var widget = widgets[i];

                    switch (widget.WidgetType)
                    {
                        case WidgetType.List:
                            LoadListWidget(widget, i);
                            break;
                        case WidgetType.Form:
                            break;
                    }
                }
            }
        }

        private void LoadListWidget(Widget widget, int index) {
            var type = widget.ListType ?? ModelUtils.ResolveType(widget.ListId);

            var getListOptionsMethod = GetType().GetTypeInfo().DeclaredMethods.FirstOrDefault(s => s.Name == "GetListOptions");
            var genericGetListOptionsMethod = getListOptionsMethod.MakeGenericMethod(type);

            var widgetOptionsType = typeof(WidgetOptions<>).MakeGenericType(type);
            var listOptionsType = typeof(ListOptions<>).MakeGenericType(type);
            var listResultType = typeof(ListResult<>).MakeGenericType(type);
            var listRecordType = typeof(ListRecord<>).MakeGenericType(type);
            var listNavigateCommandType = typeof(Command<>).MakeGenericType(listRecordType);

            var widgetOptions = Activator.CreateInstance(widgetOptionsType);
            var listOptions = Activator.CreateInstance(listOptionsType);
            var listResults = Activator.CreateInstance(listResultType);

            var listOptionsIsLoadingProperty = listOptionsType.GetTypeInfo().GetDeclaredProperty("IsLoading");
            listOptionsIsLoadingProperty?.SetValue(listOptions, false);

            var listOptionsLoadedProperty = listOptionsType.GetTypeInfo().GetDeclaredProperty("Loaded");
            listOptionsLoadedProperty?.SetValue(listOptions, false);

            var listOptionsListResultsProperty = listOptionsType.GetTypeInfo().GetDeclaredProperty("ListResults");
            listOptionsListResultsProperty?.SetValue(listOptions, listResults);

            var widgetOptionslistOptionsProperty = widgetOptionsType.GetTypeInfo().GetDeclaredProperty("ListOptions");
            widgetOptionslistOptionsProperty?.SetValue(widgetOptions, listOptions);

            WidgetOptions.Add(widgetOptions);

            var result = genericGetListOptionsMethod.Invoke(this, new object[] { widget, index });
        }

        public void ListNavigate<T>(ListRecord<T> record)
        {
            App.NavigationPage.PushAsync(FreshPageModelResolver.ResolvePageModel<MainTabPageModel>());
        }

        public async Task GetListOptions<T>(Widget widget, int index) {
            var widgetOptions = WidgetOptions[index] as WidgetOptions<T>;
            if (!widgetOptions.ListOptions.IsLoading && !widgetOptions.ListOptions.Initialized) {
                widgetOptions.ListOptions.IsLoading = true;

                widgetOptions.ListOptions.IsLoading = true;

                var service = FreshTinyIOCBuiltIn.Current.Resolve<IGenericService<T>>();

                widgetOptions.ListOptions = await service.ListOptions(widget);
                widgetOptions.ListOptions.IsLoading = true;
                widgetOptions.ListOptions.Initialized = true;
                widgetOptions.ListOptions.ListNavigateCommand = new Command<ListRecord<T>>(ListNavigate);
                widgetOptions.ListOptions.Title = widget.Title;

                WidgetOptions[index] = widgetOptions;

                var result = GetListResults(widgetOptions, index);
            }
        }

        public async Task GetListResults<T>(WidgetOptions<T> widgetOptions, int index) {
            if (widgetOptions.ListOptions.Initialized && !widgetOptions.ListOptions.Loaded)
            {
                widgetOptions.ListOptions.IsLoading = true;

                var service = FreshTinyIOCBuiltIn.Current.Resolve<IGenericService<T>>();
                 
                widgetOptions.ListOptions.ListResults = await service.Get(new GetOptions
                {
                    Url = widgetOptions.ListOptions.Url,
                    PageIndex = 1,
                    PageSize = 10,
                    ViewId = widgetOptions.ListOptions.SelectedViewId,
                    QueryParameters = new Dictionary<string, object>{
                        {"AssignedTo", 7}
                    }
                });

                widgetOptions.ListOptions.IsLoading = false;
                widgetOptions.ListOptions.Loaded = true;

                WidgetOptions[index] = widgetOptions;
            }
        }
    }
}
