using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dCountry
    {
        DrugStoreDataContext db;

        public dCountry()
        {
            db = new DrugStoreDataContext();
        }

        //Lấy toàn bộ quốc gia có trong database
        public List<eCountry> getAllCountry()
        {
            var list = (from m in db.nuocs
                        orderby m.tenNuoc //Sắp xếp
                        select m ).ToList();
            List<eCountry> ls = new List<eCountry>();
            foreach (var m in list)
            {
                eCountry e = new eCountry();
                e.Id = m.maNuoc.ToString();
                e.Name = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }

        //Kiểm tra mã quốc gia có tồn tại 
        public bool checkIDExist(string id)
        {
            nuoc emp = db.nuocs.Where(x => x.maNuoc.ToString() == id).FirstOrDefault();
            if (emp != null)
                return true;
            return false;
        }

        //Nhập quốc gia mới vào database
        public int insertCountry(eCountry q)
        {
            if (checkIDExist(q.Id))
                return 0;

            nuoc temp = new nuoc();

            temp.maNuoc = q.Id;
            temp.tenNuoc = q.Name;

            db.nuocs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        //Xóa quốc gia khỏi database
        public bool deleteCountry(string id)
        {
            nuoc q = db.nuocs.Where(x => x.maNuoc.ToString() == id).FirstOrDefault();
            if (q != null)
            {
                db.nuocs.DeleteOnSubmit(q);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        //Sửa thông tin quốc gia
        public void updateCountry(eCountry q)
        {
            nuoc temp = db.nuocs.Where(x => x.maNuoc.ToString().Equals(q.Id)).FirstOrDefault();

            // Cập nhật dữ liệu
            temp.maNuoc = q.Id;
            temp.tenNuoc = q.Name;

            db.SubmitChanges();
        }
    }
}
