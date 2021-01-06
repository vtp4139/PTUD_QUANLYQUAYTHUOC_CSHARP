using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eCustomer
    {
        string customerID, customerName, address, phone;

        public eCustomer()
        {
            CustomerID = "";
            CustomerName = "";
            Address = "";
            Phone = "";
        }

        public eCustomer(string customerID, string customerName, string address, string phone)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            Address = address;
            Phone = phone;
        }      

        public string CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
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

        /*public string CustomerID { get => customerID; set => customerID = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }*/
    }
}
