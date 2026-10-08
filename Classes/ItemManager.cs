using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TabSplit.Classes
{
    public class ItemManager : INotifyPropertyChanged
    {
        public static ItemManager Instance { get; } = new ItemManager();
        private ObservableCollection<Item> _itemList = new ObservableCollection<Item>();

        public ObservableCollection<Item> itemList
        {
            get => _itemList;

            set
            {
                _itemList = value;
                OnPropertyChanged(nameof(itemList));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
