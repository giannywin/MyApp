using System;
namespace MyApp.Models.WidgetConfiguration
{
    public class MyTasksWidgetConfiguration : WidgetConfiguration
    {
        public MyTasksWidgetConfiguration()
        {
            PageTitle = "My Tasks";
            ShowTabs = false;
            FullScreen = true;
            Tabs = new WidgetTab[] {
                new WidgetTab {
                    TabName = "My Tasks",
                    Widgets = new Widget[] {
                        new Widget {
                            ListId = "my-tasks-incomplete-config.json",
                            WidgetType = WidgetType.List,
                            Title = "MG-113",
                            Collapsed = false
                        },
                        new Widget {
                            ListId = "my-tasks-complete-config.json",
                            WidgetType = WidgetType.List,
                            Title = "MG-114",
                            Collapsed = false
                        }
                    }
                }
            };
        }
    }
}
