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
        [XmlAttribute(DataType = "string")]
        public string Name { get; set; }
        [XmlAttribute(DataType = "double")]
        public double PartsCost { get; set; }
        [XmlAttribute(DataType = "double")]
        public double LaborCost { get; set; }
        [XmlAttribute(DataType = "double")]
        public double Total { get; set;  }

        public Service() {}

        public Service(string name, double partsCost, double laborCost, double total)
        {
            Name = name;
            PartsCost = partsCost;
            LaborCost = laborCost;
            //Total = PartsCost + LaborCost;
            Total = total;
        }

        public override string ToString()
        {
            return $" Service: {Name}   Combined Cost: {PartsCost + LaborCost}.00";
        }
    }
}
