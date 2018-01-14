using System;

namespace MyApp.Models.Widgets
{
    public class Widget
    {
        public string ListId { get; set; }

        public WidgetType WidgetType { get; set; }

        public string Title { get; set; }

        public bool Collapsed { get; set; }

        public Type ListType { get; set; }
    }
}
