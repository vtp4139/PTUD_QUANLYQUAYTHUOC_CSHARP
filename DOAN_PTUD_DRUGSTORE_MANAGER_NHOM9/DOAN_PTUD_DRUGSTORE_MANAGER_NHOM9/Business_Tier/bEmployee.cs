using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data_Tier;

namespace Business_Tier
{
    public class bEmployee
    {
        dEmployee dEmpl;

        public bEmployee()
        {
            dEmpl = new dEmployee();
        }
        public List<eEmployee> getAllEmployee()
        {
            return dEmpl.getAllEmployee();
        }
        public List<string> getAllTypeName()
        {
            return dEmpl.getAllTypeName();
        }
        public int insertEmployee(eEmployee emp)
        {
            return dEmpl.insertEmployee(emp);
        }
        public bool deleteEmployee(string id)
        {
            return dEmpl.deleteEmployee(id);
        }
        public void updateEmployee(eEmployee emp)
        {
            dEmpl.updateEmployee(emp);
        }
        public eEmployee getEmployeeFromID(string id)
        {
            return dEmpl.getEmployeeFromID(id);
        }
    }
}
