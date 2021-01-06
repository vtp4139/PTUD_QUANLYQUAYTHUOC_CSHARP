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
    public partial class frmBillDetail : Form
    {
        string billID, CusID, EmpID, OrderDate;
        bBillDetail bBD;
        bBill bB;
        public frmBillDetail()
        {
            InitializeComponent();
        }
        public frmBillDetail(string id, string orderDate, string cusID, string empID)
        {
            InitializeComponent();
            billID = id;
            CusID = cusID;
            EmpID = empID;
            OrderDate = orderDate;
        }
        private void frmBillDetail_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            bBD = new bBillDetail();
            bB = new bBill();

            dgvBillDetail.DataSource = bBD.getAllBillDetail(int.Parse(billID));
            loadDataToTextbox();
            FormatDataGridview();
        }

        public void loadDataToTextbox()
        {
            txtBillId.Text = billID;
            txtCustomerID.Text = CusID;
            txtEmployeeID.Text = EmpID;
            txtOrderDate.Text = OrderDate;
        }

        void FormatDataGridview()
        {
            dgvBillDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(99, 29, 119);
            dgvBillDetail.EnableHeadersVisualStyles = false;

            dgvBillDetail.Columns[0].HeaderText = "Mã HĐ";
            dgvBillDetail.Columns[1].HeaderText = "Tên thuốc";
            dgvBillDetail.Columns[1].Width = 400;
            dgvBillDetail.Columns[2].HeaderText = "Số lượng";
            dgvBillDetail.Columns[2].Width = 150;
            dgvBillDetail.Columns[3].HeaderText = "Đơn giá";
            dgvBillDetail.Columns[3].Width = 250;
            dgvBillDetail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
