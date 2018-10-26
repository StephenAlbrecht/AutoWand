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
        public string FirstName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string LastName { get; set; }

        //address class
        [XmlAttribute(DataType = "string")]
        public string Address { get; set; } //we will simply take all of the different address elements
                                               //and add them to a single string
        //personal contact details
        [XmlAttribute(DataType = "int")]
        public int PhoneNumber { get; set; }
        [XmlAttribute(DataType = "string")]
        public string EmailAddress { get; set; }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName, string address, int phoneNumber, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
