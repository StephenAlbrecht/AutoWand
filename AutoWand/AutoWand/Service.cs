using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoWand
{
    //service class that will represent be used to represent the various services a repair shop performs
    [XmlRoot(ElementName = "Service")]
    public class Service
    {
        //elements of a service
        public string serviceName { get; set; }
        public double partsCost { get; set; }
        public double laborCost { get; set; }

        public Service()
        {
                
        }

        public Service(string serviceName, double partsCost, double laborCost)
        {
            this.serviceName = serviceName;
            this.partsCost = partsCost;
            this.laborCost = laborCost;
        }
    }
}
