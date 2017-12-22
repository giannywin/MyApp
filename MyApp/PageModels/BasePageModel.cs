using System.ComponentModel;
using MyApp.Models;
using Xamarin.Forms;

namespace MyApp.PageModels
{
    public abstract class BasePageModel : FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        private AppSettings _appSettings;

        public virtual AppSettings AppSettings
        {
            get
            {
                if (_appSettings != null)
                {
                    return _appSettings;
                }

                _appSettings = Application.Current.Properties.ContainsKey(MyAppConstants.AppSettings)
                                         ? (AppSettings)Application.Current.Properties[MyAppConstants.AppSettings]
                                         : null;
                return _appSettings;
            }
            set
            {
                _appSettings = value;
            }
        }
    }
}
