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

                var result = vm.Get();
            }
        }

        protected internal virtual bool Loaded { get; set; }
    }
}
