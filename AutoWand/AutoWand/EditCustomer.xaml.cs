using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AutoWand
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window,INotifyPropertyChanged
    {
        public Customer Cust = new Customer();
        public event PropertyChangedEventHandler PropertyChanged;

        public EditCustomer(ref Customer cust)
        {
            InitializeComponent();
            Cust = cust;
        }
        
        private string _phoneNumber;
        public string phoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("phoneNumber"));
            }
        }

        private string _street;
        public string street
        {
            get { return _street; }
            set
            {
                _street = value;
                PropertyChanged(this, new PropertyChangedEventArgs("street"));
            }
        }

        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                _city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("city"));
            }
        }

        private string _state;
        public string state
        {
            get { return _state; }
            set
            {
                _state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("state"));
            }
        }

        private string _zipCode;
        public string zipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("zipCode"));
            }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
               
                PropertyChanged(this, new PropertyChangedEventArgs("email"));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (verifyData())
            {
                Cust.PhoneNumber = phoneNumber;
                Cust.Address = $"{street}, {city}, {state}, {zipCode}";
                Cust.EmailAddress = email;
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateAlphabetical(string tester)
        {
            return tester.Where(x => char.IsLetter(x) || char.IsSeparator(x)).Count() == tester.Length; // lambda checking each char in string for letter
        }
        private bool ValidateNumerical(string tester)
        {
            return tester.Where(x => char.IsNumber(x)).Count() == tester.Length; // lambda checking each char in string for letter
        }

        private bool verifyData()
        {
            bool control = true;
            if (string.IsNullOrWhiteSpace(streetBox.Text) || !ValidateAlphabetical(cityBox.Text) || string.IsNullOrWhiteSpace(cityBox.Text) ||
                !ValidateAlphabetical(stateBox.Text) || string.IsNullOrWhiteSpace(stateBox.Text) || !ValidateNumerical(zipBox.Text) || string.IsNullOrWhiteSpace(zipBox.Text))
            {
                MessageBox.Show("A valid address must be given for billing purposes!", "Customer Creation Error");
                control = false;
            }
            
            return control;
        }
    }
}
