using System.Threading.Tasks;
using MyApp.PageModels;
using Xamarin.Forms;

namespace MyApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Appearing += async (sender, args) => await GetSystemSettings();

            InitializeComponent();
        }

        protected internal async Task GetSystemSettings()
        {
            var viewModel = BindingContext as LoginPageModel;

            await viewModel.GetSystemSettings();
        }
    }
}
