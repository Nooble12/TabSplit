using System.ComponentModel;

namespace TabSplit.Classes
{
    public class Item : INotifyPropertyChanged
    {
        private int _quantity;
        private float _price;
        private string _name;
        VerifyInput checker = new VerifyInput();

        public int quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    if (checker.CheckIfNumber(value))
                    {
                        if (value > 0)
                        {
                            _quantity = value;
                        }
                    }
                }
                OnPropertyChanged(nameof(_quantity));
            }
        }

        public float price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    if (checker.CheckIfNumber(value))
                    {
                        if (value > 0)
                        {
                            _price = value;
                        }
                    }
                }
                OnPropertyChanged(nameof(_price));
            }
        }

        public string name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    if (checker.CheckInputStringLength(value))
                    {
                        _name = value;
                        Console.Write("Name has changed");
                      
                    }

                }
                OnPropertyChanged(nameof(_name));
            }
        }

        public Item(string inName, float inPrice, int inQuantity)
        {
            _name = inName;
            _price = inPrice;
            _quantity = inQuantity;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // TODO VERIFY QUANTITY, PRICE, NAME methods. Will be Used in AddPersonPage and Person.cs to verify states
    }
}
