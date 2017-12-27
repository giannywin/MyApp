using MyApp.PageModels;
using Xamarin.Forms;

namespace MyApp.Pages
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            if (!Loaded)
            {
                Loaded = true;

                var vm = BindingContext as DashboardPageModel;
            }
        }

        private bool Loaded { get; set; }
    }
}
