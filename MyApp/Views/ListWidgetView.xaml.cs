using System.Windows.Input;
using MyApp.Models;
using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class ListWidgetView : ContentView
    {
        public ListWidgetView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ListResultProperty = BindableProperty.Create(
                                                          "ListResult", //Public name to use
                                                          typeof(ListResult<PortalListRecord>), //this type
                                                          typeof(ListWidgetView), //parent type (tihs control)
                                                          null); //default value
        public ListResult<PortalListRecord> ListResult
        {
            get { return (ListResult<PortalListRecord>)GetValue(ListResultProperty); }
            set { SetValue(ListResultProperty, value); }
        }

        public static readonly BindableProperty HandleItemSelectedProperty = BindableProperty.Create(
                                                  "HandleItemSelected", //Public name to use
                                                  typeof(ICommand), //this type
                                                  typeof(ListWidgetView), //parent type (tihs control)
                                                  null); //default value
        public ICommand HandleItemSelected
        {
            get { return (ICommand)GetValue(HandleItemSelectedProperty); }
            set { SetValue(HandleItemSelectedProperty, value); }
        }
    }
}
