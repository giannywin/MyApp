using System.Collections.Generic;

namespace MyApp.Models.Widgets
{
    public class WidgetAction
    {
        public string Action { get; set; }

        public Dictionary<string, object> Params { get; set; }
    }
}
