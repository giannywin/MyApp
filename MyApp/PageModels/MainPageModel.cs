using System.Collections.Generic;
using System.ComponentModel;
using MyApp.Models;
using MyApp.Models.Widgets;
using MyApp.Services.API;
using FreshMvvm;

namespace MyApp.PageModels
{
    public class MainPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public MainPageModel(IAppSettingsService appSettingsService)
        {
            AppSettingsService = appSettingsService;
        }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        public List<MenuPageItem> MenuPageItems { get; set; } = new List<MenuPageItem>();

        public override void Init(object initData)
        {
            base.Init(initData);

            var systemSettings = AppSettingsService.Get<SystemSettings>(MyAppConstants.SystemSettings);

            if (!systemSettings.PortalDisableMyWork)
            {
                MenuPageItems.Add(new MenuPageItem { Title = "My Tasks", Icon = "menu_1.png", PageType = typeof(DashboardPageModel), WidgetConfiguration = WidgetConfigurations.MyTasksWidgetConfiguration });
            }

            if (!systemSettings.PortalDisableMyRecords)
            {
                MenuPageItems.Add(new MenuPageItem { Title = "My Records", Icon = "menu_2.png", PageType = typeof(MainTabPageModel), WidgetConfiguration = WidgetConfigurations.MyTasksWidgetConfiguration });
            }

            if (!systemSettings.PortalDisableIncidents)
            {
                MenuPageItems.Add(new MenuPageItem { Title = "Event Reports", Icon = "menu_3.png", PageType = typeof(DashboardPageModel), WidgetConfiguration = WidgetConfigurations.EventReportsWidgetConfiguration });
            }

            MenuPageItems.Add(new MenuPageItem { Title = "Offline", Icon = "menu_4.png", PageType = typeof(DashboardPageModel), WidgetConfiguration = WidgetConfigurations.MyTasksWidgetConfiguration });
        }
    }
}
