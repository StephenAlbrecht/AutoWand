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

namespace AutoWand
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        Employee Employ = new Employee();
        public List<Employee> Employees = new List<Employee>();

        public EditEmployee(ref List<Employee> employees, ref Employee newEmp)
        {
            InitializeComponent();
            Employ = newEmp;
            Employees = employees;
        }

        private void CreateAccountClick(object sender, RoutedEventArgs e)
        {
            if (FieldsValid())
            {
                char permission;
                if ((string)PermissionSelector.SelectedValue == "Administrator")
                    permission = 'A';
                else if ((string)PermissionSelector.SelectedValue == "Manager")
                    permission = 'M';
                else
                    permission = 'E';

                Employ.UserName = UsernameEntry.Text;
                Employ.Password = PasswordEntry.Password;
                Employ.Permission = permission;

                Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private IEnumerable SetPermissionSelector()
        {
            if (Employ.Permission == 'A')
                return new List<string> { "Administrator", "Manager", "Associate" };
            else
                return new List<string> { "Manager", "Associate" };
        }
        private bool FieldsValid()
        {
            bool valid = true;
            List<TextBox> tbs = ParentGrid.Children.OfType<TextBox>().ToList();
            foreach (TextBox tb in tbs)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.BorderBrush = Brushes.Red;
                    valid = false;
                }
            }
            List<PasswordBox> pbs = ParentGrid.Children.OfType<PasswordBox>().ToList();
            foreach (PasswordBox pb in pbs)
            {
                if (string.IsNullOrWhiteSpace(pb.Password))
                {
                    pb.BorderBrush = Brushes.Red;
                    valid = false;
                }
            }
            if (PermissionSelector.SelectedIndex == -1)
            {
                PermissionError.Visibility = Visibility.Visible;
                valid = false;
            }

            if (!valid) return false; // returns before moving to actual validation

            Employee tmp = Employees.FirstOrDefault(x => x.UserName == UsernameEntry.Text);
            if (tmp != null)
            {
                UsernameEntry.BorderBrush = Brushes.Red;
                MessageBox.Show("Username already in use.", "Account Creation Error");
                return false;
            }
            if (PasswordEntry.Password != PasswordConfirmEntry.Password)
            {
                PasswordEntry.BorderBrush = Brushes.Red;
                PasswordConfirmEntry.BorderBrush = Brushes.Red;
                MessageBox.Show("Passwords do not match.", "Account Creation Error");
                return false;
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
