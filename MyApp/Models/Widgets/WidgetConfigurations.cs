namespace MyApp.Models.Widgets
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
                            Title = "Incomplete",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "my-tasks-complete-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Complete",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        }
                    }
                }
            }
        };

        public static WidgetConfiguration EventReportsWidgetConfiguration = new WidgetConfiguration
        {
            PageTitle = "Event Reports",
            ShowTabs = false,
            FullScreen = true,
            Tabs = new WidgetTab[] {
                new WidgetTab {
                    TabName = "Event Reports",
                    Widgets = new Widget[] {
                        new Widget {
                            ListId = "event-report-progress-config.json",
                            WidgetType = WidgetType.List,
                            Title = "In Progress",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "event-report-submitted-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Previously Submitted",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        }
                    }
                }
            }
        };

        public static WidgetConfiguration MyRecordsWidgetConfiguration = new WidgetConfiguration
        {
            PageTitle = "My Records",
            ShowTabs = false,
            FullScreen = true,
            Tabs = new WidgetTab[] {
                new WidgetTab {
                    TabName = "My Records",
                    Widgets = new Widget[] {
                        new Widget {
                            ListId = "allergies-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Allergies",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "medications-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Medications",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "immunizations-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Immunizations",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "clinic-visits-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Appointments",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "indicators-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Indicators",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        },
                        new Widget {
                            ListId = "clinical-test-config.json",
                            WidgetType = WidgetType.List,
                            Title = "Lab Results",
                            Collapsed = false,
                            ListType = typeof(PortalListRecord)
                        }
                    }
                }
            }
        };
    }
}
