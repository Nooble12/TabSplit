using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using TabSplit.Classes;

namespace TabSplit
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<Person> personList { get; set; } = new ObservableCollection<Person>();
        private float tipPercent;
        private float taxPercent;

        public MainPage()
        {
            InitializeComponent();
            ItemListBox.ItemsSource = personList;
        }

        private void TipPrecentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerifyInput checker = new VerifyInput();

            if (checker.CheckIfParseToNumber(TipPrecentTextBox.Text))
            {
                TipPrecentTextBox.Background = Brushes.White;
                tipPercent = checker.number;
            }
            else
            {
                TipPrecentTextBox.Background = Brushes.Red;
            }

        }

        private void TaxPercentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerifyInput checker = new VerifyInput();

            if (checker.CheckIfParseToNumber(TaxPercentTextBox.Text))
            {
                TaxPercentTextBox.Background = Brushes.White;
                taxPercent = checker.number;

                //TODO: Update prices when tip is changed
            }
            else
            {
                TaxPercentTextBox.Background = Brushes.Red;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VerifyInput checker = new VerifyInput();

            if (checker.CheckIfParseToNumber(TaxPercentTextBox.Text) && checker.CheckIfParseToNumber(TipPrecentTextBox.Text))
            {
                Person person = new Person("Name Here", "Contact Info");
                NavigationService.Navigate(new AddPersonPage(person, personList, tipPercent, taxPercent, false));

                //TODO: Update prices when tax is changed
            }
        }

        private void EditButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is Button editButton)
            {
                var instance = editButton.DataContext;
                if (instance is Person person)
                {
                    NavigationService.Navigate(new AddPersonPage(person, personList, tipPercent, taxPercent, true));

                    //personList.Remove(person);
                   // personList.Add(person);
                }
            }
        }
    }
}
