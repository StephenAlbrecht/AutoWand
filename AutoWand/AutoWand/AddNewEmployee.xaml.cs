using System;
using System.Collections.Generic;
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
        XmlSerializer xmler = new XmlSerializer(typeof(List<Employee>));
        int newID;

        public AddNewEmployee(ref List<Employee> employees)
        {
            InitializeComponent();
            Employees = employees;
            newID = GenerateID();
            ID.Content = newID.ToString();
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
                // use LINQ statement to get employees with same id
                // if returned list is empty, validID = true;
                validID = true;
            }
            return tempID;
        }

        private void CreateAccountClick(object sender, RoutedEventArgs e)
        {
            // if fields are valid and no conflicts with existing accounts
            // adds user to xml file
            Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
