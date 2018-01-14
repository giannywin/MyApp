namespace MyApp.Models.Widgets
{
    public class WidgetView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WidgetProperty[] Properties { get; set; }

        public WidgetProperty  SubDetailProperty { get; set; }

        public WidgetProperty SubTitleProperty { get; set; }

        public WidgetProperty SummaryProperty { get; set; }

        public WidgetProperty TitleProperty { get; set; }

        public WidgetProperty DetailProperty { get; set; }

        public string DetailLabel { get; set; } = "DetailLabel";

        public string SubTitleLabel { get; set; } = "SubTitleLabel";
    }
}
