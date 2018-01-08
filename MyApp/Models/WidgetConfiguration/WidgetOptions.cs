using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace MyApp.Models.WidgetConfiguration
{
    public class WidgetOptions<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ListOptions<T> _listOptions;
        public ListOptions<T> ListOptions
        {
            get
            {
                return _listOptions;
            }
            set
            {
                if (_listOptions != value)
                {
                    _listOptions = value;
                    OnPropertyChanged("ListOptions");
                }
            }
        }
    }
}
