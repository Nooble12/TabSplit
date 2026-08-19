using System.Windows;

namespace TabSplit.Windows
{
    /// <summary>
    /// Interaction logic for PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public PersonInfoWindow(string personReport)
        {
            InitializeComponent();
            PersonInfoTextBox.Text = personReport;

            this.Visibility = Visibility.Visible;
        }
    }
}
