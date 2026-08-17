using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using TabSplit.Classes;

namespace TabSplit
{
    /// <summary>
    /// Interaction logic for AddPersonPage.xaml
    /// </summary>
    public partial class AddPersonPage : Page
    {
        private ObservableCollection<Item> itemList { get; set; } = new ObservableCollection<Item>();

        private VerifyInput checker = new VerifyInput();

        private ObservableCollection<Person> personList;
        private Person person;
        private float tipPercent;
        private float taxPercent;
        public AddPersonPage(Person inPerson, ObservableCollection<Person> inPersonList, float inTipPercent, float inTaxPercent)
        {

            person = inPerson;
            personList = inPersonList;

            tipPercent = inTipPercent;
            taxPercent = inTaxPercent;

            InitializeComponent();
            ItemListBox.ItemsSource = itemList;
        }

        private void AddItemButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Item item = new Item("Enter Name", 0, 0);
            itemList.Add(item);
            person.AddItemToInventory(item);
        }

        private void ExitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (person.VerifyInventory())
            {
                person.CalculatePrice(tipPercent, taxPercent);
                personList.Add(person);

                this.NavigationService.GoBack();
            }
            else
            {
                ErrorTextBox.Text = "Error, Invalid field(s)";
            }
        }

        private void PersonNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            person.name = PersonNameTextBox.Text;
        }

        private void ContactTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            person.contactInfo = ContactTextBox.Text;
        }

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var instance = button.DataContext;
                switch (instance)
                {
                    case Item item:
                        itemList.Remove(item);
                        person.RemoveItemFromInventory(item);
                        break;
                }
            }
        }

        private void ItemNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (sender is TextBox nameTextBox)
           {
               if (checker.CheckInputStringLength(nameTextBox.Text))
                {
                    nameTextBox.Background = Brushes.White;
                }
                else
                {
                    nameTextBox.Background = Brushes.Red;
                }
           }
        }

        private void ItemPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox itemPriceTextBox)
            {
                if (checker.CheckIfParseToNumber(itemPriceTextBox.Text))
                {
                    itemPriceTextBox.Background = Brushes.White;
                }
                else
                {
                    itemPriceTextBox.Background = Brushes.Red;
                    
                }
            }
        }

        private void ItemQuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox itemQuantity)
            {
                if (checker.CheckIfParseToInt(itemQuantity.Text))
                {
                    itemQuantity.Background = Brushes.White;
                }
                else
                {
                    itemQuantity.Background = Brushes.Red;
                }
            }
        }
    }
}
