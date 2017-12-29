namespace MyApp.Models.WidgetConfiguration
{
    public class WidgetConfiguration
    {
        public string PageTitle { get; set; }

        public bool ShowTabs { get; set; }

        public bool FullScreen { get; set; }

        public WidgetAction FabAddButton { get; set; }

        public WidgetTab[] Tabs { get; set; }
    }
}
