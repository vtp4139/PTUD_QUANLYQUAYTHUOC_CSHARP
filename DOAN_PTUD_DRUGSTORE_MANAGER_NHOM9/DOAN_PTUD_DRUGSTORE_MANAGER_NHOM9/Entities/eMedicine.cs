using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eMedicine
    {
        string medicineID, medicineName, quantity,categoryName, supplierName, describe,country;
        int unitsInStock;
        double price,sellPrice;
        DateTime exp;

        public eMedicine(string medicineID, string medicineName, int unitsInStock, double price, string quantity, string categoryName, string supplierName, DateTime exp, string describe, string country, double sellPrice)
        {
            MedicineID = medicineID;
            MedicineName = medicineName;
            UnitsInStock = unitsInStock;
            Price = price;
            Quantity = quantity;
            CategoryName = categoryName;
            SupplierName = supplierName;
            Exp = exp;
            Describe = describe;
            Country = country;
            SellPrice = sellPrice;
        }
        public eMedicine()
        {
            MedicineID = "";
            MedicineName = "";
            UnitsInStock = 0;
            Price = 0;
            Quantity = "";
            CategoryName = "";
            SupplierName = "";
            //Exp = "";
            Describe = "";
            Country = "";
        }

        public string MedicineID
        {
            get
            {
                return medicineID;
            }

            set
            {
                medicineID = value;
            }
        }

        public string MedicineName
        {
            get
            {
                return medicineName;
            }

            set
            {
                medicineName = value;
            }
        }
        public int UnitsInStock
        {
            get
            {
                return unitsInStock;
            }

            set
            {
                unitsInStock = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public double SellPrice { get => sellPrice; set => sellPrice = value; }
        public string Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
        public string CategoryName
        {
            get
            {
                return categoryName;
            }

            set
            {
                categoryName = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return supplierName;
            }

            set
            {
                supplierName = value;
            }
        }
        public DateTime Exp { get => exp; set => exp = value; }
        public string Describe { get => describe; set => describe = value; }
        public string Country { get => country; set => country = value; }
    }
}
