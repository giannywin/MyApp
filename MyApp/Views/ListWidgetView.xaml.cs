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

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                                                  "Title", //Public name to use
                                                  typeof(string), //this type
                                                  typeof(ListWidgetView), //parent type (tihs control)
                                                  null); //default value

        public string Title {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
                                          "IsLoading", //Public name to use
                                          typeof(bool), //this type
                                          typeof(ListWidgetView), //parent type (tihs control)
                                          false); //default value

        public bool IsLoading
        {
            get { return (bool) GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
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
