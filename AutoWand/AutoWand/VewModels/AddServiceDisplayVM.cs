using PetShop.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AutoWand
{
    public class AddServiceDisplayVM : INotifyPropertyChanged
    {
        List<Service> Services = new List<Service>();
        XmlSerializer xmler = new XmlSerializer(typeof(List<Service>));

        public AddServiceDisplayVM()
        {
            ReadInServices();
        }

        // Properties
        private string _serviceName;
        public string ServiceName
        {
            get { return _serviceName; }
            set
            {
                _serviceName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ServiceName"));
            }
        }

        private string _partsCost;
        public string PartsCost
        {
            get { return _partsCost; }
            set
            {
                _partsCost = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PartsCost"));
            }
        }

        private string _laborCost;
        public string LaborCost
        {
            get { return _laborCost; }
            set
            {
                _laborCost = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LaborCost"));
            }
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


        private void AddService(object sender)
        {

        }
        

        public ICommand AddServiceCommand
        {
            get
            {
                if (addServiceEvent == null)
                {
                    addServiceEvent = new DelegateCommand(AddService);
                }
                return addServiceEvent;
            }
        }
        DelegateCommand addServiceEvent;


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
