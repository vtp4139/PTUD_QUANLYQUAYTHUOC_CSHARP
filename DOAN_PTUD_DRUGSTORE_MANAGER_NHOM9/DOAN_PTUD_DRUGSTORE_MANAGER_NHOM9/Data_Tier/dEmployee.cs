using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dEmployee
    {
        DrugStoreDataContext db;
        public dEmployee()
        {
            db = new DrugStoreDataContext();
        }

        //Lấy toàn bộ nhân viên có trong database
        public List<eEmployee> getAllEmployee()
        {
            //var listMed = db.Products.ToList();

            var listEmpl = (from m in db.nhanViens
                           join t in db.loaiNhanViens on m.maLoaiNV equals t.maLoaiNV //Lấy tên của loại nhân viên
                           orderby m.tenNV
                           select new
                           {
                               m.maNV,
                               m.tenNV,
                               m.diaChi,
                               m.dienThoai,
                               t.tenLoaiNV,
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
        }      

        //Lấy toàn bộ tên của loại nhân viên để load lên combobox
        public List<string> getAllTypeName()
        {
            var ds = db.loaiNhanViens.ToList();
            List<string> ls = new List<string>();
            foreach (loaiNhanVien ncc in ds)
            {
                ls.Add(ncc.tenLoaiNV);
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

        //Lấy mã loại từ tên loại đã nhập
        public string getIDType(string name)
        {
            loaiNhanVien lnv = db.loaiNhanViens.Where(x => x.tenLoaiNV == name).FirstOrDefault();
            if (lnv != null)
                return lnv.maLoaiNV;
            return null;
        }

        //Nhập nhân viên mới vào database
        public int insertEmployee(eEmployee emp)
        {
            if (checkIDExist(emp.EmployeeID))
                return 0;

            nhanVien emptemp = new nhanVien();

            emptemp.maNV = emp.EmployeeID;
            emptemp.tenNV = emp.EmployeeName;
            emptemp.diaChi = emp.Address;
            emptemp.dienThoai = emp.Phone;
            emptemp.maLoaiNV = getIDType(emp.EmployeeType); // Lưu mã của loại nhân viên

            db.nhanViens.InsertOnSubmit(emptemp);
            db.SubmitChanges();
            return 1;
        }

        //Xóa nhân viên khỏi database
        public bool deleteEmployee(string id)
        {
            nhanVien emp = db.nhanViens.Where(x => x.maNV == id).FirstOrDefault();
            if (emp != null)
            {
                db.nhanViens.DeleteOnSubmit(emp);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        //Sửa thông tin nhân viên
        public void updateEmployee(eEmployee emp)
        {
            nhanVien emptemp = db.nhanViens.Where(x => x.maNV.Equals(emp.EmployeeID)).FirstOrDefault();

            // Cập nhật dữ liệu
            emptemp.maNV = emp.EmployeeID;
            emptemp.tenNV = emp.EmployeeName;
            emptemp.diaChi = emp.Address;
            emptemp.dienThoai = emp.Phone;
            emptemp.maLoaiNV = getIDType(emp.EmployeeType); // Lưu mã của loại nhân viên

            db.SubmitChanges();
        }
        public eEmployee getEmployeeFromID(string id)
        {
            nhanVien m = db.nhanViens.Where(x => x.maNV == id).FirstOrDefault();

            eEmployee e = new eEmployee();
            e.EmployeeID = m.maNV;
            e.EmployeeName = m.tenNV;
            e.Address = m.diaChi;
            e.Phone = m.dienThoai;

            return e;
        }

    }
}
