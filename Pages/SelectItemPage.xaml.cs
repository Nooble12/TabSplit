using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TabSplit.Classes;

namespace TabSplit.Pages
{
    /// <summary>
    /// Interaction logic for SelectItemPage.xaml
    /// </summary>
    public partial class SelectItemPage : Page
    {
        private Person person;
        private ObservableCollection<Item> itemList;
        public SelectItemPage(Person inPerson, ObservableCollection<Item> inItemList)
        {
            person = inPerson;
            itemList = inItemList;
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (sender is ListBoxItem box)
            {
                var instance = box.DataContext;

                if (instance is Item item)
                {
                    // TODO: add to person inventory
                    Item itemCopy = new Item(item.name, item.price, 1);
                    person.AddItemToInventory(itemCopy);
                    itemList.Add(itemCopy);
                    this.NavigationService.GoBack();
                }
            }
        }

        private void CreateNewItem_Click(object sender, RoutedEventArgs e)
        {
            Item itemCopy = new Item("Enter Name", 10, 1);
            person.AddItemToInventory(itemCopy);
            itemList.Add(itemCopy);
            this.NavigationService.GoBack();
        }
    }
}
