using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using TabSplit.Classes;

namespace TabSplit.Pages
{
    /// <summary>
    /// Interaction logic for ManageItemsPage.xaml
    /// </summary>
    public partial class ManageItemsPage : Page
    {
        private static readonly Regex _inputRegex = new Regex("^[0-9./\b]+$");
        public ManageItemsPage()
        {
            InitializeComponent();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            ItemManager.Instance.itemList.Add(new Item("Enter Name", 10, 1));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var instance = button.DataContext;
                switch (instance)
                {
                    case Item item:
                        ItemManager.Instance.itemList.Remove(item);
                       
                        // Need to also remove the item from each person's inventory
                        break;
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
    }
}
