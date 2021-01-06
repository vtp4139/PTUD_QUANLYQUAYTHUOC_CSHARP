using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eBill
    {
        DateTime orderDate;
        string customerID, employeeID;
        int billID;


        public eBill()
        {
            //OrderDate = "1/1/1";
            CustomerID = "";
            EmployeeID = "";
            BillID = 0;
        }

        public eBill(DateTime orderDate, string customerID, string employeeID, int billID)
        {
            OrderDate = orderDate;
            CustomerID = customerID;
            EmployeeID = employeeID;
            BillID = billID;
        }

        public int BillID { get => billID; set => billID = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string EmployeeID { get => employeeID; set => employeeID = value; }

    }
}
