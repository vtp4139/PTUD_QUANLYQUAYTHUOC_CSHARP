using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dBill
    {
        DrugStoreDataContext db;
        public dBill()
        {
            db = new DrugStoreDataContext();
        }

        //Lấy toàn bộ hóa đơn có trong database
        public List<eBill> getAllBill()
        {
            var listMed = (from b in db.hoaDons
                           join c in db.khachHangs on b.maKH equals c.maKH //Lấy tên của loại thuốc
                           join n in db.nhanViens on b.maNV equals n.maNV  //Lấy tên của loại NCC
                           select new
                           {
                               b.maHoaDon,
                               b.ngayLapHD,
                               c.tenKH,
                               n.tenNV
                           }
                              ).ToList();
            var listBill = (from m in db.hoaDons
                            select m).ToList();
            List<eBill> ls = new List<eBill>();
            foreach (var m in listMed)
            {
                eBill e = new eBill();
                e.BillID = m.maHoaDon;
                e.OrderDate = m.ngayLapHD.Value;
                e.CustomerID = m.tenNV;
                e.EmployeeID = m.tenKH;

                ls.Add(e);
            }
            return ls;
        }

        public eBill getBillFromID(int id)
        {
            hoaDon hd = db.hoaDons.Where(x => x.maHoaDon == id).FirstOrDefault();           

            eBill temp = new eBill();

            temp.BillID = hd.maHoaDon;
            temp.CustomerID = hd.maKH;
            temp.EmployeeID = hd.maNV;
            temp.OrderDate = (DateTime) hd.ngayLapHD;

            return temp;
        }

        public int insertOrders(eBill or) //Thêm hóa đơn
        {
            hoaDon ortempt = new hoaDon();

            ortempt.ngayLapHD = or.OrderDate;
            ortempt.maKH = or.CustomerID;
            ortempt.maNV = or.EmployeeID;

            db.hoaDons.InsertOnSubmit(ortempt);
            db.SubmitChanges();
            return ortempt.maHoaDon;
        }

        //Xóa hóa đơn khỏi database
        public bool deleteBill(int id)
        {
            hoaDon b = db.hoaDons.Where(x => x.maHoaDon == id).FirstOrDefault();
            if (b != null)
            {
                db.hoaDons.DeleteOnSubmit(b);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        public int subtractQuantity(string id, int quantity)
        {
            thuoc d = db.thuocs.Where(x => x.maThuoc == id).FirstOrDefault();
            if (quantity > d.slTon)
                return -1;
            else
            {
                d.slTon = d.slTon - quantity;
                db.SubmitChanges();
                return 1;
            }
        }

        public int addQuantity(string id, int quantity)
        {
            thuoc d = db.thuocs.Where(x => x.maThuoc == id).FirstOrDefault();

            d.slTon = d.slTon + quantity;
            db.SubmitChanges();

            return 1;
        }

        //thong ke theo thang
        public List<eBill> orderStatistic_M(DateTime date)
        {
            eBill hd;

            List<eBill> ls = new List<eBill>();

            var s = db.hoaDons;

            if (s == null)
            {
                return null;
            }
            else
            {
                foreach (var item in s)
                {
                    if (item.ngayLapHD.Value.Month == date.Month && item.ngayLapHD.Value.Year == date.Year)
                    {
                        hd = new eBill();
                        hd.BillID = item.maHoaDon;
                        hd.OrderDate = (DateTime)item.ngayLapHD;
                        hd.EmployeeID = item.maNV;
                        hd.CustomerID = item.maKH;

                        ls.Add(hd);
                    }
                }
            }
            return ls;
        }
        public List<eBill> orderStatistic_Y(DateTime date)
        {
            eBill hd;

            List<eBill> ls = new List<eBill>();

            var s = db.hoaDons;

            if (s == null)
            {
                return null;
            }
            else
            {
                foreach (var item in s)
                {
                    if (item.ngayLapHD.Value.Year == date.Year)
                    {
                        hd = new eBill();
                        hd.BillID = item.maHoaDon;
                        hd.OrderDate = (DateTime)item.ngayLapHD;
                        hd.EmployeeID = item.maNV;
                        hd.CustomerID = item.maKH;

                        ls.Add(hd);
                    }
                }
            }
            return ls;
        }
        /*    public List<eEmployee> getIncome(DateTime dt)
            {
                //var listMed = db.Products.ToList();

                var listEmpl = (from b in db.hoaDons
                                join ct in db.ct_hoaDons on b.maHoaDon equals ct.maHD //Lấy tên của loại nhân viên
                                where b.ngayLapHD.Value.Month == dt.Month
                                group ct by ct.maHD into g
                                select new
                                {
                                    SumTotal = g.Sum(x => x.donGia);
                                }
                                  ).ToList();
                List<eEmployee> ls = new List<eEmployee>();
                foreach (var m in listEmpl)
                {
                    eEmployee e = new eEmployee();
                    e.EmployeeID = m.maNV;
                    e.EmployeeName = m.tenNV;
                    e.EmployeeType = m.tenLoaiNV;
                    e.Address = m.diaChi;
                    e.Phone = m.dienThoai;

                    ls.Add(e);
                }
                return ls;
            }*/
    }
}
