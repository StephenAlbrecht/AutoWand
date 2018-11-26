using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutoWand
{   //employee class will serve to hold employee information, as well as login information
    [XmlRoot(ElementName = "Employee")]
    public class Employee
    {
        //employee ID
        [XmlAttribute(DataType = "string")]
        public string ID { get; set; }

        //employee name info
        [XmlAttribute(DataType = "string")]
        public string FirstName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string LastName { get; set; }

        //employee login information
        [XmlAttribute(DataType = "string")]
        public string UserName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Password { get; set; }
        
        //employee permissions   A: Admin,   M: Manager,   E: Employee
        [XmlAttribute]
        public char Permission { get; set; }

        public Employee() {}

        public Employee(string id, string firstName, string lastName, string userName, string password, char permission)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Permission = permission;
        }

        override public string ToString()
        {
            return $"{ID}: {LastName}, {FirstName}, {UserName}";
        }
    }
}
