using System.Windows;
using System.Windows.Controls;

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
