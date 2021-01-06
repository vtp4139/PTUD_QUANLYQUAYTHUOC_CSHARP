using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Tier;
using Entities;

namespace Business_Tier
{
    public class bBill
    {
        dBill dB;

        public bBill()
        {
            dB = new dBill();
        }

        public List<eBill> getAllBill()
        {
            return dB.getAllBill();
        }
        public int insertOrders(eBill or) //Thêm hóa đơn
        {
            return dB.insertOrders(or);
        }
        public bool deleteBill(int id)
        {
            return dB.deleteBill(id);
        }
        public int subtractQuantity(string id, int quantity)
        {
            return dB.subtractQuantity(id, quantity);
        }

        public int addQuantity(string id, int quantity)
        {
            return dB.addQuantity(id, quantity);
        }
        //thong ke theo thang
        public List<eBill> orderStatistic_M(DateTime date)
        {
            return dB.orderStatistic_M(date);
        }
        public List<eBill> orderStatistic_Y(DateTime date)
        {
            return dB.orderStatistic_Y(date);
        }
        public eBill getBillFromID(int id)
        {
            return dB.getBillFromID(id);
        }
    }
}
