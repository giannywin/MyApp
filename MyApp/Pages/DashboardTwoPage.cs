using System;
using MyApp.Models.WidgetConfiguration;
using MyApp.PageModels;
using Xamarin.Forms;

namespace MyApp.Pages
{
    public class DashboardTwoPage : ContentPage
    {
        public DashboardTwoPage()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!Loaded)
            {
                Loaded = true;

                var vm = BindingContext as DashboardPageModel;

                var mainStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                var titleStackLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
                var welcomeLabel = new Label { Text = "Welcome" };
                titleStackLayout.Children.Add(welcomeLabel);

                var usernameLabel = new Label();
                usernameLabel.SetBinding(Label.TextProperty, "WidgetConfiguration.PageTitle");
                titleStackLayout.Children.Add(usernameLabel);

                mainStackLayout.Children.Add(titleStackLayout);

                InitWidgets(mainStackLayout, vm.WidgetConfiguration);

                Content = mainStackLayout;

                var result = vm.Get();
            }
        }

        protected virtual void InitWidgets(StackLayout stackLayout, WidgetConfiguration widgetConfiguration) {
            foreach(var tab in widgetConfiguration.Tabs) {
                foreach(var widget in tab.Widgets) {
                }
            }
        }

        protected internal virtual bool Loaded { get; set; }
    }
}

