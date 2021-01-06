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
    public partial class frmSupplierManager : Form
    {
        bSupplier bSup;
        public frmSupplierManager()
        {
            InitializeComponent();
        }
        private void frmSupplierManager_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bSup = new bSupplier();
            btnSave.Enabled = false;
            label2.Text = "";

            //Load dữ liệu datagridview
            dgvSupList.DataSource = bSup.getAllSupplier();
            FormatDataGridview();

            setOnOffEditTextbox(0);

        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvSupList.SelectedRows.Count > 0)
            {
                txtSupID.Text = dgvSupList.SelectedRows[0].Cells[0].Value.ToString();
                txtSupName.Text = dgvSupList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvSupList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvSupList.SelectedRows[0].Cells[3].Value.ToString();
            }
        }
        void FormatDataGridview()
        {
            dgvSupList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 185, 1);
            dgvSupList.EnableHeadersVisualStyles = false;

            dgvSupList.Columns[0].HeaderText = "Mã NCC";
            dgvSupList.Columns[1].HeaderText = "Tên NCC";
            dgvSupList.Columns[1].Width = 200;
            dgvSupList.Columns[2].HeaderText = "Địa chỉ";
            dgvSupList.Columns[2].Width = 200;
            dgvSupList.Columns[3].HeaderText = "Số điện thoại";
            dgvSupList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        /*Lựa chọn khi nào người dùng được edit textbox
          0 : textbox ở chế độ đọc, không thể chỉnh sửa
          1 : textbox ở chế độ chỉnh sửa
        */
        public void setOnOffEditTextbox(int c)
        {
            if (c == 0)
            {
                txtSupID.ReadOnly = true;
                txtSupID.BackColor = System.Drawing.SystemColors.Window;//set màu trắng cho textbox khi dùng ReadOnly
                txtSupName.ReadOnly = true;
                txtSupName.BackColor = System.Drawing.SystemColors.Window;
                txtAddress.ReadOnly = true;
                txtAddress.BackColor = System.Drawing.SystemColors.Window;
                txtPhone.ReadOnly = true;
                txtPhone.BackColor = System.Drawing.SystemColors.Window;
            }
            else if (c == 1)
            {
                txtSupID.ReadOnly = false;
                txtSupName.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtPhone.ReadOnly = false;
            }
        }

        void clearTextbox()
        {
            txtSupID.Text = "";
            txtSupName.Text = "";
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
                label2.Text = "*Nhập thông tin nhà cung cấp mới vào form bên dưới";
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
            if (txtSupID.Text.Length == 0 || txtSupName.Text.Length == 0 || txtPhone.Text.Length == 0 || txtAddress.Text.Length == 0)
            {
                MessageBox.Show("Không chừa trống dữ liệu nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSupID.Text.KiemTraMaNCC() == false)
            {
                MessageBox.Show("Mã máy có 4 chữ số !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            eSupplier sup = new eSupplier();

            sup.SupplierId = txtSupID.Text;
            sup.SupplierName = txtSupName.Text;
            sup.Address = txtAddress.Text;
            sup.Phone = txtPhone.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    int result = bSup.insertSupplier(sup);
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

                        MessageBox.Show("Thêm nhà cung cấp mới thành công !", "Thêm NCC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvSupList.DataSource = bSup.getAllSupplier();
                    }
                    else
                        MessageBox.Show("Mã nhà cung cấp bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                bSup.updateSupplier(sup);

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

                MessageBox.Show("Cập nhập nhà cung cấp thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSupList.DataSource = bSup.getAllSupplier();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này ?",
                "Xóa NCC", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bSup.deleteSupplier(txtSupID.Text);
                if (result == true)
                {
                    dgvSupList.DataSource = bSup.getAllSupplier();
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
                label2.Text = "*Cập nhập thông tin nhà cung cấp";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
