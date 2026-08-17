using System.ComponentModel;
using System.Diagnostics;
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

        public void RemoveItemFromInventory(Item inItem)
        {
            inventory.Remove(inItem);
        }

        public bool VerifyInventory()
        {
            VerifyInput input = new VerifyInput();

            foreach (Item item in inventory)
            {
                Debug.Write(item.name);

                if (!input.CheckIfNumber(item.price) || !input.CheckIfNumber(item.quantity))
                {
                    return false;
                }

                if (item.price <= 0 || item.name.Length <= 0 || item.quantity <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void CalculatePrice(float tipPercent, float taxPercent)
        {
            CalculateTotalPrice price = new CalculateTotalPrice();
            _totalPrice = price.GetTotalPrice(inventory, tipPercent, taxPercent);
            _totalBasePrice = price.GetTotalBasePrice(inventory);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
