using MyApp.Models;
using Xamarin.Forms;

namespace MyApp.Services
{
    public abstract class BaseService
    {
        protected internal virtual AppSettings AppSettings
        {
            get
            {
                return Application.Current.Properties.ContainsKey(MyAppConstants.AppSettings)
                                  ? (AppSettings)Application.Current.Properties[MyAppConstants.AppSettings]
                                  : null;
            }
        }

        protected internal virtual User CurrentUser
        {
            get
            {
                return Application.Current.Properties.ContainsKey(MyAppConstants.CurrentUser)
                                  ? (User)Application.Current.Properties[MyAppConstants.CurrentUser]
                                  : null;
            }
        }
    }
}
