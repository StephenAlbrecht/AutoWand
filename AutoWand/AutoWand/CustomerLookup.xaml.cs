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

namespace AutoWand
{
    /// <summary>
    /// Interaction logic for CustomerLookup.xaml
    /// </summary>
    public partial class CustomerLookup : Window
    {
        public List<Employee> Employees = new List<Employee>();

        public CustomerLookup(ref List<Employee> employees)
        {
            InitializeComponent();
            Employees = employees;
        }
    }
}
