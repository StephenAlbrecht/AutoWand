using PetShop.Classes;
using System;
using System.Collections.Generic;
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
    class EmployeeLoginVM : INotifyPropertyChanged
    {
        public List<Employee> Employees = new List<Employee>();
        XmlSerializer xmler = new XmlSerializer(typeof(List<Employee>));
        Employee User;

        public EmployeeLoginVM()
        {
            ReadInUsers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Properties
        private string _userName;
        public string userName
        {
            get { return _userName; }
            set {
                _userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("userName"));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        //Populate Employee Data Structure
        private void ReadInUsers()
        {
            string path = "Employees.xml";
            if (File.Exists(path))
            {
                using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Employees = xmler.Deserialize(readStream) as List<Employee>;
                }
            }
        }
        

        private void LogInClick(object sender)
        {
            // if fields valid
            if (FieldsValid())
            {
                CustomerFinder lookupWin = new CustomerFinder(ref Employees, ref User); // pass users
                lookupWin.ShowDialog();
            }
        }
        
        //command Structure for LoginClick command
        public ICommand loginCommand
        {
            get
            {
                if (loginEvent == null)
                {
                    loginEvent = new DelegateCommand(LogInClick);
                }
                return loginEvent;
            }
        }
        DelegateCommand loginEvent;
        
        //clear elements helper function
        private void ClearFields()
        {
            userName = "";
            Password = "";
        }


        private void AddNewEmployeeClick(object sender)
        {
            // if fields valid and user is admin
            if (FieldsValid() && (User.Permission == 'M' || User.Permission == 'A'))
            {
                AddNewEmployee newEmployeeWin = new AddNewEmployee(ref Employees, ref User); // pass users
                newEmployeeWin.ShowDialog();
            }
            else
            {
                if (User.Permission == 'E' && FieldsValid())
                {
                    MessageBox.Show("You do not have permission to create new users.", "Access Denied");
                }
            }
        }
        //command Structure for addnewemployeeClick command
        public ICommand addNewEmpCommand
        {
            get
            {
                if (newEmpEvent == null)
                {
                    newEmpEvent = new DelegateCommand(AddNewEmployeeClick);
                }
                return newEmpEvent;
            }
        }
        DelegateCommand newEmpEvent;

        private bool FieldsValid()
        {
            bool valid = true;
            if (string.IsNullOrWhiteSpace(userName))
            {
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                valid = false;
            }
            if (!valid) return false; // returns before User is assigned

            User = Employees.FirstOrDefault(e => e.UserName == userName);
            if (User?.Password != Password)
            {
                valid = false;
                MessageBox.Show("Invalid username or password. Please try again.", "Invalid credentials");
                ClearFields();
            }
            return valid;
        }

    }
}
