using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Tier;
using Entities;

namespace Business_Tier
{
    public class bSupplier
    {
        dSupplier dSup;

        public bSupplier()
        {
            dSup = new dSupplier();
        }

        public List<eSupplier> getAllSupplier()
        {
            return dSup.getAllSupplier();
        }

        public int insertSupplier(eSupplier sup)
        {
            return dSup.insertSupplier(sup);
        }

        public bool deleteSupplier(string id)
        {
            return dSup.deleteSupplier(id);
        }

        public void updateSupplier(eSupplier sup)
        {
            dSup.updateSupplier(sup);
        }
    }
}
