namespace MyApp.Models.Widgets
{
    public class ListWidget : IWidget
    {
        public bool MobileLayout { get; set; }

        public string SelectedViewId { get; set; }

        public string Url { get; set; }

        public WidgetAction RowClickAction { get; set; }

        public WidgetAction[] OfflineActions { get; set; }

        public WidgetView[] Views { get; set; }
    }
}
