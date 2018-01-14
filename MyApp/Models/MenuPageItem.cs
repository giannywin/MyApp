using System;
using MyApp.Models.Widgets;

namespace MyApp.Models
{
    public class MenuPageItem
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public Type PageType { get; set; }

        public WidgetConfiguration WidgetConfiguration { get; set; }
    }
}
