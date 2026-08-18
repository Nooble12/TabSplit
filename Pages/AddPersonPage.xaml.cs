using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using TabSplit.Classes;
using System.Diagnostics;

namespace TabSplit
{
    /// <summary>
    /// Interaction logic for AddPersonPage.xaml
    /// </summary>
    public partial class AddPersonPage : Page
    {
        private ObservableCollection<Item> itemList { get; set; } = new ObservableCollection<Item>();

        private VerifyInput checker = new VerifyInput();
        private static readonly Regex _inputRegex = new Regex("^[0-9./\b]+$"); // WIP new Regex("^[0-9./\b]+$"); for fractions and decimals

        private ObservableCollection<Person> personList;
        private Person person;
        private float tipPercent;
        private float taxPercent;
        private bool isEditMode = false;
        public AddPersonPage(Person inPerson, ObservableCollection<Person> inPersonList, float inTipPercent, float inTaxPercent, bool editModeSelect)
        {

            person = inPerson;
            personList = inPersonList;

            tipPercent = inTipPercent;
            taxPercent = inTaxPercent;

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
            Item item = new Item("Enter Name", 0, 1);
            itemList.Add(item);
            person.AddItemToInventory(item);

            ExitButton.Visibility = Visibility.Visible;
        }

        private void ExitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (person.VerifyInventory())
            {
                person.CalculatePrice(tipPercent, taxPercent);

                if (isEditMode == false)
                {
                    personList.Add(person);
                }

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
                    nameTextBox.Background = Brushes.White;
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
