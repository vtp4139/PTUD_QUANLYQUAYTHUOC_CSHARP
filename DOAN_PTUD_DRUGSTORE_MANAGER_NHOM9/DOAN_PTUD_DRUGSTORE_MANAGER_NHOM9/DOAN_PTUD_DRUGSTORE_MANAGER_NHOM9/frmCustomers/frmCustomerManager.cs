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
    public partial class frmCustomerManager : Form
    {
        bCustomer bCus;
        public frmCustomerManager()
        {
            InitializeComponent();
        }
        private void frmCustomerManager_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bCus = new bCustomer();
            btnSave.Enabled = false;
            label2.Text = "";

            //Load dữ liệu datagridview
            dgvCusList.DataSource = bCus.getAllCustomer();
            FormatDataGridview();

            setOnOffEditTextbox(0);

        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCusList.SelectedRows.Count > 0)
            {
                txtCusID.Text = dgvCusList.SelectedRows[0].Cells[0].Value.ToString();
                txtCusName.Text = dgvCusList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvCusList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvCusList.SelectedRows[0].Cells[3].Value.ToString();
            }
        }
        void FormatDataGridview()
        {
             dgvCusList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(183, 71, 42);
             dgvCusList.EnableHeadersVisualStyles = false;

             dgvCusList.Columns[0].HeaderText = "Mã KH";
             dgvCusList.Columns[1].HeaderText = "Tên khách hàng";
             dgvCusList.Columns[1].Width = 150;
             dgvCusList.Columns[2].HeaderText = "Địa chỉ";
             dgvCusList.Columns[2].Width = 250;
             dgvCusList.Columns[3].HeaderText = "Số điện thoại";
             dgvCusList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        /*Lựa chọn khi nào người dùng được edit textbox
          0 : textbox ở chế độ đọc, không thể chỉnh sửa
          1 : textbox ở chế độ chỉnh sửa
        */
        public void setOnOffEditTextbox(int c)
        {
            if (c == 0)
            {
                txtCusID.ReadOnly = true;
                txtCusID.BackColor = System.Drawing.SystemColors.Window;//set màu trắng cho textbox khi dùng ReadOnly
                txtCusName.ReadOnly = true;
                txtCusName.BackColor = System.Drawing.SystemColors.Window;
                txtAddress.ReadOnly = true;
                txtAddress.BackColor = System.Drawing.SystemColors.Window;
                txtPhone.ReadOnly = true;
                txtPhone.BackColor = System.Drawing.SystemColors.Window;
            }
            else if (c == 1)
            {
                txtCusID.ReadOnly = false;
                txtCusName.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtPhone.ReadOnly = false;
            }
        }

        void clearTextbox()
        {
            txtCusID.Text = "";
            txtCusName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            clearTextbox();
            if (!btnNew.Text.Equals("Hủy"))
            {
                btnSave.Enabled = true;
                btnSave.Text = "Lưu thêm";
                btnSave.BackColor = Color.FromArgb(36, 187, 116);
                btnNew.Text = "Hủy";
                btnNew.BackColor = Color.FromArgb(231, 62, 52);
                label2.Text = "*Nhập thông tin khách hàng mới";
                setOnOffEditTextbox(1);


                btnSave.ForeColor = Color.White;
                btnNew.ForeColor = Color.White;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnNew.Text = "Thêm";
                btnNew.BackColor = Color.Gainsboro;
                label2.Text = "";
                setOnOffEditTextbox(0);

                btnSave.ForeColor = Color.Black;
                btnNew.ForeColor = Color.Black;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCusID.Text.Length == 0 || txtCusName.Text.Length == 0 || txtPhone.Text.Length == 0 || txtAddress.Text.Length == 0 )
            {
                MessageBox.Show("Không chừa trống dữ liệu nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCusID.Text.KiemTraMaKhachHang() == false)
            {
                MessageBox.Show("Mã nhân viên có định dạng:KHXXX với X là số !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            eCustomer cus = new eCustomer();

            cus.CustomerID = txtCusID.Text;
            cus.CustomerName = txtCusName.Text;
            cus.Address = txtAddress.Text;
            cus.Phone = txtPhone.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    int result = bCus.insertCustomer(cus);
                    if (result == 1)
                    {
                        clearTextbox();

                        btnSave.Enabled = false;
                        btnSave.Text = "Lưu";
                        btnSave.BackColor = Color.Gainsboro;
                        btnNew.Text = "Thêm";
                        btnNew.BackColor = Color.Gainsboro;
                        label2.Text = "";
                        setOnOffEditTextbox(0);

                        btnSave.ForeColor = Color.Black;
                        btnNew.ForeColor = Color.Black;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;

                        MessageBox.Show("Thêm khách hàng mới thành công !", "Thêm thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCusList.DataSource = bCus.getAllCustomer();
                    }
                    else
                        MessageBox.Show("Mã khách hàng bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                bCus.updateCustomer(cus);

                btnSave.Enabled = false;
                btnSave.Text = "Lưu";
                btnSave.BackColor = Color.Gainsboro;
                btnUpdate.Text = "Sửa";
                btnUpdate.BackColor = Color.Gainsboro;
                label2.Text = "";
                setOnOffEditTextbox(0);

                btnSave.ForeColor = Color.Black;
                btnUpdate.ForeColor = Color.Black;
                btnNew.Enabled = true;
                btnDelete.Enabled = true;

                MessageBox.Show("Cập nhập khách hàng thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCusList.DataSource = bCus.getAllCustomer();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này ?",
                "Xóa KH", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bCus.deleteCustomer(txtCusID.Text);
                if (result == true)
                {
                    dgvCusList.DataSource = bCus.getAllCustomer();
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
                btnSave.BackColor = Color.FromArgb(36, 187, 116);
                btnUpdate.Text = "Hủy";
                btnUpdate.BackColor = Color.FromArgb(231, 62, 52);
                label2.Text = "*Cập nhập thông tin khách hàng";
                setOnOffEditTextbox(1);

                btnSave.ForeColor = Color.White;
                btnUpdate.ForeColor = Color.White;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
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

                btnSave.ForeColor = Color.Black;
                btnUpdate.ForeColor = Color.Black;
                btnNew.Enabled = true;
                btnDelete.Enabled = true;
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
    }
}
