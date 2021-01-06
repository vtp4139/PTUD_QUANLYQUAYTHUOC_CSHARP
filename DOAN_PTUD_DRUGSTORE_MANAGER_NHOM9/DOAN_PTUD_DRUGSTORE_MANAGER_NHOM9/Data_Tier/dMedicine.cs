using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data_Tier
{
    public class dMedicine
    {
        DrugStoreDataContext db;
        public dMedicine()
        {
            db = new DrugStoreDataContext();
        }

        #region LOAD DANH SÁCH THUỐC

        //LOAD DỮ LIỆU THUỐC
        //------------------------------------------------------------------------------------
        //Lấy toàn bộ thuốc có trong database
        public List<eMedicine> getAllMedecine()
        {
            //var listMed = db.Products.ToList();

            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           orderby m.tenThuoc
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();
            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;                
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }

        public List<eMedicine> getMedecineByCategories(string cate)
        {
            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           where t.tenLoai == cate
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();
            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }
        public List<eMedicine> getMedecineBySupplier(string sup)
        {
            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           where s.tenNCC == sup
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();
            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }
        public List<eMedicine> getMedecineBySupplierAndCategory(string sup, string cate)
        {
            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           where s.tenNCC == sup && t.tenLoai == cate
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();
            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }

        public List<eMedicine> getExpiredMedecine()
        {
            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           where m.hanSuDung < DateTime.Now
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();
            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }
        public List<eMedicine> getNearlyExpiredMedecine()
        {
            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           where m.hanSuDung.Value.Month - DateTime.Now.Month == 1 && m.hanSuDung.Value.Year == DateTime.Now.Year
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();
            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }
        #endregion

        #region SẮP XẾP
        /*
         *--------------------SẮP XẾP---------------------------------
         * 1.SẮP XẾP THEO TÊN
         * 2.SẮP XẾP THEO ĐƠN GIÁ GIẢM
         * 3.SẮP XẾP THEO ĐƠN GIÁ TĂNG
         * 4.SẮP XẾP THEO SỐ LƯỢNG 
         */
        public List<eMedicine> sortByMedecineQuantityDes() //(1)
        {
            //var listMed = db.Products.ToList();

            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           orderby m.slTon descending //Sắp xếp
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();

            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }

        public List<eMedicine> sortByMedecinePriceInc() //(2)
        {
            //var listMed = db.Products.ToList();

            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           orderby m.giaGoc
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();

            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }
        public List<eMedicine> sortByMedecinePriceDes() //(3)
        {
            //var listMed = db.Products.ToList();

            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           orderby m.giaGoc descending
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();

            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }
        public List<eMedicine> sortByMedecineUnit() //(4)
        {
            //var listMed = db.Products.ToList();

            var listMed = (from m in db.thuocs
                           join t in db.loaiThuocs on m.maLoai equals t.maLoai //Lấy tên của loại thuốc
                           join s in db.nhaCungCaps on m.maNCC equals s.maNCC  //Lấy tên của loại NCC
                           join d in db.donViTinhs on m.maDVT equals d.maDVT  //Lấy tên của DVT
                           join n in db.nuocs on m.maNuoc equals n.maNuoc  //Lấy tên của nước 
                           orderby m.slTon
                           select new
                           {
                               m.maThuoc,
                               m.tenThuoc,
                               m.donViTinh,
                               m.slTon,
                               m.giaGoc,
                               m.giaBan,
                               m.moTa,
                               m.hanSuDung,
                               t.tenLoai,
                               s.tenNCC,
                               d.tenDVT,
                               n.tenNuoc
                           }
                              ).ToList();

            List<eMedicine> ls = new List<eMedicine>();
            foreach (var m in listMed)
            {
                eMedicine e = new eMedicine();
                e.MedicineID = m.maThuoc;
                e.MedicineName = m.tenThuoc;
                e.CategoryName = m.tenLoai;
                e.Quantity = m.tenDVT;
                e.UnitsInStock = (int)m.slTon;
                e.Price = (double)m.giaGoc;
                e.SellPrice = (double)m.giaBan;
                e.SupplierName = m.tenNCC;
                e.Describe = m.moTa;
                e.Exp = m.hanSuDung.Value;
                e.Country = m.tenNuoc;

                ls.Add(e);
            }
            return ls;
        }
        //--------------------------------------------------------------------------------------

        #endregion

        #region XỬ LÝ
        //Lấy toàn bộ tên của nhà cung cấp để load lên combobox
        public List<string> getAllSupplierName()
        {
            var ds = db.nhaCungCaps.ToList();
            List<string> ls = new List<string>();
            foreach (nhaCungCap ncc in ds)
            {
                ls.Add(ncc.tenNCC);
            }
            return ls;
        }
        //Lấy toàn bộ tên của loại thuốc để load lên combobox
        public List<string> getAllCategoriesName()
        {
            var ds = db.loaiThuocs.ToList();
            List<string> ls = new List<string>();
            foreach (loaiThuoc lt in ds)
            {
                ls.Add(lt.tenLoai);
            }
            return ls;
        }
        public List<string> getAllQuantityPerUnitName()
        {
            var ds = db.donViTinhs.ToList();
            List<string> ls = new List<string>();
            foreach (donViTinh lt in ds)
            {
                ls.Add(lt.tenDVT);
            }
            return ls;
        }
        public List<string> getAllCountryName()
        {
            var ds = db.nuocs.ToList();
            List<string> ls = new List<string>();
            foreach (nuoc lt in ds)
            {
                ls.Add(lt.tenNuoc);
            }
            return ls;
        }

        //Kiểm tra mã thuốc có tồn tại 
        public bool checkIDExist(string id)
        {
            thuoc mttemp = db.thuocs.Where(x => x.maThuoc == id).FirstOrDefault();
            if (mttemp != null)
                return true;
            return false;
        }

        //Lấy mã loại từ tên loại đã nhập
        public string getIDCategory(string name)
        {
            loaiThuoc ct = db.loaiThuocs.Where(x => x.tenLoai == name).FirstOrDefault();
            if (ct != null)
                return ct.maLoai;
            return null;
        }
        //Lấy mã loại từ tên loại đã nhập
        public int getIDSupplier(string name)
        {
            nhaCungCap sp = db.nhaCungCaps.Where(x => x.tenNCC == name).FirstOrDefault();
            if (sp != null)
                return sp.maNCC;
            return -1;
        }

        //Nhập thuốc mới vào database
        public int insertMedecine(eMedicine med)
        {
            if (checkIDExist(med.MedicineID))
                return 0;

            thuoc medtemp = new thuoc();

            medtemp.maThuoc = med.MedicineID;
            medtemp.tenThuoc = med.MedicineName;
           // medtemp.donViTinh = med.Quantity;
            medtemp.giaGoc = (decimal)med.Price;
            medtemp.slTon = med.UnitsInStock;
            medtemp.maLoai = getIDCategory(med.CategoryName); // Lưu mã của loại thuốc
            medtemp.maNCC = getIDSupplier(med.SupplierName); // Lưu mã của nhà cung cấp
            medtemp.hanSuDung = med.Exp;
            medtemp.moTa = med.Describe;

            db.thuocs.InsertOnSubmit(medtemp);
            db.SubmitChanges();
            return 1;
        }

        //Xóa thuốc khỏi database
        public bool deleteMedecine(string id)
        {
            thuoc med = db.thuocs.Where(x => x.maThuoc == id).FirstOrDefault();
            if (med != null)
            {
                db.thuocs.DeleteOnSubmit(med);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        //Sửa thông tin thuốc
        public void updateMedecine(eMedicine med)
        {
            thuoc medUpdate = db.thuocs.Where(x => x.maThuoc.Equals(med.MedicineID)).FirstOrDefault();

            // Cập nhật dữ liệu
            medUpdate.maThuoc = med.MedicineID;
            medUpdate.tenThuoc = med.MedicineName;
            //medUpdate.donViTinh = med.Quantity;
            medUpdate.giaGoc = (decimal)med.Price;
            medUpdate.slTon = med.UnitsInStock;
            medUpdate.maLoai = getIDCategory(med.CategoryName); // Lưu mã của loại thuốc
            medUpdate.maNCC = getIDSupplier(med.SupplierName); // Lưu mã của nhà cung cấp
            medUpdate.hanSuDung = med.Exp;
            medUpdate.moTa = med.Describe;

            db.SubmitChanges();
        }
        #endregion
    }
}
