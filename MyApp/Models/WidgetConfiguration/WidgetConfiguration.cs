namespace MyApp.Models.WidgetConfiguration
{
    public class WidgetConfiguration
    {
        public virtual string PageTitle { get; set; }

        public virtual bool ShowTabs { get; set; }

        public virtual bool FullScreen { get; set; }

        public virtual WidgetAction FabAddButton { get; set; }

        public WidgetTab[] Tabs { get; set; }
    }
}
