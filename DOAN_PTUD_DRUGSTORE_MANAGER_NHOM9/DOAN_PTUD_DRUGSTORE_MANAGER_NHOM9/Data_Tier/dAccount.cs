using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tier
{
    public class dAccount
    {
        DrugStoreDataContext db;
        public dAccount()
        {
            db = new DrugStoreDataContext();
        }
        public bool checkIDExist(string id, string pass)
        {
            taiKhoan temp = db.taiKhoans.Where(x => x.maNV == id && x.matKhau == pass).FirstOrDefault();
            if (temp != null)
                return true;
            return false;
        }
    }
}
