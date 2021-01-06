using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Tier;
using Entities;

namespace Business_Tier
{    
    public class bCustomer
    {
        dCustomer dCus;
        public bCustomer()
        {
            dCus = new dCustomer();
        }
        public List<eCustomer> getAllCustomer()
        {
            return dCus.getAllCustomer();
        }
        public int insertCustomer(eCustomer cus)
        {
            return dCus.insertCustomer(cus);
        }
        public bool deleteCustomer(string id)
        {
            return dCus.deleteCustomer(id);
        }
        public void updateCustomer(eCustomer cus)
        {
            dCus.updateCustomer(cus);
        }
    }
}
