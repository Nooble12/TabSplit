using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
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
            Item item = new Item("Item Name", 0, 1);
            itemList.Add(item);
            person.AddItemToInventory(item);
        }

        private void ExitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CalculateTotalPrice price = new CalculateTotalPrice();
            person.totalPrice = price.GetTotalPrice(person.inventory, tipPercent, taxPercent);
            person.totalBasePrice = price.GetTotalBasePrice(person.inventory);

            personList.Add(person);

            this.NavigationService.GoBack();
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

        }

        private void ItemNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ItemPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ItemQuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
