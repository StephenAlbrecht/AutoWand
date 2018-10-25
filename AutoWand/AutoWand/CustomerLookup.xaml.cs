using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CustomerLookup.xaml
    /// </summary>
    public partial class CustomerLookup : Window, INotifyPropertyChanged
    {
        public List<Employee> Employees = new List<Employee>();
        Employee User;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<Customer> customerCollection = new ObservableCollection<Customer>();

        private Customer custOut;
        public Customer customerOut
        {
            get { return custOut; }
            set {
                custOut = value;
                PropertyChanged(this, new PropertyChangedEventArgs("customerOut")); 
            }
        }

        public CustomerLookup(ref List<Employee> employees, ref Employee user)
        {
            InitializeComponent();
            Employees = employees;
            User = user;
            DataContext = this;
        }

        private Customer searchByName(string firstName, string lastName)
        {
            foreach(Customer temp in customerCollection)
            {
                if (firstName.Equals(temp.firstName) && lastName.Equals(temp.lastName))
                {
                    return temp;
                }
            }
            return null;
        }

        private Customer searchByEmail(string email)
        {
            foreach (Customer temp in customerCollection)
            {
                if (email.Equals(temp.emailAddress))
                {
                    return temp;
                }
            }
            return null;
        }

        private Customer searchByPhone(int phoneNumber)
        {
            foreach (Customer temp in customerCollection)
            {
                if (phoneNumber == temp.phoneNumber)
                {
                    return temp;
                }
            }
            return null;
        }



        private void searchNameButtonClick(object sender, RoutedEventArgs e)
        {
            if (fNameBox.Text != null || lNameBox.Text != null) {
                custOut = searchByName(fNameBox.Text, lNameBox.Text);
                
            }
        }

        private void searchPhoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchEmailButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addNewCustomer(object sender, RoutedEventArgs e)
        {
            AddNewCustomer newCustomer = new AddNewCustomer(ref customerCollection);
            newCustomer.ShowDialog();
        }
    }
}
