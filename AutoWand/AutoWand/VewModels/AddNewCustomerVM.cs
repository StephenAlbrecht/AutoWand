using PetShop.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AutoWand.VewModels
{
    class AddNewCustomerVM : INotifyPropertyChanged
    {
        ObservableCollection<Customer> customerList = new ObservableCollection<Customer>();
        XmlSerializer xmler = new XmlSerializer(typeof(ObservableCollection<Customer>));

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        public AddNewCustomerVM(ref ObservableCollection<Customer> customers)
        {
            customerList = customers;
        }

        //Properties
        private string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set {
                _firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("firstName"));
            }
        }

        private string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("lastName"));
            }
        }

        private string _phoneNumber;
        public string phoneNumber
        {
            get { return _phoneNumber; }
            set {
                _phoneNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("phoneNumber"));
            }
        }

        private string _street;
        public string street
        {
            get { return _street; }
            set {
                _street = value;
                PropertyChanged(this, new PropertyChangedEventArgs("street"));
            }
        }

        private string _city;
        public string city
        {
            get { return _city; }
            set {
                _city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("city"));
            }
        }

        private string _state;
        public string state
        {
            get { return _state; }
            set {
                _state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("state"));
            }
        }

        private string _zipCode;
        public string zipCode
        {
            get { return _zipCode; }
            set {
                _zipCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("zipCode"));
            }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("email"));
            }
        }

        private void addClick(object sender)
        {
            if (verifyData())
            {
                Customer tempCust = new Customer();
                tempCust.FirstName = firstName;
                tempCust.LastName = lastName;
                tempCust.PhoneNumber = phoneNumber;
                tempCust.Address = $"{street}, {city}, {state}, {zipCode}";

                if (!string.IsNullOrWhiteSpace(email))
                {
                    tempCust.EmailAddress = email;
                }
                customerList.Add(tempCust);
                writeCustomers();

                MessageBox.Show($"{tempCust.FirstName} {tempCust.LastName} was added to database.", "Customer Successfully Added");
                //this.Close();
            }
        }

        public ICommand addCustCommand
        {
            get
            {
                if (addCustEvent == null)
                {
                    addCustEvent = new DelegateCommand(addClick);
                }
                return addCustEvent;
            }
        }
        DelegateCommand addCustEvent;


        private void writeCustomers()
        {
            string path = "Customers.xml";

            if (customerList.Count == 0 && File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    xmler.Serialize(fileStream, customerList);
                }
            }
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

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || !ValidateAlphabetical(firstName) || !ValidateAlphabetical(lastName))
            {
                control = false;
            }
            else if (string.IsNullOrWhiteSpace(street) || !ValidateAlphabetical(city) || string.IsNullOrWhiteSpace(city) ||
                !ValidateAlphabetical(state) || string.IsNullOrWhiteSpace(state) || !ValidateNumerical(zipCode) || string.IsNullOrWhiteSpace(zipCode))
            {
                control = false;
            }
            else if (!ValidateNumerical(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            { 
                control = false;
            }
            else
            {
                control = true;  
            }
            return control;
        }
    }
}
