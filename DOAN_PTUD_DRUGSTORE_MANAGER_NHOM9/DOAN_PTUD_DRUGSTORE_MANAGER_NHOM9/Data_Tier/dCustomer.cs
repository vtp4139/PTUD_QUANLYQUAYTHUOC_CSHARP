using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dCustomer
    {
        DrugStoreDataContext db;
        public dCustomer()
        {
            db = new DrugStoreDataContext();
        }

        //Lấy toàn bộ khách hàng có trong database
        public List<eCustomer> getAllCustomer()
        {
            var listCus = (from m in db.khachHangs
                            select m).ToList();
            List<eCustomer> ls = new List<eCustomer>();
            foreach (var m in listCus)
            {
                eCustomer e = new eCustomer();
                e.CustomerID = m.maKH;
                e.CustomerName = m.tenKH;
                e.Address = m.diaChi;
                e.Phone = m.phone;

                ls.Add(e);
            }
            return ls;
        }     
    
        //Kiểm tra mã nhân viên có tồn tại 
        public bool checkIDExist(string id)
        {
            nhanVien emp = db.nhanViens.Where(x => x.maNV == id).FirstOrDefault();
            if (emp != null)
                return true;
            return false;
        }

        //Nhập khách hàng mới vào database
        public int insertCustomer(eCustomer cus)
        {
            if (checkIDExist(cus.CustomerID))
                return 0;

            khachHang custemp = new khachHang();

            custemp.maKH = cus.CustomerID;
            custemp.tenKH = cus.CustomerName;
            custemp.diaChi = cus.Address;
            custemp.phone = cus.Phone;

            db.khachHangs.InsertOnSubmit(custemp);
            db.SubmitChanges();
            return 1;
        }

        //Xóa khách hàng khỏi database
        public bool deleteCustomer(string id)
        {
            khachHang cus = db.khachHangs.Where(x => x.maKH == id).FirstOrDefault();
            if (cus != null)
            {
                db.khachHangs.DeleteOnSubmit(cus);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        //Sửa thông tin khách hàng
        public void updateCustomer(eCustomer cus)
        {
            khachHang custemp = db.khachHangs.Where(x => x.maKH.Equals(cus.CustomerID)).FirstOrDefault();

            // Cập nhật dữ liệu
            custemp.maKH = cus.CustomerID;
            custemp.tenKH = cus.CustomerName;
            custemp.diaChi = cus.Address;
            custemp.phone = cus.Phone;

            db.SubmitChanges();
        }
    }
}

