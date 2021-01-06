using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data_Tier;

namespace Business_Tier
{
    public class bQuantityPerUnit
    {
        dQuantityPerUnit dquan;

        public bQuantityPerUnit()
        {
            dquan = new dQuantityPerUnit();
        }

        public List<eQuantityPerUnit> getAllQuantityPerUnit()
        {
            return dquan.getAllQuantityPerUnit();
        }

        public int insertQuantityPerUnit(eQuantityPerUnit q)
        {
            return dquan.insertQuantityPerUnit(q);
        }

        public bool deleteQuantityPerUnit(string id)
        {
            return dquan.deleteQuantityPerUnit(id);
        }

        public void updateQuantityPerUnit(eQuantityPerUnit q)
        {
            dquan.updateQuantityPerUnit(q);
        }
    }
}
