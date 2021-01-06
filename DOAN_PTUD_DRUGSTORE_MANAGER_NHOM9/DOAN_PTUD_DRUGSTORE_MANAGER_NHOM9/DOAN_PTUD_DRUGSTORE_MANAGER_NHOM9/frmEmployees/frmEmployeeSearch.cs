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
    public partial class frmEmployeeSearch : Form
    {
        bEmployee bEmp;
        public frmEmployeeSearch()
        {
            InitializeComponent();
        }
        private void frmEmployeeSearch_Load(object sender, EventArgs e)
        {
            bEmp = new bEmployee();

            dgvEmpList.DataSource = bEmp.getAllEmployee();
            FormatDataGridview();

            rdoID.Checked = true;

            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
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

        //Tìm kiếm Auto Complete
        void AutoComplete()
        {
            if (rdoID.Checked)
            {
                foreach (eEmployee emp in bEmp.getAllEmployee())
                {
                    txtSearch.AutoCompleteCustomSource.Add(emp.EmployeeID);
                }
            }
            else if(rdoPhone.Checked)
            {
                foreach (eEmployee emp in bEmp.getAllEmployee())
                {
                    txtSearch.AutoCompleteCustomSource.Add(emp.Phone);
                }
            }
            else
            {
                foreach (eEmployee emp in bEmp.getAllEmployee())
                {
                    txtSearch.AutoCompleteCustomSource.Add(emp.EmployeeName);
                }
            }
        }

        private void rdoID_CheckedChanged(object sender, EventArgs e)
        {
            AutoComplete();
        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            AutoComplete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm !", "Không có dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string key = txtSearch.Text;
            int pos = search(key);
            if (pos >= 0)
            {
                if (dgvEmpList.SelectedRows.Count > 0)
                {
                    dgvEmpList.CurrentRow.Selected = false; // Không bôi xanh dòng hiện tại
                }
                dgvEmpList.Rows[pos].Selected = true; //Bôi xanh dòng thuộc tính tìm được
                dgvEmpList.CurrentCell = dgvEmpList.Rows[pos].Cells[0]; //Chỉ mũi tên đến dòng tìm được
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int search(string key)
        {
            if (rdoID.Checked)
            {
                string a = "";
                for (int i = 0; i < dgvEmpList.Rows.Count; i++)
                {
                    a = dgvEmpList.Rows[i].Cells[0].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else if (rdoPhone.Checked)
            {
                string a = "";
                for (int i = 0; i < dgvEmpList.Rows.Count; i++)
                {
                    a = dgvEmpList.Rows[i].Cells[4].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else
            {
                string a = "";
                for (int i = 0; i < dgvEmpList.Rows.Count; i++)
                {
                    a = dgvEmpList.Rows[i].Cells[1].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            return -1;
        }
        private void dgvMed_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvEmpList.SelectedRows.Count > 0)
            {
                txtEmpID.Text = dgvEmpList.SelectedRows[0].Cells[0].Value.ToString();
                txtEmpName.Text = dgvEmpList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvEmpList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvEmpList.SelectedRows[0].Cells[3].Value.ToString();
                txtEmpType.Text = dgvEmpList.SelectedRows[0].Cells[4].Value.ToString();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
