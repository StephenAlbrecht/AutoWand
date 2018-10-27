using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ConfirmOrder.xaml
    /// </summary>
    public partial class ConfirmOrder : Window
    {
        public ConfirmOrder(ref Employee user, ref Customer customer, ref ObservableCollection<Service> services, ref List<string> vehicleInfo)
        {

            InitializeComponent();
            userInfo.Content = user.UserName;
            custInfo.Content = customer.FirstName + " " + customer.LastName;
            vicInfo.Content = vicBuilder(vehicleInfo);
            servicesList.ItemsSource = services;
            laborTotal.Content = laborCost(services).ToString("N2");
            partsTotal.Content = partsCost(services).ToString("N2");
            double total = partsCost(services) + laborCost(services);
            subtotal.Content = total.ToString("N2");
            double tax = total * 0.07;
            taxLabel.Content = tax.ToString("N2");
            total = total * 1.07;
            Total.Content = total.ToString("N2");

        }

        private double laborCost(ObservableCollection<Service> services)
        {
            double total = 0;
            foreach (Service temp in services)
            {
                total = total + temp.LaborCost;
            }
            return total;
        }

        private double partsCost(ObservableCollection<Service> services)
        {
            double total = 0;
            foreach (Service temp in services)
            {
                total = total + temp.PartsCost;
            }
            return total;
        }
        
        private string vicBuilder(List<string> vehicleInfo)
        {
            string output = "";
            foreach(string temp in vehicleInfo)
            {
                output = output + temp + " ";
            }
            return output;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}