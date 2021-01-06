using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eEmployee
    {
        string employeeID, employeeName, employeeType, address, phone;

        public eEmployee()
        {
            EmployeeID = "";
            EmployeeName = "";
            EmployeeType = "";
            Address = "";
            Phone = "";
        }
        public eEmployee(string employeeID, string employeeName, string employeeType, string address, string phone)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            EmployeeType = employeeType;
            Address = address;
            Phone = phone;
        }      

        public string EmployeeID
        {
            get
            {
                return employeeID;
            }

            set
            {
                employeeID = value;
            }
        }

        public string EmployeeName
        {
            get
            {
                return employeeName;
            }

            set
            {
                employeeName = value;
            }
        }

        public string EmployeeType
        {
            get
            {
                return employeeType;
            }

            set
            {
                employeeType = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        /*public string EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string EmployeeType { get => employeeType; set => employeeType = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }*/
    }
}
