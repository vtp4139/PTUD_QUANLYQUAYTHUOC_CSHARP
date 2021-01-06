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
    public partial class frmDrugSearch : Form
    {
        bMedecine bMed;
        public frmDrugSearch()
        {
            InitializeComponent();
        }

        private void frmDrugSearch_Load(object sender, EventArgs e)
        {
            bMed = new bMedecine();

            dgvMed.DataSource = bMed.getAllMedecine();
            FormatDataGridview();

            rdoID.Checked = true;

            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;           
        }
        void FormatDataGridview()
        {
            dgvMed.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 116, 71);
            dgvMed.EnableHeadersVisualStyles = false;

            dgvMed.Columns[0].HeaderText = "Mã thuốc";
            dgvMed.Columns[1].HeaderText = "Tên thuốc";
            dgvMed.Columns[2].HeaderText = "Số lượng";
            dgvMed.Columns[3].HeaderText = "Giá gốc";
            dgvMed.Columns[4].HeaderText = "Đơn vị tính";
            dgvMed.Columns[4].Width = 150;
            dgvMed.Columns[5].HeaderText = "Loại thuốc";
            dgvMed.Columns[5].Width = 150;
            dgvMed.Columns[6].HeaderText = "Nhà cung cấp";
            dgvMed.Columns[6].Width = 300;
        }

        //Tìm kiếm Auto Complete
        void AutoComplete()
        {
            if (rdoID.Checked)
            {
                foreach (eMedicine med in bMed.getAllMedecine())
                {
                    txtSearch.AutoCompleteCustomSource.Add(med.MedicineID);
                }
            }
            else
            {
                foreach (eMedicine med in bMed.getAllMedecine())
                {
                    txtSearch.AutoCompleteCustomSource.Add(med.MedicineName);
                }
            }
        }

        private void rdoID_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.AutoCompleteCustomSource.Clear();
            AutoComplete();
        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.AutoCompleteCustomSource.Clear();
            AutoComplete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm !", "Không có dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string key = txtSearch.Text;
            int pos = search(key);
            if (pos >= 0)
            {
                if (dgvMed.SelectedRows.Count > 0)
                {
                    dgvMed.CurrentRow.Selected = false; // Không bôi xanh dòng hiện tại
                }
                dgvMed.Rows[pos].Selected = true; //Bôi xanh dòng thuộc tính tìm được
                dgvMed.CurrentCell = dgvMed.Rows[pos].Cells[0]; //Chỉ mũi tên đến dòng tìm được
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu !", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        int search(string key)
        {
            if (rdoID.Checked)
            {
                string a = "";
                for (int i = 0; i < dgvMed.Rows.Count; i++)
                {
                    a = dgvMed.Rows[i].Cells[0].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            else
            {
                string a = "";
                for (int i = 0; i < dgvMed.Rows.Count; i++)
                {
                    a = dgvMed.Rows[i].Cells[1].Value.ToString();
                    if (a.Equals(key))
                        return i;
                }
            }
            return -1;
        }      
        private void dgvMed_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvMed.SelectedRows.Count > 0)
            {
                txtMedID.Text = e.Row.Cells["medicineID"].Value.ToString();
                txtMedName.Text = e.Row.Cells["medicineName"].Value.ToString();
                txtInStock.Text = e.Row.Cells["unitsInStock"].Value.ToString();
                txtPrice.Text = e.Row.Cells["price"].Value.ToString();
                txtQuantity.Text = e.Row.Cells["quantity"].Value.ToString();
                txtCategory.Text = e.Row.Cells[5].Value.ToString();
                txtSupplier.Text = e.Row.Cells[6].Value.ToString();
                txtDescribe.Text = e.Row.Cells[8].Value.ToString();
                txtExp.Text = e.Row.Cells[7].Value.ToString();
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
