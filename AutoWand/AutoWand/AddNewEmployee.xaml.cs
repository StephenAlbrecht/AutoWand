using System;
using System.Collections;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace AutoWand
{
    /// <summary>
    /// Interaction logic for AddNewEmployee.xaml
    /// </summary>
    public partial class AddNewEmployee : Window
    {
        public List<Employee> Employees = new List<Employee>();
        Employee User;
        XmlSerializer xmler = new XmlSerializer(typeof(List<Employee>));
        int newID;

        public AddNewEmployee(ref List<Employee> employees, ref Employee user)
        {
            InitializeComponent();
            Employees = employees;
            User = user;
            newID = GenerateID();
            ID.Content = newID.ToString();
            PermissionSelector.ItemsSource = SetPermissionSelector();
            FirstNameEntry.Focus();
        }

        private IEnumerable SetPermissionSelector()
        {
            if (User.Permission == 'A')
                return new List<string> { "Administrator", "Manager", "Associate" };
            else
                return new List<string> { "Manager", "Associate" };
        }

        /* generates random 6 digit int and checks that no other employee has the same one */
        private int GenerateID()
        {
            Random r = new Random();
            bool validID = false;
            int tempID = 0;
            while(!validID)
            {
                tempID = r.Next(100000, 1000000); // 100,000 - 999,999
                Employee tmp = Employees.FirstOrDefault(x => x.ID == tempID.ToString());
                if (tmp == null)
                {
                    validID = true;
                }
            }
            return tempID;
        }

        private void CreateAccountClick(object sender, RoutedEventArgs e)
        {
            if(FieldsValid())
            {
                char permission;
                if ((string)PermissionSelector.SelectedValue == "Administrator")
                    permission = 'A';
                else if ((string)PermissionSelector.SelectedValue == "Manager")
                    permission = 'M';
                else
                    permission = 'E';

                Employee newUser = new Employee(newID.ToString(), FirstNameEntry.Text, LastNameEntry.Text, 
                    UsernameEntry.Text, PasswordEntry.Password, permission);

                Employees.Add(newUser);
                string path = "Employees.xml";

                if (Employees.Count == 0 && File.Exists(path))
                {
                    File.Delete(path);
                }
                else
                {
                    using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        xmler.Serialize(filestream, Employees);
                    }
                }
                MessageBox.Show(newUser.ToString() + " added to the database", "User Successfully Created");

                Close();
            }
        }


        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool FieldsValid()
        {
            bool valid = true;
            List<TextBox> tbs = ParentGrid.Children.OfType<TextBox>().ToList();
            foreach (TextBox tb in tbs)
            {
                if(string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.BorderBrush = Brushes.Red;
                    valid = false;
                }
            }
            List<PasswordBox> pbs = ParentGrid.Children.OfType<PasswordBox>().ToList();
            foreach (PasswordBox pb in pbs)
            {
                if(string.IsNullOrWhiteSpace(pb.Password))
                {
                    pb.BorderBrush = Brushes.Red;
                    valid = false;
                }
            }
            if(PermissionSelector.SelectedIndex == -1)
            {
                PermissionError.Visibility = Visibility.Visible;
                valid = false;
            }

            if (!valid) return false; // returns before moving to actual validation

            if(!ValidateAlphabetical(FirstNameEntry.Text))
            {
                FirstNameEntry.BorderBrush = Brushes.Red;
                valid = false;
            }
            if(!ValidateAlphabetical(LastNameEntry.Text))
            {
                LastNameEntry.BorderBrush = Brushes.Red;
                valid = false;
            }
            Employee tmp = Employees.FirstOrDefault(x => x.UserName == UsernameEntry.Text);
            if(tmp != null)
            {
                UsernameEntry.BorderBrush = Brushes.Red;
                MessageBox.Show("Username already in use.", "Account Creation Error");
                return false;
            }
            if(PasswordEntry.Password != PasswordConfirmEntry.Password)
            {
                PasswordEntry.BorderBrush = Brushes.Red;
                PasswordConfirmEntry.BorderBrush = Brushes.Red;
                MessageBox.Show("Passwords do not match.", "Account Creation Error");
                return false;
            }

            return valid;
        }

        private bool ValidateAlphabetical(string tester)
        {
            return tester.Where(x => char.IsLetter(x) || char.IsSeparator(x)).Count() == tester.Length;
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

        private void PermissionClicked(object sender, MouseButtonEventArgs e)
        {
            PermissionError.Visibility = Visibility.Hidden;
        }

        private void PermissionChanged(object sender, SelectionChangedEventArgs e)
        {
            PermissionError.Visibility = Visibility.Hidden;
        }
    }
}
