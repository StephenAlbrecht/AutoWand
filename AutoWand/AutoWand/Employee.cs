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
        public string employeeID { get; set; }

        //employee name info
        [XmlAttribute(DataType = "string")]
        public string firstName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string lastName { get; set; }

        //employee login information
        [XmlAttribute(DataType = "string")]
        public string userName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string password { get; set; }
        
        //employee permissions   A: Admin,   M: Manager,   E: Employee
        [XmlAttribute(DataType = "string")]
        public char employeePerm { get; set; }

        public Employee()
        {

        }

        public Employee(string employeeID, string firstName, string lastName, string userName, string password, char employeePerm)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.employeePerm = employeePerm;
        }
    }
}
