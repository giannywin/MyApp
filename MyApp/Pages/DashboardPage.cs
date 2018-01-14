using MyApp.Models.Widgets;
using MyApp.PageModels;
using MyApp.Views;
using Xamarin.Forms;

namespace MyApp.Pages
{
    public class DashboardPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!Loaded)
            {
                Loaded = true;

                var vm = BindingContext as DashboardPageModel;

                var mainStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical
                };

                var titleStackLayout = new StackLayout { Orientation = StackOrientation.Horizontal };

                var titleLabel = new Label();
                titleLabel.SetBinding(Label.TextProperty, "WidgetConfiguration.PageTitle");

                titleStackLayout.Children.Add(titleLabel);

                mainStackLayout.Children.Add(titleStackLayout);

                RenderWidgets(mainStackLayout, vm.WidgetConfiguration);

                Content = mainStackLayout;

                var result = vm.LoadWidgets();
            }
        }

        protected internal virtual void RenderWidgets(StackLayout stackLayout, WidgetConfiguration widgetConfiguration) {
            var tab = widgetConfiguration.Tabs.Length > 0 ? widgetConfiguration.Tabs[0] : null;
            if (tab != null) {
                for (var i = 0; i < tab.Widgets.Length; ++i) {
                    var widget = tab.Widgets[i];

                    switch(widget.WidgetType) {
                        case WidgetType.List:
                            RenderListWidget(stackLayout, widget, i);
                            break;
                        case WidgetType.Form:
                            break;
                    }
                }
            }
        }

        protected internal virtual void RenderListWidget(StackLayout stackLayout, Widget widget, int index) {
            var listWidget = new ListWidgetView();
            listWidget.SetBinding(ListWidgetView.ListResultProperty, $"WidgetOptions[{index}].ListOptions.ListResults");
            listWidget.SetBinding(ListWidgetView.TitleProperty, $"WidgetOptions[{index}].ListOptions.Title");
            listWidget.SetBinding(ListWidgetView.IsLoadingProperty, $"WidgetOptions[{index}].ListOptions.IsLoading");
            listWidget.SetBinding(ListWidgetView.HandleItemSelectedProperty, $"WidgetOptions[{index}].ListOptions.ListNavigateCommand");
            listWidget.SetBinding(ListWidgetView.DetailPropertyNameProperty, $"WidgetOptions[{index}].ListOptions.Views[0].DetailProperty.PropertyName");
            listWidget.SetBinding(ListWidgetView.SubDetailPropertyNameProperty, $"WidgetOptions[{index}].ListOptions.Views[0].SubDetailProperty.PropertyName");
            listWidget.SetBinding(ListWidgetView.TitlePropertyNameProperty, $"WidgetOptions[{index}].ListOptions.Views[0].TitleProperty.PropertyName");
            listWidget.SetBinding(ListWidgetView.SummaryPropertyNameProperty, $"WidgetOptions[{index}].ListOptions.Views[0].SummaryProperty.PropertyName");
            listWidget.SetBinding(ListWidgetView.SubTitlePropertyNameProperty, $"WidgetOptions[{index}].ListOptions.Views[0].SubTitleProperty.PropertyName");
            listWidget.SetBinding(ListWidgetView.DetailLabelPropertyNameProperty, $"WidgetOptions[{index}].ListOptions.Views[0].DetailLabel");
            listWidget.SetBinding(ListWidgetView.SubTitleLabelPropertyNameProperty, $"WidgetOptions[{index}].ListOptions.Views[0].SubTitleLabel");
            stackLayout.Children.Add(listWidget);
        }

        protected internal virtual bool Loaded { get; set; }
    }
}

