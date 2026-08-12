using System.Windows;
using TabSplit.Classes;

namespace TabSplit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> personList = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Visibility = Visibility.Visible;

            MainPage page = new MainPage();
            MainFrame.Navigate(page);
        }
    }
}