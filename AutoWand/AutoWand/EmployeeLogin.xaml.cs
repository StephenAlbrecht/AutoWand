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
        public List<Employee> Employees = new List<Employee>();
        XmlSerializer xmler = new XmlSerializer(typeof(List<Employee>));
        Employee User;

        public EmployeeLogin()
        {
            InitializeComponent();
            ReadInUsers();
        }

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

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            // if fields valid
            if (FieldsValid())
            {
                CustomerLookup lookupWin = new CustomerLookup(ref Employees, ref User); // pass users
                lookupWin.ShowDialog();
            }
        }

        private void ClearFields()
        {
            UsernameEntry.Text = "";
            PasswordEntry.Password = "";
        }

        private void AddNewEmployeeClick(object sender, RoutedEventArgs e)
        {
            // if fields valid and user is admin
            if (FieldsValid() && (User.Permission == 'M' || User.Permission == 'A'))
            {
                AddNewEmployee newEmployeeWin = new AddNewEmployee(ref Employees, ref User); // pass users
                newEmployeeWin.ShowDialog();
            }
            else
            {
                if(User.Permission == 'E')
                {
                    MessageBox.Show("You do not have permission to create new users.", "Access Denied");
                }
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
            if (string.IsNullOrWhiteSpace(PasswordEntry.Password))
            {
                PasswordEntry.BorderBrush = Brushes.Red;
                valid = false;
            }
            if (!valid) return false; // returns before User is assigned

            User = Employees.FirstOrDefault(e => e.UserName == UsernameEntry.Text);
            if (User?.Password != PasswordEntry.Password)
            {
                valid = false;
                MessageBox.Show("Invalid username or password. Please try again.", "Invalid credentials");
                ClearFields();
                UsernameEntry.Focus();
            }
            return valid;
        }

        private void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            tb.BorderBrush = Brushes.DarkGray;
        }

        private void PasswordBoxChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (sender as PasswordBox);
            pb.BorderBrush = Brushes.DarkGray;
        }
    }
}
