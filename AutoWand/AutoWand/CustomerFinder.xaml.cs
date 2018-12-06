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
    /// Interaction logic for CustomerFinder.xaml
    /// </summary>
    public partial class CustomerFinder : Window
    {
        public List<Employee> Employees = new List<Employee>();
        Employee User;

        public ObservableCollection<Customer> customerCollection = new ObservableCollection<Customer>();
        public Customer custOut = new Customer();
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Customer>));

        string path = "Customers.xml";
        private void readCustomersFromMem()
        {
            using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                customerCollection = serializer.Deserialize(readStream) as ObservableCollection<Customer>;
            }
        }

        public CustomerFinder(ref List<Employee> employees, ref Employee user)
        {
            InitializeComponent();
            Employees = employees;
            User = user;
            if (File.Exists(path))
            {
                readCustomersFromMem();
            }
            customerBox.ItemsSource = customerCollection;
        }

        private bool ValidateAlphabetical(string tester)
        {
            return tester.Where(x => char.IsLetter(x)).Count() == tester.Length; // lambda checking each char in string for letter
        }
        private bool ValidateNumerical(string tester)
        {
            return tester.Where(x => char.IsNumber(x)).Count() == tester.Length; // lambda checking each char in string for letter
        }
        
        private void searchNameButtonClick(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Customer> customerOutCol = new ObservableCollection<Customer>();

            if (string.IsNullOrWhiteSpace(fNameBox.Text) || string.IsNullOrWhiteSpace(lNameBox.Text) 
                || !ValidateAlphabetical(fNameBox.Text) || !ValidateAlphabetical(lNameBox.Text))
            {
                MessageBox.Show("Please enter valid names to search for.");
            }
            else
            {
                customerBox.ItemsSource = new ObservableCollection<Customer>(customerCollection
                    .Where(c => c.FirstName == fNameBox.Text && c.LastName == lNameBox.Text));
            }
        }

        private void searchPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(phoneBox.Text) ||  !ValidateNumerical(phoneBox.Text))
            {
                MessageBox.Show("Please enter a valid phone number to search for.");
            }
            else
            {
                customerBox.ItemsSource = new ObservableCollection<Customer>(customerCollection
                    .Where(c => c.PhoneNumber == phoneBox.Text));
            }
        }

        private void searchEmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailBox.Text))
            {
               MessageBox.Show("Please enter a valid email address to search for.");
            }
            else
            {
                customerBox.ItemsSource = new ObservableCollection<Customer>(customerCollection
                    .Where(c => c.EmailAddress == emailBox.Text));
            }
        }

        private void cancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
        private void addNewCustomer(object sender, RoutedEventArgs e)
        {
            AddNewCustomer newCustomer = new AddNewCustomer(ref customerCollection);
            newCustomer.ShowDialog();
        }

        private void customerSelectButton_Click(object sender, RoutedEventArgs e)
        { 
            Customer output = customerBox.SelectedItem as Customer;
            if (output != null)
            {
                Cart newCart = new Cart(ref User, ref output);
                this.Close();
                newCart.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("No customer selected. Select a customer or add a new one.", "Cannot Continue");
            }
        }

        private void customerEditButton_Click(object sender, RoutedEventArgs e)
        {
            Customer cust = customerBox.SelectedItem as Customer;
            if (cust != null) {
                EditCustomer edit = new EditCustomer(ref cust);
                edit.ShowDialog();
            }
            else
            {
                MessageBox.Show("No customer selected. Select a customer or add a new one.", "Cannot Continue");
            }
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            EditEmployee edit = new EditEmployee(ref Employees,ref User);
            edit.ShowDialog();
        }
    }
}