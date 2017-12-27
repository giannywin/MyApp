using System.Collections.Generic;
using MyApp.Models;
using MyApp.PageModels;
using Xamarin.Forms;
using FreshMvvm;

namespace MyApp.Pages
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public List<MenuItem> List { get; set; }

        protected override void OnBindingContextChanged()
        {
            var viewModel = BindingContext as MainPageModel;

            menu.ItemsSource = viewModel.MenuPageItems;

            var currentUser = viewModel.AppSettingsService.Get<User>(MyAppConstants.CurrentUser);

            loginName.Text = currentUser != null ? currentUser.FirstName + " " + currentUser.LastName: string.Empty;
        }

        public void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MenuPageItem) e.SelectedItem;
            var viewModel = BindingContext as MainPageModel;
            App.NavigationPage.PushAsync(FreshPageModelResolver.ResolvePageModel(item.PageType, (object) new User { FullName = item.Title }));
            IsPresented = false;
        }

    }
}
