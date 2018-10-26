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
        [XmlAttribute(DataType = "String")]
        public string ServiceName { get; set; }
        [XmlAttribute(DataType = "Double")]
        public double PartsCost { get; set; }
        [XmlAttribute(DataType = "Double")]
        public double LaborCost { get; set; }

        public Service() {}

        public Service(string serviceName, double partsCost, double laborCost)
        {
            ServiceName = serviceName;
            PartsCost = partsCost;
            LaborCost = laborCost;
        }
    }
}
