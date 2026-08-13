using System.ComponentModel;
using System.Windows.Controls;

namespace TabSplit.Classes
{
    public class Person : INotifyPropertyChanged
    {

        private string _name;
        private string _contactInfo;
        private float _totalBasePrice;
        private float _totalPrice;

        public string name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
                OnPropertyChanged(nameof(_name));
            }
        }

        public string contactInfo
        {
            get => _contactInfo;
            set
            {
                if (_contactInfo != value)
                {
                    _contactInfo = value;
                }
                OnPropertyChanged(nameof(_contactInfo));
            }
        }
        public float totalBasePrice
        {
            get => _totalBasePrice;
            set
            {
                if (_totalBasePrice != value)
                {
                    _totalBasePrice = value;
                }
                OnPropertyChanged(nameof(_totalBasePrice));
            }
        }

        public float totalPrice
        {
            get => _totalPrice;
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                }
                OnPropertyChanged(nameof(_totalPrice));
            }
        }

        public List<Item> inventory = new List<Item>();

        public Person(string inName)
        {
            _name = inName;
        }

        public void AddItemToInventory(Item inItem)
        {
            inventory.Add(inItem);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
