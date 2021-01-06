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
    public partial class frmCustomerSearch : Form
    {
        bCustomer bCus;
        public frmCustomerSearch()
        {
            InitializeComponent();
        }
        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            bCus = new bCustomer();

            dgvCusList.DataSource = bCus.getAllCustomer();
            FormatDataGridview();

            rdoID.Checked = true;

            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        void FormatDataGridview()
        {
            dgvCusList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(183, 71, 42);
            dgvCusList.EnableHeadersVisualStyles = false;

            dgvCusList.Columns[0].HeaderText = "Mã KH";
            dgvCusList.Columns[1].HeaderText = "Tên khách hàng";
            dgvCusList.Columns[1].Width = 200;
            dgvCusList.Columns[2].HeaderText = "Địa chỉ";
            dgvCusList.Columns[2].Width = 250;
            dgvCusList.Columns[3].HeaderText = "Số điện thoại";
            dgvCusList.Columns[3].Width = 150;
        }

        //Tìm kiếm Auto Complete
        void AutoComplete()
        {
            if (rdoID.Checked)
            {
                foreach (eCustomer cus in bCus.getAllCustomer())
                {
                    txtSearch.AutoCompleteCustomSource.Add(cus.CustomerID);
                }
            }
            else if (rdoPhone.Checked)
            {
                foreach (eCustomer cus in bCus.getAllCustomer())
                {
                    txtSearch.AutoCompleteCustomSource.Add(cus.Phone);
                }
            }
            else
            {
                foreach (eCustomer cus in bCus.getAllCustomer())
                {
                    txtSearch.AutoCompleteCustomSource.Add(cus.CustomerName);
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
                if (dgvCusList.SelectedRows.Count > 0)
                {
                    dgvCusList.CurrentRow.Selected = false; // Không bôi xanh dòng hiện tại
                }
                dgvCusList.Rows[pos].Selected = true; //Bôi xanh dòng thuộc tính tìm được
                dgvCusList.CurrentCell = dgvCusList.Rows[pos].Cells[0]; //Chỉ mũi tên đến dòng tìm được
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
                for (int i = 0; i < dgvCusList.Rows.Count; i++)
                {
                    a = dgvCusList.Rows[i].Cells[0].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else if (rdoPhone.Checked)
            {
                string a = "";
                for (int i = 0; i < dgvCusList.Rows.Count; i++)
                {
                    a = dgvCusList.Rows[i].Cells[3].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else
            {
                string a = "";
                for (int i = 0; i < dgvCusList.Rows.Count; i++)
                {
                    a = dgvCusList.Rows[i].Cells[1].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            return -1;
        }
        private void dgvMed_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCusList.SelectedRows.Count > 0)
            {
                txtCusID.Text = dgvCusList.SelectedRows[0].Cells[0].Value.ToString();
                txtCusName.Text = dgvCusList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvCusList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvCusList.SelectedRows[0].Cells[3].Value.ToString();
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
