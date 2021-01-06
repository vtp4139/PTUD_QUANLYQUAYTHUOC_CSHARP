using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dBillDetail
    {
        DrugStoreDataContext db;
        public dBillDetail()
        {
            db = new DrugStoreDataContext();
        }

        public List<eBillDetail> getAllBillDetail(int i)
        {
            var listBD = (from b in db.ct_hoaDons
                          join t in db.thuocs on b.maThuoc equals t.maThuoc
                          where b.maHD == i
                           select new
                           {
                               t.tenThuoc,
                               b.soLuong,
                               b.donGia,
                               b.maHD
                           }
                           ).ToList();
            List<eBillDetail> ls = new List<eBillDetail>();
            foreach (var m in listBD)
            {
                eBillDetail e = new eBillDetail();
                e.BillID = m.maHD.ToString();
                e.MedicineID = m.tenThuoc;
                e.Price = (double) m.donGia;
                e.Quantity = (int) m.soLuong;

                ls.Add(e);
            }
            return ls;
        }
        public int insertOrderDetail(List<eBillDetail> list) //Thêm chi tiết hóa đơn
        {
            foreach (eBillDetail ord in list)
            {
                ct_hoaDon ct = new ct_hoaDon();
                ct.maHD = int.Parse(ord.BillID);
                ct.maThuoc = ord.MedicineID;
                ct.donGia = (decimal)ord.Price;
                ct.soLuong = (short)ord.Quantity;

                db.ct_hoaDons.InsertOnSubmit(ct);
                db.SubmitChanges();
            }
            return 1;
        }
        public double totalMoney(int billID)
        {
            var listBD = (from b in db.ct_hoaDons
                          where b.maHD == billID
                          select b).ToList();

            double total = 0;

            foreach (var m in listBD)
            {
                total = total + (double) m.donGia;
            }
            return total;
        }
    }
}
