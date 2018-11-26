using AutoWand.VewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace AutoWand
{
    /// <summary>
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddNewCustomer : Window
    {
        public AddNewCustomer(ref ObservableCollection<Customer> customers)
        {
            AddNewCustomerVM newCust = new AddNewCustomerVM(ref customers);
            InitializeComponent();
            DataContext = newCust;
            fNameBox.Focus();
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            verifyData();
        }

        private bool ValidateAlphabetical(string tester)
        {
            return tester.Where(x => char.IsLetter(x) || char.IsSeparator(x)).Count() == tester.Length; // lambda checking each char in string for letter
        }
        private bool ValidateNumerical(string tester)
        {
            return tester.Where(x => char.IsNumber(x)).Count() == tester.Length; // lambda checking each char in string for letter
        }
        
        private bool verifyData() {
            bool control = true;

            if (string.IsNullOrWhiteSpace(fNameBox.Text) || string.IsNullOrWhiteSpace(lNameBox.Text) || !ValidateAlphabetical(fNameBox.Text) || !ValidateAlphabetical(lNameBox.Text))
            {
                MessageBox.Show("A valid name must be given for billing purposes!", "Customer Creation Error");
                control = false;
            }
            else if(string.IsNullOrWhiteSpace(streetBox.Text) || !ValidateAlphabetical(cityBox.Text) || string.IsNullOrWhiteSpace(cityBox.Text) || 
                !ValidateAlphabetical(stateBox.Text) || string.IsNullOrWhiteSpace(stateBox.Text) || !ValidateNumerical(zipBox.Text) || string.IsNullOrWhiteSpace(zipBox.Text))
            {
                MessageBox.Show("A valid address must be given for billing purposes!", "Customer Creation Error");
                control = false;
            }
            else if (!ValidateNumerical(phoneBox.Text) || string.IsNullOrWhiteSpace(phoneBox.Text))
            {
                phoneBox.BorderBrush = Brushes.Red;
                control = false;
            }
            else
            {
                phoneBox.BorderBrush = Brushes.DarkGray;
                emailBox.BorderBrush = Brushes.DarkGray;
            }
            return control;
        }
        
        private void cancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
