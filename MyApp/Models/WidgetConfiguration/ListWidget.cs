namespace MyApp.Models.WidgetConfiguration
{
    public class ListWidget : IWidget
    {
        public bool MobileLayout { get; set; }

        public string SelectedViewId { get; set; }

        public string Url { get; set; }

        public WidgetAction RowClickAction { get; set; }

        public WidgetAction[] OfflineActions { get; set; }

        public ListWidgetView[] Views { get; set; }
    }
}
