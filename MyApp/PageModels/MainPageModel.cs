using System.Collections.Generic;
using System.ComponentModel;
using MyApp.Models;
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
                MenuPageItems.Add(new MenuPageItem { Title = "My Tasks", Icon = "my_tasks.png", PageType = typeof(DashboardPageModel) });
            }

            if (!systemSettings.PortalDisableMyRecords)
            {
                MenuPageItems.Add(new MenuPageItem { Title = "My Records", Icon = "medical_records.png", PageType = typeof(DashboardPageModel) });
            }

            if (!systemSettings.PortalDisableIncidents)
            {
                MenuPageItems.Add(new MenuPageItem { Title = "Event Reports", Icon = "event_reports.png", PageType = typeof(DashboardPageModel) });
            }

            MenuPageItems.Add(new MenuPageItem { Title = "Offline", Icon = "offline.png", PageType = typeof(DashboardPageModel) });
        }
    }
}
