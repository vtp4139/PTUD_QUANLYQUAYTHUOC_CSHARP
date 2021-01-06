using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Tier;
using Entities;

namespace DOAN_PTUD_DRUGSTORE_MANAGER_NHOM9
{
    public partial class frmDrugManager : Form
    {
        bMedecine bMed;
        public frmDrugManager()
        {
            InitializeComponent();
        }

        private void frmDrugManager_Load(object sender, EventArgs e)
        {
            //Set giao diện lúc load
            bMed = new bMedecine();
            btnSave.Enabled = false;
            label2.Text = "";
            dtpExp.CustomFormat = "dd-MM-yyyy";
            //dtpExp.Format = DateTimePickerFormat.Custom;

            //Load dữ liệu lên combobox
            cboSupplier.DataSource = bMed.getAllSupplierName();
            cboCategory.DataSource = bMed.getAllCategoriesName();
            cboCountry.DataSource = bMed.getAllCountryName();
            cboQuantityPerUnit.DataSource = bMed.getAllQuantityPerUnitName();

            List<string> c = bMed.getAllCategoriesName();
            c.Add("Tất cả thuốc");
            cboCategoryPL.DataSource = c;

            List<string> s = bMed.getAllSupplierName();
            s.Add("Tất cả nhà cung cấp");
            cboSupplierPL.DataSource = s;

            cboCategoryPL.Text = "Tất cả thuốc";
            cboSupplierPL.Text = "Tất cả nhà cung cấp";

            //Load dữ liệu datagridview
            dgvMedList.DataSource = bMed.getAllMedecine();
            FormatDataGridview();
            setOnOffEditTextbox(0);
        }
        private void dgvMedList_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvMedList.SelectedRows.Count > 0)
            {
                txtMedID.Text = dgvMedList.SelectedRows[0].Cells["medicineID"].Value.ToString();
                txtMedName.Text = dgvMedList.SelectedRows[0].Cells["medicineName"].Value.ToString();
                txtInStock.Text = dgvMedList.SelectedRows[0].Cells["unitsInStock"].Value.ToString();
                txtPrice.Text = string.Format("{0:C}", Convert.ToDecimal(dgvMedList.SelectedRows[0].Cells["price"].Value.ToString()));
                txtSellPrice.Text = string.Format("{0:C}", Convert.ToDecimal(dgvMedList.SelectedRows[0].Cells["sellPrice"].Value.ToString()));
                cboQuantityPerUnit.Text = dgvMedList.SelectedRows[0].Cells["quantity"].Value.ToString();
                cboCategory.Text = dgvMedList.SelectedRows[0].Cells["categoryName"].Value.ToString();
                cboSupplier.Text = dgvMedList.SelectedRows[0].Cells["supplierName"].Value.ToString();
                cboCountry.Text = dgvMedList.SelectedRows[0].Cells["country"].Value.ToString();
                txtDescribe.Text = dgvMedList.SelectedRows[0].Cells["describe"].Value.ToString();
            }
        }

        void FormatDataGridview()
        {
            dgvMedList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 116, 71);
            dgvMedList.EnableHeadersVisualStyles = false;

            dgvMedList.Columns[0].HeaderText = "Mã thuốc";
            dgvMedList.Columns[1].HeaderText = "Tên thuốc";
            dgvMedList.Columns[1].Width = 250;
            dgvMedList.Columns[2].HeaderText = "Số lượng";
            dgvMedList.Columns[3].HeaderText = "Giá gốc";
            dgvMedList.Columns[4].HeaderText = "Giá bán";
            dgvMedList.Columns[5].HeaderText = "Đơn vị tính";
            dgvMedList.Columns[5].Width = 110;
            dgvMedList.Columns[6].HeaderText = "Loại thuốc";
            dgvMedList.Columns[6].Width = 150;
            dgvMedList.Columns[7].HeaderText = "Nhà cung cấp";
            dgvMedList.Columns[7].Width = 250;
            dgvMedList.Columns[8].HeaderText = "HSD";
            dgvMedList.Columns[8].Width = 100;
            dgvMedList.Columns[9].HeaderText = "Mô tả";
            dgvMedList.Columns[9].Width = 250;
            dgvMedList.Columns[10].HeaderText = "Quốc gia";
            dgvMedList.Columns[10].Width = 100;
        }

        /*Lựa chọn khi nào người dùng được edit textbox
          0 : textbox ở chế độ đọc, không thể chỉnh sửa
          1 : textbox ở chế độ chỉnh sửa
        */
        public void setOnOffEditTextbox(int c)
        {
            if (c == 0)
            {
                txtMedID.ReadOnly = true;
                txtMedID.BackColor = System.Drawing.SystemColors.Window;//set màu trắng cho textbox khi dùng ReadOnly
                txtMedName.ReadOnly = true;
                txtMedName.BackColor = System.Drawing.SystemColors.Window;
                //cboUnitInStock.ReadOnly = true;
                cboQuantityPerUnit.BackColor = System.Drawing.SystemColors.Window;
                txtPrice.ReadOnly = true;
                txtPrice.BackColor = System.Drawing.SystemColors.Window;
                txtInStock.ReadOnly = true;
                txtInStock.BackColor = System.Drawing.SystemColors.Window;
                dtpExp.Enabled = false;
                dtpExp.BackColor = System.Drawing.SystemColors.Window;
                txtDescribe.ReadOnly = true;
                txtDescribe.BackColor = System.Drawing.SystemColors.Window;
                cboCountry.Enabled = false;
                cboQuantityPerUnit.Enabled = false;
                cboSupplier.Enabled = false;
                cboCategory.Enabled = false;
            }
            else if (c == 1)
            {
                txtMedID.ReadOnly = false;
                txtMedName.ReadOnly = false;
                // cboUnitInStock.ReadOnly = false;
                txtPrice.ReadOnly = false;
                txtInStock.ReadOnly = false;
                dtpExp.Enabled = true;
                txtDescribe.ReadOnly = false;
                cboCountry.Enabled = true;
                cboQuantityPerUnit.Enabled = true;
                cboSupplier.Enabled = true;
                cboCategory.Enabled = true;
            }
        }

        void clearTextbox()
        {
            txtMedID.Text = "";
            txtMedName.Text = "";
            cboQuantityPerUnit.Text = "";
            txtPrice.Text = "";
            txtInStock.Text = "";
            txtDescribe.Text = "";
            cboCategory.Text = "";
            cboSupplier.Text = "";
            cboCountry.Text = "";
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
                label2.Text = "*Nhập thông tin thuốc mới vào form bên dưới:";
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
                //this.txtMsMay.Enabled = false;
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
            eMedicine med = new eMedicine();

            med.MedicineID = txtMedID.Text;
            med.MedicineName = txtMedName.Text;
            med.Quantity = cboQuantityPerUnit.Text;
            med.Price = double.Parse(txtPrice.Text);
            med.UnitsInStock = int.Parse(txtInStock.Text);
            med.CategoryName = cboCategory.Text;
            med.SupplierName = cboSupplier.Text;
            med.Exp = dtpExp.Value;
            med.Describe = txtDescribe.Text;

            if (btnSave.Text.Equals("Lưu thêm"))
            {
                try
                {
                    int result = bMed.insertMedecine(med);
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

                        MessageBox.Show("Thêm thuốc mới thành công !", "Thêm thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvMedList.DataSource = bMed.getAllMedecine();
                    }
                    else
                        MessageBox.Show("Mã thuốc bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                bMed.updateMedecine(med);

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

                MessageBox.Show("Cập nhập thuốc thành công !", "Cập nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvMedList.DataSource = bMed.getAllMedecine();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result;
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa thuốc này ?",
                "Xóa thuốc", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlg == DialogResult.Yes)
            {
                result = bMed.deleteMedecine(txtMedID.Text);
                if (result == true)
                {
                    dgvMedList.DataSource = bMed.getAllMedecine();
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
                //this.txtMsMay.Enabled = true;
                btnUpdate.Text = "Hủy";
                btnUpdate.BackColor = Color.FromArgb(231, 62, 52);
                label2.Text = "*Sửa thông tin thuốc:";
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
                //this.txtMsMay.Enabled = false;
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

        private void rdoMedName_CheckedChanged(object sender, EventArgs e)
        {
            dgvMedList.DataSource = bMed.sortByMedecineName();
        }

        private void rdoPriceIncr_CheckedChanged(object sender, EventArgs e)
        {
            dgvMedList.DataSource = bMed.sortByMedecinePriceInc();
        }

        private void rdoPriceDes_CheckedChanged(object sender, EventArgs e)
        {
            dgvMedList.DataSource = bMed.sortByMedecinePriceDes();
        }

        private void rdoInStock_CheckedChanged(object sender, EventArgs e)
        {
            dgvMedList.DataSource = bMed.sortByMedecineUnit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboCategoryPL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoryPL.Text == "Tất cả thuốc" && cboSupplierPL.Text != "Tất cả nhà cung cấp")
            {
                dgvMedList.DataSource = bMed.getMedecineBySupplier(cboSupplierPL.Text);
            }
            else if (cboCategoryPL.Text != "Tất cả thuốc" && cboSupplierPL.Text != "Tất cả nhà cung cấp")
            {
                dgvMedList.DataSource = bMed.getMedecineBySupplierAndCategory(cboSupplierPL.Text, cboCategoryPL.Text);
            }
            else if (cboCategoryPL.Text == "Tất cả thuốc" && cboSupplierPL.Text == "Tất cả nhà cung cấp")
            {
                dgvMedList.DataSource = bMed.getAllMedecine();
            }
            else
                dgvMedList.DataSource = bMed.getMedecineByCategories(cboCategoryPL.Text);
        }

        private void cboSupplierPL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoryPL.Text != "Tất cả thuốc" && cboSupplierPL.Text == "Tất cả nhà cung cấp")
            {
                dgvMedList.DataSource = bMed.getMedecineByCategories(cboCategoryPL.Text);
            }
            else if (cboCategoryPL.Text != "Tất cả thuốc" && cboSupplierPL.Text != "Tất cả nhà cung cấp")
            {
                dgvMedList.DataSource = bMed.getMedecineBySupplierAndCategory(cboSupplierPL.Text, cboCategoryPL.Text);
            }
            else if (cboCategoryPL.Text == "Tất cả thuốc" && cboSupplierPL.Text == "Tất cả nhà cung cấp")
            {
                dgvMedList.DataSource = bMed.getAllMedecine();
            }
            else
                dgvMedList.DataSource = bMed.getMedecineBySupplier(cboSupplierPL.Text);
        }

        private void dgvMedList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMedList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMedList_MouseClick(object sender, MouseEventArgs e)
        {
            string strDate = dgvMedList.SelectedRows[0].Cells["exp"].Value.ToString();
            DateTime d = new DateTime(1999,11,1);
            d = Convert.ToDateTime(strDate);
            
            if(d < dtpExp.MinDate || d>dtpExp.MaxDate)
            {
                MessageBox.Show("Lỗi!");
            }
            else dtpExp.Value = d;

        }
    }
}
