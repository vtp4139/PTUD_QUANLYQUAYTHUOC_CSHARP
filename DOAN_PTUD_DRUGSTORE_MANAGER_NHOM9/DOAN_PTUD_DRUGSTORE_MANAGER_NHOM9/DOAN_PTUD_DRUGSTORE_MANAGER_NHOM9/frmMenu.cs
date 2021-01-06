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
    public partial class frmMenu : Form
    {
        string EmpID = "";
        bEmployee bEmp;
        eEmployee emp;
        public frmMenu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public frmMenu(string empId)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            EmpID = empId;
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.Text = "CHƯƠNG TRÌNH QUẢN LÝ QUẦY THUỐC - NHÓM 9";

            bEmp = new bEmployee();
            emp = bEmp.getEmployeeFromID(EmpID);     

            tàiKhoảnToolStripMenuItem.Text = emp.EmployeeName;

            //PHÂN QUYỀN NGƯỜI DÙNG
            if (EmpID.Contains("BH"))
            {
                CateToolStripMenuItem.Visible = false;
                thongToolStripMenuItem.Visible = false;
            }
            else if (EmpID.Contains("QL"))
            {
                xửLýToolStripMenuItem.Visible = false;
                thongToolStripMenuItem.Visible = false;
            }
            else if (EmpID.Contains("TK"))
            {
                xửLýToolStripMenuItem.Visible = false;
                CateToolStripMenuItem.Visible = false;
            }
        }
        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CateToolStripMenuItem.BackColor = Color.Gainsboro;
            this.Text = "CHỨC NĂNG QUẢN LÝ";
            frmDrugManager frm = new frmDrugManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG QUẢN LÝ";
            frmEmployeeManager frm = new frmEmployeeManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG QUẢN LÝ";
            frmCustomerManager frm = new frmCustomerManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        private void menuChucNang_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tìmKiếmThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG TÌM KIẾM";
            frmDrugSearch frm = new frmDrugSearch();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void tìmKiếmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG TÌM KIẾM";
            frmEmployeeSearch frm = new frmEmployeeSearch();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void tìmKiếmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG TÌM KIẾM";
            frmCustomerSearch frm = new frmCustomerSearch();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }    

        private void bánThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG BÁN HÀNG";
            frmDrugSell frm = new frmDrugSell(EmpID);
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG QUẢN LÝ";
            frmSupplierManager frm = new frmSupplierManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "THÔNG TIN TÀI KHOẢN";
            frmAccountDetails frm = new frmAccountDetails(EmpID);
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG QUẢN LÝ";
            frmBillManager frm = new frmBillManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void nhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG TÌM KIẾM";
            frmSupplierSearch frm = new frmSupplierSearch();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "THỐNG KÊ";
            frmIncomeStatistics frm = new frmIncomeStatistics();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void thuốcHếtHạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "THỐNG KÊ";
            frmExpiredDrugsStatistics frm = new frmExpiredDrugsStatistics();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG QUẢN LÝ";
            frmQuantityPerUnit frm = new frmQuantityPerUnit();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void quốcGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CHỨC NĂNG QUẢN LÝ";
            frmCountry frm = new frmCountry();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new frmLogin();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
