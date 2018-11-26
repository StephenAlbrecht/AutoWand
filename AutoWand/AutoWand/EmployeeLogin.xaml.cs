using AutoWand.VewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace AutoWand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EmployeeLogin : Window
    {
        public EmployeeLogin()
        {
            EmployeeLoginVM empLog = new EmployeeLoginVM();
            InitializeComponent();
            DataContext = empLog;
        }
        
        private void LogInClick(object sender, RoutedEventArgs e)
        {
            if (FieldsValid()) {

            }
        }
        
        private bool FieldsValid()
        {
            bool valid = true;
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
            {
                UsernameEntry.BorderBrush = Brushes.Red;
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                PasswordEntry.BorderBrush = Brushes.Red;
                valid = false;
            }
            return valid;
        }

        private void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            tb.BorderBrush = Brushes.DarkGray;
        }
    }
}
