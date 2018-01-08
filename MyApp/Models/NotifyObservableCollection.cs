using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MyApp.Models
{
    public class NotifyObservableCollection<T> : ObservableCollection<T>
    {
        #region Constructors

        public NotifyObservableCollection() : base()
        {
            CollectionChanged += ObservableCollection_CollectionChanged;
        }

        public NotifyObservableCollection(IEnumerable<T> c) : base(c)
        {
            CollectionChanged += ObservableCollection_CollectionChanged;
        }

        public NotifyObservableCollection(List<T> l) : base(l)
        {
            CollectionChanged += ObservableCollection_CollectionChanged;
        }

        #endregion

        public new void Clear()
        {
            foreach (var item in this)
            {
                if (item is INotifyPropertyChanged i)
                {
                    if (i != null)
                        i.PropertyChanged -= Element_PropertyChanged;
                }
            }
            base.Clear();
        }

        private void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                foreach (var item in e.OldItems)
                {
                    if (item != null && item is INotifyPropertyChanged i)
                    {
                        i.PropertyChanged -= Element_PropertyChanged;
                    }
                }
            if (e.NewItems != null)
                foreach (var item in e.NewItems)
                {
                    if (item != null && item is INotifyPropertyChanged i)
                    {
                        i.PropertyChanged -= Element_PropertyChanged;
                        i.PropertyChanged += Element_PropertyChanged;
                    }
                }
        }

        private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(sender, e);
        }

        public PropertyChangedEventHandler ItemPropertyChanged;
    }
}
