using System.Collections.Generic;

namespace MyApp.Models.WidgetConfiguration
{
    public class WidgetAction
    {
        public string Action { get; set; }

        public Dictionary<string, object> Params { get; set; }
    }
}
