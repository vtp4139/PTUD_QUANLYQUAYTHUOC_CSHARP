using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Tier;
using Entities;

namespace Business_Tier
{
    public class bBillDetail
    {
        dBillDetail dBD;

        public bBillDetail()
        {
            dBD = new dBillDetail();
        }
        public int insertOrderDetail(List<eBillDetail> list)
        {
            return dBD.insertOrderDetail(list);
        }
        public List<eBillDetail> getAllBillDetail(int i)
        {           
            return dBD.getAllBillDetail(i);
        }
        public double totalMoney(int billID)
        {
            return dBD.totalMoney(billID);
        }
    }
}
