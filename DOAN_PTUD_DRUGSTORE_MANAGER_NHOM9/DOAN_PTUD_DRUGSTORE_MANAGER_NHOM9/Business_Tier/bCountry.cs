using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data_Tier;

namespace Business_Tier
{
    public class bCountry
    {
        dCountry dCou;

        public bCountry()
        {
            dCou = new dCountry();
        }

        public List<eCountry> getAllCountry()
        {
            return dCou.getAllCountry();
        }

        public int insertCountry(eCountry c)
        {
            return dCou.insertCountry(c);
        }

        public bool deleteCountry(string id)
        {
            return dCou.deleteCountry(id);
        }

        public void updateCountry(eCountry c)
        {
            dCou.updateCountry(c);
        }
    }
}
