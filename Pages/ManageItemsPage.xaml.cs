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
        public ManageItemsPage()
        {
            InitializeComponent();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            ItemManager.Instance.itemList.Add(new Item("Test Item", 100, 1));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
