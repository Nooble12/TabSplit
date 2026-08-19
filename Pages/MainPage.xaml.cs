using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TabSplit.Classes;
using TabSplit.Pages;
using TabSplit.Windows;

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
        private float serviceFeePercent;

        public MainPage()
        {
            InitializeComponent();
            ItemListBox.ItemsSource = personList;
            GenerateReportButton.Visibility = Visibility.Hidden;
        }

        private void TipPrecentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tipPercent = HandleTextInput(TipPrecentTextBox);
            UpdateAllPersons();
        }

        private void TaxPercentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            taxPercent = HandleTextInput(TaxPercentTextBox);
            UpdateAllPersons();
        }
        private void ServiceFeePercentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            serviceFeePercent = HandleTextInput(ServiceFeePercentTextBox);
            UpdateAllPersons();
        }

        private float HandleTextInput(TextBox inTextBox)
        {
            VerifyInput checker = new VerifyInput();

            if (checker.CheckIfParseToNumber(inTextBox.Text))
            {
                inTextBox.Background = Brushes.White;
                return checker.number;
            }
            else
            {
                inTextBox.Background = Brushes.Red;
                return 0;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VerifyInput checker = new VerifyInput();

            if (checker.CheckIfParseToNumber(TaxPercentTextBox.Text) 
                && checker.CheckIfParseToNumber(TipPrecentTextBox.Text) 
                && checker.CheckIfParseToNumber(ServiceFeePercentTextBox.Text))
            {
                Person person = new Person("Name Here", "Contact Info");
                NavigationService.Navigate(new AddPersonPage(person, personList, tipPercent, taxPercent, serviceFeePercent,false));

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
                    NavigationService.Navigate(new AddPersonPage(person, personList, tipPercent, taxPercent, serviceFeePercent, true));

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
                person.CalculatePrice(tipPercent, taxPercent, serviceFeePercent); 
            }
        }

        private void GenerateReportButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GenerateReport generator = new GenerateReport(personList, taxPercent, tipPercent, serviceFeePercent);
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

        private void ListBoxItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (sender is ListBoxItem item)
            {
                var instance = item.DataContext;

                if (instance is Person person)
                {
                    ObservableCollection<Person> tempList = new ObservableCollection<Person>();
                    tempList.Add(person);

                    GenerateReport generator = new GenerateReport(tempList, taxPercent, tipPercent, serviceFeePercent);
                    string reportString = generator.CreateReport();

                    PersonInfoWindow personInfoWindow = new PersonInfoWindow(reportString);
                }
            }
        }
    }
}
