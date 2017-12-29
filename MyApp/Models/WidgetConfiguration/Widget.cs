namespace MyApp.Models.WidgetConfiguration
{
    public class Widget
    {
        public string ListId { get; set; }

        public WidgetType WidgetType { get; set; }

        public string Title { get; set; }

        public bool Collapsed { get; set; }
    }
}
