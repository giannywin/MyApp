using System.ComponentModel;
using System.Windows.Input;

namespace MyApp.Models.WidgetConfiguration
{
    public class ListOptions<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }

        bool _loaded;
        public bool Loaded
        {
            get
            {
                return _loaded;
            }
            set
            {
                if (_loaded != value)
                {
                    _loaded = value;
                    OnPropertyChanged("Loaded");
                }
            }
        }

        ICommand _listNavigateCommand;
        public ICommand ListNavigateCommand
        {
            get
            {
                return _listNavigateCommand;
            }
            set
            {
                if (_listNavigateCommand != value)
                {
                    _listNavigateCommand = value;
                    OnPropertyChanged("ListNavigateCommand");
                }
            }
        }

        private ListResult<T> _listResults;
        public ListResult<T> ListResults
        {
            get
            {
                return _listResults;
            }
            set
            {
                if (_listResults != value)
                {
                    _listResults = value;
                    OnPropertyChanged("ListResults");
                }
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
    }
}
