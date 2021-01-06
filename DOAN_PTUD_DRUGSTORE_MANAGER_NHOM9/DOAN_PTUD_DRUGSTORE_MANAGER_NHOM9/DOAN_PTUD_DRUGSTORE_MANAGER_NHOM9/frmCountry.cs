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
    public partial class frmCountry : Form
    {
        bCountry bCou;

        public frmCountry()
        {
            InitializeComponent();
        }
        private void frmCountry_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bCou = new bCountry();
            btnSave.Enabled = false;
            label2.Text = "";

            //Load dữ liệu datagridview
            dgvCountryList.DataSource = bCou.getAllCountry();
            FormatDataGridview();

            setOnOffEditTextbox(0);

        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCountryList.SelectedRows.Count > 0)
            {
                txtID.Text = dgvCountryList.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvCountryList.SelectedRows[0].Cells[1].Value.ToString();
            }
        }
        void FormatDataGridview()
        {
            dgvCountryList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 182, 159);
            dgvCountryList.EnableHeadersVisualStyles = false;

            dgvCountryList.Columns[0].HeaderText = "Mã quốc gia";
            dgvCountryList.Columns[0].Width = 200;
            dgvCountryList.Columns[1].HeaderText = "Tên quốc gia";
            dgvCountryList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                label2.Text = "*Nhập thông tin quốc gia mới vào form bên dưới";
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

            if (txtID.Text.Length != 3)
            {
                MessageBox.Show("Mã có số kí tự bằng 3 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            eCountry sup = new eCountry();

            sup.Id = txtID.Text;
            sup.Name = txtName.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    int result = bCou.insertCountry(sup);
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

                        MessageBox.Show("Thêm quốc gia mới thành công !", "Thêm NCC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCountryList.DataSource = bCou.getAllCountry();
                    }
                    else
                        MessageBox.Show("Mã quốc gia bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                bCou.updateCountry(sup);

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


                MessageBox.Show("Cập nhập quốc gia thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCountryList.DataSource = bCou.getAllCountry();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa quốc gia này ?",
                "Xóa NCC", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bCou.deleteCountry(txtID.Text);
                if (result == true)
                {
                    dgvCountryList.DataSource = bCou.getAllCountry();
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
                label2.Text = "*Cập nhập thông tin quốc gia";
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
