using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Business_Tier;

namespace DOAN_PTUD_DRUGSTORE_MANAGER_NHOM9
{
    public partial class frmBillManager : Form
    {
        bBill bB;
        public frmBillManager()
        {
            InitializeComponent();
        }
        private void frmBillManager_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bB = new bBill();
            btnSave.Enabled = false;
            label2.Text = "";

            //Load dữ liệu datagridview
            dgvBillList.DataSource = bB.getAllBill();
            FormatDataGridview();

            setOnOffEditTextbox(0);

        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvBillList.SelectedRows.Count > 0)
            {
                txtBillID.Text = dgvBillList.SelectedRows[0].Cells[0].Value.ToString();
                txtOrderDate.Text = dgvBillList.SelectedRows[0].Cells[1].Value.ToString();
                txtCusID.Text = dgvBillList.SelectedRows[0].Cells[2].Value.ToString();
                txtEmID.Text = dgvBillList.SelectedRows[0].Cells[3].Value.ToString();
            }
        }
        void FormatDataGridview()
        {
            dgvBillList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(99, 29, 119);
            dgvBillList.EnableHeadersVisualStyles = false;

            dgvBillList.Columns[0].HeaderText = "Mã HĐ";
            dgvBillList.Columns[1].HeaderText = "Ngày lập HĐ";
            dgvBillList.Columns[1].Width = 150;
            dgvBillList.Columns[2].HeaderText = "Tên KH";
            dgvBillList.Columns[2].Width = 200;
            dgvBillList.Columns[3].HeaderText = "Tên NV";
            dgvBillList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        /*Lựa chọn khi nào người dùng được edit textbox
          0 : textbox ở chế độ đọc, không thể chỉnh sửa
          1 : textbox ở chế độ chỉnh sửa
        */
        public void setOnOffEditTextbox(int c)
        {
            if (c == 0)
            {
                txtBillID.ReadOnly = true;
                txtBillID.BackColor = System.Drawing.SystemColors.Window;//set màu trắng cho textbox khi dùng ReadOnly
                txtOrderDate.ReadOnly = true;
                txtOrderDate.BackColor = System.Drawing.SystemColors.Window;
                txtCusID.ReadOnly = true;
                txtCusID.BackColor = System.Drawing.SystemColors.Window;
                txtEmID.ReadOnly = true;
                txtEmID.BackColor = System.Drawing.SystemColors.Window;
            }
            else if (c == 1)
            {
                txtBillID.ReadOnly = false;
                txtOrderDate.ReadOnly = false;
                txtCusID.ReadOnly = false;
                txtEmID.ReadOnly = false;
            }
        }      

        private void btnSave_Click(object sender, EventArgs e)
        {
            eCustomer cus = new eCustomer();

            cus.CustomerID = txtBillID.Text;
            cus.CustomerName = txtOrderDate.Text;
            cus.Address = txtCusID.Text;
            cus.Phone = txtEmID.Text;

            //bB.updateCustomer(cus);

            btnSave.Enabled = false;
            btnSave.Text = "Lưu";
            btnSave.BackColor = Color.Gainsboro;
            btnUpdate.Text = "Sửa";
            btnUpdate.BackColor = Color.Gainsboro;
            label2.Text = "";
            setOnOffEditTextbox(0);

            MessageBox.Show("Cập nhập hóa đơn thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvBillList.DataSource = bB.getAllBill();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa hoá đơn này ?",
                "Xóa HĐ", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bB.deleteBill(int.Parse(txtBillID.Text));
                if (result == true)
                {
                    dgvBillList.DataSource = bB.getAllBill();
                }
                else
                {
                    MessageBox.Show("Lỗi !");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!btnUpdate.Text.Equals("Hủy"))
            {
                btnSave.Enabled = true;
                btnSave.Text = "Lưu sửa";
                btnSave.BackColor = Color.FromArgb(109, 255, 84);
                btnUpdate.Text = "Hủy";
                btnUpdate.BackColor = Color.FromArgb(255, 68, 78);
                label2.Text = "*Cập nhập thông tin hóa đơn";
                setOnOffEditTextbox(1);
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnUpdate.Text = "Sửa";
                btnUpdate.BackColor = Color.Gainsboro;
                label2.Text = "";
                setOnOffEditTextbox(0);
            }
        }

        private void dgvEmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEmpList_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvBillList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Text = "CHỨC NĂNG QUẢN LÝ";

            string id = dgvBillList.SelectedRows[0].Cells[0].Value.ToString();
            string orderDate = dgvBillList.SelectedRows[0].Cells[1].Value.ToString();
            string cusID = dgvBillList.SelectedRows[0].Cells[2].Value.ToString();
            string empID = dgvBillList.SelectedRows[0].Cells[3].Value.ToString();

            frmBillDetail frm = new frmBillDetail(id,orderDate,cusID,empID);
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
