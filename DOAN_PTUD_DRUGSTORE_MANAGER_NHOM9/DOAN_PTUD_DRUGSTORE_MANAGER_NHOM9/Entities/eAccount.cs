using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eAccount
    {
        string employeeID, password;

        public eAccount(string employeeID, string password)
        {
            EmployeeID = employeeID;
            Password = password;
        }
        public eAccount()
        {
            EmployeeID = "";
            Password = "";
        }

        public string EmployeeID { get => employeeID; set => employeeID = value; }
        public string Password { get => password; set => password = value; }
    }
}
