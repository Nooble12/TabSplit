using System.ComponentModel;
using System.Diagnostics;

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
                    OnPropertyChanged(nameof(name));
                }
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
                    OnPropertyChanged(nameof(contactInfo));
                }
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
                    OnPropertyChanged(nameof(totalBasePrice));
                }
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
                    OnPropertyChanged(nameof(totalPrice));
                }
            }
        }

        public List<Item> inventory = new List<Item>();

        public Person(string inName, string inContactInfo)
        {
            _name = inName;
            _contactInfo = inContactInfo;
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
            totalPrice = price.GetTotalPrice(inventory, tipPercent, taxPercent);
            totalBasePrice = price.GetTotalBasePrice(inventory);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
