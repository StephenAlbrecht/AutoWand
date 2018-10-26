using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoWand
{   //customer class holds all personal details of a customer so that they can be via database
    [XmlRoot(ElementName = "Customer")]
    public class Customer
    {
        //name
        [XmlAttribute(DataType = "string")]
        public string firstName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string lastName { get; set; }

        //address class
        [XmlAttribute(DataType = "string")]
        public string custAddr { get; set; } //we will simply take all of the different address elements
                                               //and add them to a single string
        //personal contact details
        [XmlAttribute(DataType = "string")]
        public string phoneNumber { get; set; }
        [XmlAttribute(DataType = "string")]
        public string emailAddress { get; set; }

        public override string ToString()
        {
            return $"{firstName}   {lastName}   {emailAddress}   {phoneNumber}";
        }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName, string custAddr, string phoneNumber, string emailAddress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.custAddr = custAddr;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
        }
    }
}
