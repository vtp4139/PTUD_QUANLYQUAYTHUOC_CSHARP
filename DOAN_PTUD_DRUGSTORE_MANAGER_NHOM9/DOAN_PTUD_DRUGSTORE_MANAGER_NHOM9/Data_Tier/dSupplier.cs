using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dSupplier
    {
        DrugStoreDataContext db;
        public dSupplier()
        {
            db = new DrugStoreDataContext();
        }

        //Lấy toàn bộ khách hàng có trong database
        public List<eSupplier> getAllSupplier()
        {
            var listCus = (from m in db.nhaCungCaps
                           select m).ToList();
            List<eSupplier> ls = new List<eSupplier>();
            foreach (var m in listCus)
            {
                eSupplier e = new eSupplier();
                e.SupplierId = m.maNCC.ToString();
                e.SupplierName = m.tenNCC;
                e.Address = m.diaChi;
                e.Phone = m.phone;

                ls.Add(e);
            }
            return ls;
        }

        //Kiểm tra mã nhà cung cấp có tồn tại 
        public bool checkIDExist(string id)
        {
            nhaCungCap emp = db.nhaCungCaps.Where(x => x.maNCC.ToString() == id).FirstOrDefault();
            if (emp != null)
                return true;
            return false;
        }

        //Nhập nhà cung cấp mới vào database
        public int insertSupplier(eSupplier sup)
        {
            if (checkIDExist(sup.SupplierId))
                return 0;

            nhaCungCap suptemp = new nhaCungCap();

            suptemp.maNCC = int.Parse(sup.SupplierId);
            suptemp.tenNCC = sup.SupplierName;
            suptemp.diaChi = sup.Address;
            suptemp.phone = sup.Phone;

            db.nhaCungCaps.InsertOnSubmit(suptemp);
            db.SubmitChanges();
            return 1;
        }

        //Xóa nhà cung cấp khỏi database
        public bool deleteSupplier(string id)
        {
            nhaCungCap sup = db.nhaCungCaps.Where(x => x.maNCC.ToString() == id).FirstOrDefault();
            if (sup != null)
            {
                db.nhaCungCaps.DeleteOnSubmit(sup);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        //Sửa thông tin nhà cung cấp
        public void updateSupplier(eSupplier sup)
        {
            nhaCungCap suptemp = db.nhaCungCaps.Where(x => x.maNCC.ToString().Equals(sup.SupplierId)).FirstOrDefault();

            // Cập nhật dữ liệu
            suptemp.maNCC = int.Parse(sup.SupplierId);
            suptemp.tenNCC = sup.SupplierName;
            suptemp.diaChi = sup.Address;
            suptemp.phone = sup.Phone;

            db.SubmitChanges();
        }
    }
}
