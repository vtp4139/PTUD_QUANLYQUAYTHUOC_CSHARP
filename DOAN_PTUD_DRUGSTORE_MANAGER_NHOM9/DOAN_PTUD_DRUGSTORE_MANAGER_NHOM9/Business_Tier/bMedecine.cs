using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data_Tier;

namespace Business_Tier
{
    public class bMedecine
    {
        dMedicine eMed;
        public bMedecine()
        {
            eMed = new dMedicine();
        }
        //lấy thông qua tầng
        public List<eMedicine> getAllMedecine()
        {
            return eMed.getAllMedecine();
        }
        public List<string> getAllSupplierName()
        {
            return eMed.getAllSupplierName();
        }
        public List<string> getAllCategoriesName()
        {
            return eMed.getAllCategoriesName();
        }
        public int insertMedecine(eMedicine med)
        {
            return eMed.insertMedecine(med);
        }
        public bool deleteMedecine(string id)
        {
            return eMed.deleteMedecine(id);
        }
        public void updateMedecine(eMedicine med)
        {
            eMed.updateMedecine(med);
        }
        public List<eMedicine> sortByMedecineName()
        {       
            return eMed.sortByMedecineQuantityDes();
        }
        public List<eMedicine> sortByMedecinePriceInc()
        { 
            return eMed.sortByMedecinePriceInc();
        }
        public List<eMedicine> sortByMedecinePriceDes()
        {
            return eMed.sortByMedecinePriceDes();
        }
        public List<eMedicine> sortByMedecineUnit()
        {
            return eMed.sortByMedecineUnit();
        }
        public List<eMedicine> getMedecineByCategories(string cate)
        {
            return eMed.getMedecineByCategories(cate);
        }
        public List<eMedicine> getMedecineBySupplier(string sup)
        {
            return eMed.getMedecineBySupplier(sup);
        }
        public List<eMedicine> getMedecineBySupplierAndCategory(string sup, string cate)
        {
            return eMed.getMedecineBySupplierAndCategory(sup, cate);
        }
        public List<eMedicine> getExpiredMedecine()
        {
            return eMed.getExpiredMedecine();
        }
        public List<eMedicine> getNearlyExpiredMedecine()
        {
            return eMed.getNearlyExpiredMedecine();
        }
        public List<string> getAllQuantityPerUnitName()
        {
            return eMed.getAllQuantityPerUnitName();
        }
        public List<string> getAllCountryName()
        {
            return eMed.getAllCountryName();
        }
    }
}
