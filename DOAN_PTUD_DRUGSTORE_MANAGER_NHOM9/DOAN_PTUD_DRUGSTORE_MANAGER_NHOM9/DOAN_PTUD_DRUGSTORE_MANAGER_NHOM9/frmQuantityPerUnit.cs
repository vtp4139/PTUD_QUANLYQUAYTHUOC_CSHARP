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
    public partial class frmQuantityPerUnit : Form
    {
        bQuantityPerUnit bQuan;

        public frmQuantityPerUnit()
        {
            InitializeComponent();
        }
        private void frmQuantityPerUnit_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bQuan = new bQuantityPerUnit();
            btnSave.Enabled = false;
            label2.Text = "";

            //Load dữ liệu datagridview
            dgvQuanList.DataSource = bQuan.getAllQuantityPerUnit();
            FormatDataGridview();

            setOnOffEditTextbox(0);

        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvQuanList.SelectedRows.Count > 0)
            {
                txtID.Text = dgvQuanList.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvQuanList.SelectedRows[0].Cells[1].Value.ToString();
            }
        }
        void FormatDataGridview()
        {
            dgvQuanList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 75, 90);
            dgvQuanList.EnableHeadersVisualStyles = false;

            dgvQuanList.Columns[0].HeaderText = "Mã ĐVT";
            dgvQuanList.Columns[0].Width = 200;
            dgvQuanList.Columns[1].HeaderText = "Tên đơn vị tính";
            dgvQuanList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        /*Lựa chọn khi nào người dùng được edit textbox
          0 : textbox ở chế độ đọc, không thể chỉnh sửa
          1 : textbox ở chế độ chỉnh sửa
        */
        public void setOnOffEditTextbox(int c)
        {
            if (c == 0)
            {
                txtID.ReadOnly = true;
                txtID.BackColor = System.Drawing.SystemColors.Window;//set màu trắng cho textbox khi dùng ReadOnly
                txtName.ReadOnly = true;
                txtName.BackColor = System.Drawing.SystemColors.Window;
            }
            else if (c == 1)
            {
                txtID.ReadOnly = false;
                txtName.ReadOnly = false;
            }
        }

        void clearTextbox()
        {
            txtID.Text = "";
            txtName.Text = "";
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
                label2.Text = "*Nhập thông tin đơn vị tính mới vào form bên dưới";
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
            if (txtID.Text.Length == 0 || txtName.Text.Length == 0)
            {
                MessageBox.Show("Không chừa trống dữ liệu nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtID.Text.Length > 3)
            {
                MessageBox.Show("Mã có số kí tự nhỏ hơn 3 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            eQuantityPerUnit sup = new eQuantityPerUnit();

            sup.Id = txtID.Text;
            sup.Name = txtName.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    int result = bQuan.insertQuantityPerUnit(sup);
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

                        MessageBox.Show("Thêm đơn vị tính mới thành công !", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvQuanList.DataSource = bQuan.getAllQuantityPerUnit();
                    }
                    else
                        MessageBox.Show("Mã đơn vị tính bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                bQuan.updateQuantityPerUnit(sup);

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

                MessageBox.Show("Cập nhập đơn vị tính thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvQuanList.DataSource = bQuan.getAllQuantityPerUnit();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa đơn vị tính này ?",
                "Xóa NCC", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bQuan.deleteQuantityPerUnit(txtID.Text);
                if (result == true)
                {
                    dgvQuanList.DataSource = bQuan.getAllQuantityPerUnit();
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
                label2.Text = "*Cập nhập thông tin đơn vị tính";
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
