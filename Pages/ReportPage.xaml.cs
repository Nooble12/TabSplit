using System.Windows;
using System.Windows.Controls;

namespace TabSplit.Pages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage(string reportString)
        {
            InitializeComponent();

            ReportTextBox.Text = reportString;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
