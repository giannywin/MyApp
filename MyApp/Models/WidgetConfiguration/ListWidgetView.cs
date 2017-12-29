namespace MyApp.Models.WidgetConfiguration
{
    public class ListWidgetView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WidgetProperty[] Properties { get; set; }

        public WidgetProperty SubDetailProperty { get; set; }

        public WidgetProperty SubTitleProperty { get; set; }

        public WidgetProperty SummaryProperty { get; set; }

        public WidgetProperty TitleProperty { get; set; }
    }
}
