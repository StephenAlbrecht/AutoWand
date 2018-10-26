using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        Employee User;
        Customer Customer;
        XmlSerializer xmler = new XmlSerializer(typeof(ObservableCollection<Service>));
        ObservableCollection<Service> Services = new ObservableCollection<Service>();
        ObservableCollection<Service> CartServices = new ObservableCollection<Service>();

        public Cart(ref Employee user, ref Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            User = user;
            CustomerLabel.Content = $"Customer: {Customer.ToString()}";
            ReadInServices();
        }

        private void ReadInServices()
        {
            string path = "Services.xml";
            if (File.Exists(path))
            {
                using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Services = xmler.Deserialize(readStream) as ObservableCollection<Service>;
                }
            }
        }

        private void AddToCart(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveFromCart(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateTotal()
        {

        }
    }
}
