using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dQuantityPerUnit
    {
        DrugStoreDataContext db;

        public dQuantityPerUnit()
        {
            db = new DrugStoreDataContext();
        }

        //Lấy toàn bộ đơn vị tính có trong database
        public List<eQuantityPerUnit> getAllQuantityPerUnit()
        {
            var list = (from m in db.donViTinhs
                           select m).ToList();
            List<eQuantityPerUnit> ls = new List<eQuantityPerUnit>();
            foreach (var m in list)
            {
                eQuantityPerUnit e = new eQuantityPerUnit();
                e.Id = m.maDVT.ToString();
                e.Name = m.tenDVT;

                ls.Add(e);
            }
            return ls;
        }

        //Kiểm tra mã đơn vị tính có tồn tại 
        public bool checkIDExist(string id)
        {
            donViTinh emp = db.donViTinhs.Where(x => x.maDVT.ToString() == id).FirstOrDefault();
            if (emp != null)
                return true;
            return false;
        }

        //Nhập đơn vị tính mới vào database
        public int insertQuantityPerUnit(eQuantityPerUnit q)
        {
            if (checkIDExist(q.Id))
                return 0;

            donViTinh temp = new donViTinh();

            temp.maDVT = q.Id;
            temp.tenDVT = q.Name;

            db.donViTinhs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        //Xóa đơn vị tính khỏi database
        public bool deleteQuantityPerUnit(string id)
        {
            donViTinh q = db.donViTinhs.Where(x => x.maDVT.ToString() == id).FirstOrDefault();
            if (q != null)
            {
                db.donViTinhs.DeleteOnSubmit(q);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        //Sửa thông tin đơn vị tính
        public void updateQuantityPerUnit(eQuantityPerUnit q)
        {
            donViTinh temp = db.donViTinhs.Where(x => x.maDVT.ToString().Equals(q.Id)).FirstOrDefault();

            // Cập nhật dữ liệu
            temp.maDVT = q.Id;
            temp.tenDVT = q.Name;

            db.SubmitChanges();
        }
    }
}
