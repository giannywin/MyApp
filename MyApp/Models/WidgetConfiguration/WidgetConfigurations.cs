using System;
namespace MyApp.Models.WidgetConfiguration
{
    public static class WidgetConfigurations
    {
        public static WidgetConfiguration MyTasksWidgetConfiguration = new WidgetConfiguration
        {
            PageTitle = "My Tasks",
            ShowTabs = false,
            FullScreen = true,
            Tabs = new WidgetTab[] {
                new WidgetTab {
                    TabName = "My Tasks",
                    Widgets = new Widget[] {
                        new Widget {
                            ListId = "my-tasks-incomplete-config.json",
                            WidgetType = WidgetType.List,
                            Title = "MG-113",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "my-tasks-complete-config.json",
                            WidgetType = WidgetType.List,
                            Title = "MG-114",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        }
                    }
                }
            }
        };
    }
}
