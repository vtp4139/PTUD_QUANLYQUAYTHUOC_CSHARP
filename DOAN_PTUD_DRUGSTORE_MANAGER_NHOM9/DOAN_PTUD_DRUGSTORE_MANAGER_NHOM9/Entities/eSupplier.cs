using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eSupplier
    {
        string supplierId, supplierName,address,phone;

        public eSupplier()
        {
            SupplierId = "";
            SupplierName = "";
            Address = "";
            Phone = "";
        }

        public eSupplier(string supplierId, string supplierName, string address, string phone)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
            Address = address;
            Phone = phone;
        }

        public string SupplierId { get => supplierId; set => supplierId = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
