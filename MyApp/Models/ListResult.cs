using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp.Models
{
    public class ListResult<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }

        int[] _recordsIds;
        public int[] RecordIds {
            get {
                return _recordsIds;
            } 
            set {
                if (_recordsIds != value) {
                    _recordsIds = value;
                    NotifyPropertyChanged("RecordIds");
                }
            }
        }

        int _totalCount;
        public int TotalCount {
            get
            {
                return _totalCount;
            }
            set
            {
                if (_totalCount != value)
                {
                    _totalCount = value;
                    NotifyPropertyChanged("TotalCount");
                }
            }
        }

        int _secondaryCount;
        public int SecondaryCount {
            get
            {
                return _secondaryCount;
            }
            set
            {
                if (_secondaryCount != value)
                {
                    _secondaryCount = value;
                    NotifyPropertyChanged("SecondaryCount");
                }
            }
        }

        ListRecord<T>[] _records;
        public ListRecord<T>[] Records {
            get
            {
                return _records;
            }
            set
            {
                if (_records != value)
                {
                    _records = value;
                    NotifyPropertyChanged("Records");
                }
            }
        }
    }
}
