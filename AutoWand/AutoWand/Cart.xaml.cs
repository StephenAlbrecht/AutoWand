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
        List<string> VehicleInfo = new List<string>();

        public Cart(ref Employee user, ref Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            User = user;
            CustomerLabel.Content = $"Customer: {Customer.FirstName} {Customer.LastName}";
            ReadInServices();
            ServicesListBox.ItemsSource = Services;
            CartListView.ItemsSource = CartServices;
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
            if(ServicesListBox.SelectedIndex != -1)
            {
                Service selection = ServicesListBox.SelectedItem as Service;
                CartServices.Add(selection);
                AddTotal(selection);
            }
        }

        private void RemoveFromCart(object sender, RoutedEventArgs e)
        {
            if(CartListView.SelectedIndex != -1)
            {
                int index = CartListView.SelectedIndex;
                Service selection = CartListView.SelectedItem as Service;
                CartServices.RemoveAt(index);
                RemoveTotal(selection);
            }
        }

        private void SubmitCommand(object sender, RoutedEventArgs e)
        {
            if(FieldsValid())
            {
                string trim = (string.IsNullOrWhiteSpace(TrimEntry.Text)) ? "" : TrimEntry.Text;
                VehicleInfo.AddRange(new List<string> { YearEntry.Text, MakeEntry.Text, ModelEntry.Text, trim });

                ConfirmOrder confirmWin = new ConfirmOrder(ref User, ref Customer, ref CartServices, ref VehicleInfo);
                confirmWin.ShowDialog();
            }
        }

        private void CancelCommand(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearFieldsCommand(object sender, RoutedEventArgs e)
        {
            YearEntry.Text = "";
            MakeEntry.Text = "";
            ModelEntry.Text = "";
            TrimEntry.Text = "";
        }

        private void AddTotal(Service service)
        {
            double itemTotal = double.Parse(ItemTotal.Content as string);
            itemTotal += service.Total;
            double tax = itemTotal * 0.07;
            double grandTotal = itemTotal + tax;
            ItemTotal.Content = itemTotal.ToString("N2");
            Tax.Content = tax.ToString("N2");
            GrandTotal.Content = grandTotal.ToString("N2");
        }

        private void RemoveTotal(Service service)
        {
            double itemTotal = double.Parse(ItemTotal.Content as string);
            itemTotal -= service.Total;
            double tax = itemTotal * 0.07;
            double grandTotal = itemTotal + tax;
            ItemTotal.Content = itemTotal.ToString("N2");
            Tax.Content = tax.ToString("N2");
            GrandTotal.Content = grandTotal.ToString("N2");
        }

        private bool FieldsValid()
        {
            bool valid = true;
            List<TextBox> vehicleTBs = VehicleInfoPanel.Children.OfType<TextBox>().ToList();
            foreach(TextBox tb in vehicleTBs)
            {
                if(string.IsNullOrWhiteSpace(tb.Text) && tb.Name != "TrimEntry")
                {
                    valid = false;
                    tb.BorderBrush = Brushes.Red;
                }
            }
            if (!valid) return false; // return before actual validation

            if(!ValidateNumerical(YearEntry.Text) || YearEntry.Text.Length != YearEntry.MaxLength)
            {
                MessageBox.Show("Vehicle year is invalid", "Service Error");
                return false;
            }
            if(!ValidateAlphabetical(MakeEntry.Text))
            {
                MessageBox.Show("Make is invalid", "Service Error");
                return false;
            }
            if(CartServices.Count == 0)
            {
                valid = false;
                MessageBox.Show("Cart is empty.", "Service Error");
            }

            return valid;
        }

        private bool ValidateAlphabetical(string tester)
        {
            return tester.Where(x => char.IsLetter(x)).Count() == tester.Length;
        }

        private bool ValidateNumerical(string tester)
        {
            return tester.Where(x => char.IsNumber(x)).Count() == tester.Length;
        }

        private void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            tb.BorderBrush = Brushes.DarkGray;
        }
    }
}
