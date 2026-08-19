using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using TabSplit.Classes;
using System.Windows;
using TabSplit.Pages;

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
            GenerateReportButton.Visibility = Visibility.Hidden;
        }

        private void TipPrecentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerifyInput checker = new VerifyInput();

            if (checker.CheckIfParseToNumber(TipPrecentTextBox.Text))
            {
                TipPrecentTextBox.Background = Brushes.White;
                tipPercent = checker.number;

                UpdateAllPersons();
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

                UpdateAllPersons();
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

                GenerateReportButton.Visibility = Visibility.Visible;
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

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is Button editButton)
            {
                var instance = editButton.DataContext;

                if (instance is Person person)
                {
                    personList.Remove(person);

                    if (personList.Count == 0)
                    {
                        GenerateReportButton.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        // Recalculates the tip and tax when the value is changed during runtime.
        private void UpdateAllPersons()
        {
            foreach (Person person in personList)
            {
                person.CalculatePrice(tipPercent, taxPercent); 
            }
        }

        private void GenerateReportButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GenerateReport generator = new GenerateReport(personList, taxPercent, tipPercent);
            string reportString = generator.CreateReport();
            NavigationService.Navigate(new ReportPage(reportString));
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to clear?", "Clear Elements", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                personList.Clear();
                GenerateReportButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
