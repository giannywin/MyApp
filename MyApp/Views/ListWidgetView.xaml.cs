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

        public static readonly BindableProperty DetailPropertyNameProperty = BindableProperty.Create(
                                                    "DetailPropertyName", //Public name to use
                                                    typeof(string), //this type
                                                    typeof(ListWidgetView), //parent type (tihs control)
                                                    null); //default value
        public string DetailPropertyName
        {
            get { return (string)GetValue(DetailPropertyNameProperty); }
            set { SetValue(DetailPropertyNameProperty, value); }
        }

        public static readonly BindableProperty DetailLabelPropertyNameProperty = BindableProperty.Create(
                                            "DetailLabelPropertyName", //Public name to use
                                            typeof(string), //this type
                                            typeof(ListWidgetView), //parent type (tihs control)
                                            null); //default value
        public string DetailLabelPropertyName
        {
            get { return (string)GetValue(DetailLabelPropertyNameProperty); }
            set { SetValue(DetailLabelPropertyNameProperty, value); }
        }

        public static readonly BindableProperty SubDetailPropertyNameProperty = BindableProperty.Create(
                                                    "SubDetailPropertyName", //Public name to use
                                                    typeof(string), //this type
                                                    typeof(ListWidgetView), //parent type (tihs control)
                                                    null); //default value
        public string SubDetailPropertyName
        {
            get { return (string)GetValue(SubDetailPropertyNameProperty); }
            set { SetValue(SubDetailPropertyNameProperty, value); }
        }

        public static readonly BindableProperty TitlePropertyNameProperty = BindableProperty.Create(
                                            "TitlePropertyName", //Public name to use
                                            typeof(string), //this type
                                            typeof(ListWidgetView), //parent type (tihs control)
                                            null); //default value
        public string TitlePropertyName
        {
            get { return (string)GetValue(TitlePropertyNameProperty); }
            set { SetValue(TitlePropertyNameProperty, value); }
        }

        public static readonly BindableProperty SubTitlePropertyNameProperty = BindableProperty.Create(
                                    "SubTitlePropertyName", //Public name to use
                                    typeof(string), //this type
                                    typeof(ListWidgetView), //parent type (tihs control)
                                    null); //default value
        public string SubTitlePropertyName
        {
            get { return (string)GetValue(SubTitlePropertyNameProperty); }
            set { SetValue(SubTitlePropertyNameProperty, value); }
        }

        public static readonly BindableProperty SubTitleLabelPropertyNameProperty = BindableProperty.Create(
                            "SubTitleLabelPropertyName", //Public name to use
                            typeof(string), //this type
                            typeof(ListWidgetView), //parent type (tihs control)
                            null); //default value
        public string SubTitleLabelPropertyName
        {
            get { return (string)GetValue(SubTitleLabelPropertyNameProperty); }
            set { SetValue(SubTitleLabelPropertyNameProperty, value); }
        }

        public static readonly BindableProperty SummaryPropertyNameProperty = BindableProperty.Create(
                            "SummaryPropertyName", //Public name to use
                            typeof(string), //this type
                            typeof(ListWidgetView), //parent type (tihs control)
                            null); //default value
        public string SummaryPropertyName
        {
            get { return (string)GetValue(SummaryPropertyNameProperty); }
            set { SetValue(SummaryPropertyNameProperty, value); }
        }
    }
}
