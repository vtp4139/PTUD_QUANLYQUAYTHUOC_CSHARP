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
    public partial class frmEmployeeManager : Form
    {
        bEmployee bEmpl;
        public frmEmployeeManager()
        {
            InitializeComponent();
        }
        private void frmEmployeeManager_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bEmpl = new bEmployee();
            btnSave.Enabled = false;
            label2.Text = "";

            //Load dữ liệu lên combobox
            cboEmpType.DataSource = bEmpl.getAllTypeName();

            //Load dữ liệu datagridview
            dgvEmpList.DataSource = bEmpl.getAllEmployee();
            FormatDataGridview();

            setOnOffEditTextbox(0);
            
        }
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvEmpList.SelectedRows.Count > 0)
            {
                txtEmpID.Text = dgvEmpList.SelectedRows[0].Cells[0].Value.ToString();
                txtEmpName.Text = dgvEmpList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvEmpList.SelectedRows[0].Cells[3].Value.ToString();
                txtPhone.Text = dgvEmpList.SelectedRows[0].Cells[4].Value.ToString();
                cboEmpType.Text = dgvEmpList.SelectedRows[0].Cells[2].Value.ToString();
            }
        }
        void FormatDataGridview()
        {
            dgvEmpList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 87, 154);
            dgvEmpList.EnableHeadersVisualStyles = false;

            dgvEmpList.Columns[0].HeaderText = "Mã NV";
            dgvEmpList.Columns[1].HeaderText = "Tên nhân viên";
            dgvEmpList.Columns[1].Width = 150;
            dgvEmpList.Columns[2].HeaderText = "Loại nhân viên";
            dgvEmpList.Columns[2].Width = 150;
            dgvEmpList.Columns[3].HeaderText = "Địa chỉ";
            dgvEmpList.Columns[3].Width = 250;
            dgvEmpList.Columns[4].HeaderText = "Số điện thoại";
            dgvEmpList.Columns[4].Width = 150;
        }

        /*Lựa chọn khi nào người dùng được edit textbox
          0 : textbox ở chế độ đọc, không thể chỉnh sửa
          1 : textbox ở chế độ chỉnh sửa
        */
        public void setOnOffEditTextbox(int c)
        {
            if (c == 0)
            {
                txtEmpID.ReadOnly = true;
                txtEmpID.BackColor = System.Drawing.SystemColors.Window;//set màu trắng cho textbox khi dùng ReadOnly
                txtEmpName.ReadOnly = true;
                txtEmpName.BackColor = System.Drawing.SystemColors.Window;
                txtAddress.ReadOnly = true;
                txtAddress.BackColor = System.Drawing.SystemColors.Window;
                txtPhone.ReadOnly = true;
                txtPhone.BackColor = System.Drawing.SystemColors.Window;
                cboEmpType.Enabled = false;
            }
            else if (c == 1)
            {
                txtEmpID.ReadOnly = false;
                txtEmpName.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtPhone.ReadOnly = false;
                cboEmpType.Enabled = true;
            }
        }

        void clearTextbox()
        {
            txtEmpID.Text = "";
            txtEmpName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            cboEmpType.Text = "";
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
                label2.Text = "*Nhập thông tin nhân viên mới vào form bên dưới";
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
            if (txtEmpID.Text.Length == 0 || txtEmpName.Text.Length == 0 || txtPhone.Text.Length == 0 || txtAddress.Text.Length == 0 || cboEmpType.Text.Length == 0)
            {
                MessageBox.Show("Không chừa trống dữ liệu nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtEmpID.Text.KiemTraMaNhanVien() == false)
            {
                MessageBox.Show("Mã nhân viên có định dạng:BH(TK,QL)XXX với X là số !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            eEmployee emp = new eEmployee();

            emp.EmployeeID = txtEmpID.Text;
            emp.EmployeeName = txtEmpName.Text;
            emp.Address = txtAddress.Text;
            emp.Phone = txtPhone.Text;
            emp.EmployeeType = cboEmpType.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    int result = bEmpl.insertEmployee(emp);
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

                        MessageBox.Show("Thêm nhân viên mới thành công !", "Thêm thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvEmpList.DataSource = bEmpl.getAllEmployee();
                    }
                    else
                        MessageBox.Show("Mã nhân viên bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                bEmpl.updateEmployee(emp);

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

                MessageBox.Show("Cập nhập nhân viên thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmpList.DataSource = bEmpl.getAllEmployee();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này ?",
                "Xóa nhân viên", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bEmpl.deleteEmployee(txtEmpID.Text);
                if (result == true)
                {
                    dgvEmpList.DataSource = bEmpl.getAllEmployee();
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
                label2.Text = "*Cập nhập thông tin nhân viên";
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
