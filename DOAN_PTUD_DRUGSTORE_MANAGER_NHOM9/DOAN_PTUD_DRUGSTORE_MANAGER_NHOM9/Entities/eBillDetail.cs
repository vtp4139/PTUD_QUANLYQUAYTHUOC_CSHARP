using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eBillDetail
    {
        string billID, medicineID;
        int quantity;
        double price, discount;

        public eBillDetail()
        {
            BillID = "";
            MedicineID = "";
            Quantity = 0;
            Price = 0;
            Discount = 0;
        }

        public eBillDetail(string billID, string medicineID, int quantity, double price, double discount)
        {
            BillID = billID;
            MedicineID = medicineID;
            Quantity = quantity;
            Price = price;
            Discount = discount;
        }

        public string BillID { get => billID; set => billID = value; }
        public string MedicineID { get => medicineID; set => medicineID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public double Discount { get => discount; set => discount = value; }
    }
}
