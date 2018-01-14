using System.ComponentModel;
using System.Windows.Input;

namespace MyApp.Models.Widgets
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

        bool _initialized;
        public bool Initialized
        {
            get
            {
                return _initialized;
            }
            set
            {
                if (_initialized != value)
                {
                    _initialized = value;
                    OnPropertyChanged("Initialized");
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

        private bool _mobileLayout;
        public bool MobileLayout
        {
            get
            {
                return _mobileLayout;
            }
            set
            {
                if (_mobileLayout != value)
                {
                    _mobileLayout = value;
                    OnPropertyChanged("MobileLayout");
                }
            }
        }

        private string _selectedViewId;
        public string SelectedViewId
        {
            get
            {
                return _selectedViewId;
            }
            set
            {
                if (_selectedViewId != value)
                {
                    _selectedViewId = value;
                    OnPropertyChanged("SelectedViewId");
                }
            }
        }

        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    OnPropertyChanged("Url");
                }
            }
        }

        private WidgetAction _rowClickAction;
        public WidgetAction RowClickAction
        {
            get
            {
                return _rowClickAction;
            }
            set
            {
                if (_rowClickAction != value)
                {
                    _rowClickAction = value;
                    OnPropertyChanged("RowClickAction");
                }
            }
        }

        private WidgetAction[] _offlineActions;
        public WidgetAction[] OfflineActions
        {
            get
            {
                return _offlineActions;
            }
            set
            {
                if (_offlineActions != value)
                {
                    _offlineActions = value;
                    OnPropertyChanged("OfflineActions");
                }
            }
        }

        private WidgetView[] _views;
        public WidgetView[] Views
        {
            get
            {
                return _views;
            }
            set
            {
                if (_views != value)
                {
                    _views = value;
                    OnPropertyChanged("Views");
                }
            }
        }
    }
}
