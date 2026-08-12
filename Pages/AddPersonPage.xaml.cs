using System.Collections.ObjectModel;
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
        public AddPersonPage(Person inPerson)
        {
            InitializeComponent();
        }
    }
}
