using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Tier;
using Entities;

namespace DOAN_PTUD_DRUGSTORE_MANAGER_NHOM9
{
    public partial class frmAccountDetails : Form
    {
        bEmployee bEmp;
        eEmployee eEmp;
        string EmpID = "";
        public frmAccountDetails()
        {
            InitializeComponent();
        }
        public frmAccountDetails(string empID)
        {
            InitializeComponent();
            EmpID = empID;
        }
        private void frmAccountDetails_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblName;

            txtName.ReadOnly = true;
            txtName.BackColor = System.Drawing.SystemColors.Window;
            txtPhone.ReadOnly = true;
            txtPhone.BackColor = System.Drawing.SystemColors.Window;
            txtAddress.ReadOnly = true;
            txtAddress.BackColor = System.Drawing.SystemColors.Window;
            txtID.ReadOnly = true;
            txtID.BackColor = System.Drawing.SystemColors.Window;

            bEmp = new bEmployee();
            eEmp = new eEmployee();
            eEmp = bEmp.getEmployeeFromID(EmpID);           

            lblName.Text = eEmp.EmployeeName;
            txtName.Text = eEmp.EmployeeName;
            txtPhone.Text = eEmp.Phone;
            txtAddress.Text = eEmp.Address;
            txtID.Text = eEmp.EmployeeID;
        }             
    }
}
