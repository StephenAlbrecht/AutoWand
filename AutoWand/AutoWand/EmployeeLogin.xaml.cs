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
        public List<int> Users = new List<int>(); // change to user class
        XmlSerializer xmler = new XmlSerializer(typeof(List<int>));

        public EmployeeLogin()
        {
            InitializeComponent();
            ReadInUsers();
        }

        private void ReadInUsers()
        {
            throw new NotImplementedException();
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            // if fields valid
            if (true)
            {
                CustomerLookup lookupWin = new CustomerLookup(); // pass users
            }
        }

        private void AddNewEmployeeClick(object sender, RoutedEventArgs e)
        {
            // if fields valid and user is admin
            if (true)
            {
                AddNewEmployee newEmployeeWin = new AddNewEmployee(); // pass users
                newEmployeeWin.Show();
            }
        }
    }
}
