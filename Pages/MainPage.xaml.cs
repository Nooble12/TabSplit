using System.Collections.ObjectModel;
using System.Windows.Controls;
using TabSplit.Classes;

namespace TabSplit
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<Person> personList { get; set; } = new ObservableCollection<Person>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Person person = new Person("N/A");
            NavigationService.Navigate(new AddPersonPage(person));
            personList.Add(person);
        }
    }
}
