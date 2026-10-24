using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TabSplit.Classes;
using TabSplit.Pages;

namespace TabSplit
{
    /// <summary>
    /// Interaction logic for AddPersonPage.xaml
    /// </summary>
    public partial class AddPersonPage : Page
    {
        private ObservableCollection<Item> itemList { get; set; } = new ObservableCollection<Item>();
        private ObservableCollection<Item> ItemCatalog { get; set; }

        private Fees fees;

        private VerifyInput checker = new VerifyInput();
        private static readonly Regex _inputRegex = new Regex("^[0-9./\b]+$"); // WIP new Regex("^[0-9./\b]+$"); for fractions and decimals

        private ObservableCollection<Person> personList;
        private Person person;
        private bool isEditMode = false;
        public AddPersonPage(Person inPerson, 
            ObservableCollection<Person> inPersonList, 
            ObservableCollection<Item> inItemCatalog,
            Fees inFees,
            bool editModeSelect)
        {

            ItemCatalog = inItemCatalog;

            person = inPerson;
            personList = inPersonList;

            fees = inFees;

            isEditMode = editModeSelect;

            this.DataContext = person;

            InitializeComponent();

            ExitButton.Visibility = Visibility.Hidden;

            // Handles when user is editing a person rather than creating a new.
            if (isEditMode)
            {
                foreach (Item item in person.inventory)
                {
                    itemList.Add(item);
                }
                ExitButton.Visibility = Visibility.Visible;
            }

            ItemListBox.ItemsSource = itemList;

        }

        private void AddItemButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (ItemCatalog.Count == 0)
            {
                // Allow for item creation
                Item item = new Item("Enter Name", 5, 1);
                itemList.Add(item);
                person.AddItemToInventory(item);

                ExitButton.Visibility = Visibility.Visible;
            }
            else 
            {
                // Allow for item selection
                this.NavigationService.Navigate(new SelectItemPage(person, itemList, ItemCatalog));
                ExitButton.Visibility = Visibility.Visible;
            }
        }

        private void ExitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (person.VerifyInventory())
            {
                person.CalculatePrice(fees);

                if (isEditMode == false)
                {
                    personList.Add(person);
                }

                this.NavigationService.GoBack();
            }
            else
            {
               
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

                        if (itemList.Count <= 0)
                        {
                            ExitButton.Visibility = Visibility.Hidden;
                        }

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
                    nameTextBox.SetResourceReference(TextBox.BackgroundProperty, "TextBoxBackgroundBrush");
                }
                else
                {
                    nameTextBox.Background = Brushes.Red;
                }
           }
        }

        private void ItemPriceTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (_inputRegex.IsMatch(e.Text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ItemQuantityTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (_inputRegex.IsMatch(e.Text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
