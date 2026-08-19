using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
