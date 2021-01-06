using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eEmployeeType
    {
        string employeeTypeID, employeeTypeName;

        public eEmployeeType()
        {
            EmployeeTypeID = "";
            EmployeeTypeName = "";
        }
        public eEmployeeType(string employeeTypeID, string employeeTypeName)
        {
            EmployeeTypeID = employeeTypeID;
            EmployeeTypeName = employeeTypeName;
        }

        public string EmployeeTypeID
        {
            get
            {
                return employeeTypeID;
            }

            set
            {
                employeeTypeID = value;
            }
        }

        public string EmployeeTypeName
        {
            get
            {
                return employeeTypeName;
            }

            set
            {
                employeeTypeName = value;
            }
        }

        /* public string EmployeeTypeID { get => employeeTypeID; set => employeeTypeID = value; }
         public string EmployeeTypeName { get => employeeTypeName; set => employeeTypeName = value; }*/
    }
}
