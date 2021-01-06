using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data_Tier;

namespace Business_Tier
{
    public class bAccount
    {
        dAccount dAcc;

        public bAccount()
        {
            dAcc = new dAccount();
        }
        public bool checkIDExist(string id, string pass)
        {
            return dAcc.checkIDExist(id, pass);
        }
    }
}
