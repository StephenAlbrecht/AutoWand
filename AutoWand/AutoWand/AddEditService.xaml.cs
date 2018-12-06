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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace AutoWand
{
    /// <summary>
    /// Interaction logic for AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Window
    {
        List<Service> Services = new List<Service>();
        XmlSerializer xmler = new XmlSerializer(typeof(List<Service>));
        public AddEditService()
        {
            InitializeComponent();
            ReadInServices();
        }

        private void ReadInServices()
        {
            string path = "Services.xml";
            if (File.Exists(path))
            {
                using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Services = xmler.Deserialize(readStream) as List<Service>;
                }
            }
        }

        private void WriteServices()
        {
            string path = "Services.xml";
            {
                using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    xmler.Serialize(filestream, Services);
                }
            }
        }

        private void AddService(object sender, RoutedEventArgs e)
        {
            if(FieldsValid())
            {
                double partsCost = double.Parse(PartsEntry.Text);
                double laborCost = double.Parse(LaborEntry.Text);
                Services.Add(new Service(NameEntry.Text, partsCost, laborCost, partsCost + laborCost));
                WriteServices();
                MessageBox.Show($"{NameEntry.Text} successfully added to database");
                Close();
            }
        }

        private bool FieldsValid()
        {
            double partsCost, laborCost;
            bool valid = true;
            // check for null/white space first
            List<TextBox> tbs = ParentGrid.Children.OfType<TextBox>().ToList();
            foreach (TextBox tb in tbs)
            {
                if (string.IsNullOrWhiteSpace(tb.Text) && tb.Name != "TrimEntry")
                {
                    valid = false;
                    tb.BorderBrush = Brushes.Red;
                }
            }
            if (!valid) return false; // return before actual validation

            // validate doubles
            if (!double.TryParse(PartsEntry.Text, out partsCost))
            {
                PartsEntry.BorderBrush = System.Windows.Media.Brushes.Red;
                valid = false;
            }
            if (!double.TryParse(LaborEntry.Text, out laborCost))
            {
                LaborEntry.BorderBrush = System.Windows.Media.Brushes.Red;
                valid = false;
            }

            return valid;
        }

        private void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            tb.BorderBrush = Brushes.DarkGray;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
