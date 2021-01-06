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
    public partial class frmDrugSell : Form
    {
        bMedecine bMed;
        bCustomer bCus;
        bBill bB;
        bBillDetail bBD;
        string empID = "";

        //Tạo biến lưu thông tin thuốc khi chon thuốc để load lên list view
        string medecineID, medecineName;
        int money;
        public frmDrugSell(string id)
        {
            InitializeComponent();
            empID = id;
        }

        private void frmDrugSell_Load(object sender, EventArgs e)
        {
            bMed = new bMedecine();
            bCus = new bCustomer();
            bB = new bBill();
            bBD = new bBillDetail();

            medecineID = "";
            medecineName = "";

            //Load danh sách
            dgvMedList.DataSource = bMed.getAllMedecine();
            FormatDataGridviewMed();
            dgvCusList.DataSource = bCus.getAllCustomer();
            FormatDataGridviewCus();

            //Sử dụng AutoComplete
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearchCus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearchCus.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (eMedicine med in bMed.getAllMedecine())
            {
                txtSearch.AutoCompleteCustomSource.Add(med.MedicineName);
            }
            foreach (eCustomer cus in bCus.getAllCustomer())
            {
                txtSearchCus.AutoCompleteCustomSource.Add(cus.CustomerName);
            }

            //Định dạng form
            setOnOffEditTextbox(0);
            btnSave.Enabled = false;
            lblNotify.Text = "";
            InsertColumnsListView();
            txtTotalMoney.ReadOnly = true;
            txtTotalMoney.BackColor = System.Drawing.SystemColors.Window;
            btnCancelBill.Enabled = false;
            btnPay.Enabled = false;

            dgvMedList.ReadOnly = true;
            dgvCusList.ReadOnly = true;
        }

        //Format danh sách thuốc
        void FormatDataGridviewMed()
        {
            dgvMedList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(1, 113, 197);//Thêm màu cho header
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

        //Format danh sách khách hàng
        void FormatDataGridviewCus()
        {
            dgvCusList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(1, 113, 197);
            dgvCusList.EnableHeadersVisualStyles = false;

            dgvCusList.Columns[0].HeaderText = "Mã KH";
            dgvCusList.Columns[1].HeaderText = "Tên khách hàng";
            dgvCusList.Columns[1].Width = 150;
            dgvCusList.Columns[2].HeaderText = "Địa chỉ";
            dgvCusList.Columns[2].Width = 250;
            dgvCusList.Columns[3].HeaderText = "Số điện thoại";
            dgvCusList.Columns[3].Width = 150;
        }

        //-------Tạo cột cho List View-----------------
        void InsertColumnsListView()
        {
            this.lstvBill.Columns.Add("Mã thuốc", 100);
            this.lstvBill.Columns.Add("Tên thuốc", 250);
            this.lstvBill.Columns.Add("Số lượng", 150);
            this.lstvBill.Columns.Add("Thành tiền", 200);

            this.lstvBill.View = View.Details;
            this.lstvBill.GridLines = true;
            this.lstvBill.FullRowSelect = true;
        }
       
        int search(string key)
        {
            string a = "";
            for (int i = 0; i < dgvMedList.Rows.Count; i++)
            {
                a = dgvMedList.Rows[i].Cells[1].Value.ToString();
                if (a.Equals(key))
                    return i;
            }
            return -1;
        }
      
        int searchCus(string key)
        {
            string a = "";
            for (int i = 0; i < dgvCusList.Rows.Count; i++)
            {
                a = dgvCusList.Rows[i].Cells[1].Value.ToString();
                if (a.Equals(key))
                    return i;
            }
            return -1;
        }

        //Hiện thông tin khách hàng lên text box
        private void dgvCusList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvCusList.SelectedRows.Count > 0)
            {
                txtCusID.Text = dgvCusList.SelectedRows[0].Cells[0].Value.ToString();
                txtCusName.Text = dgvCusList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvCusList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvCusList.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        //Lấy thông tin thuốc hiện để load lên list view
        //Chèn thông tin vào các biến tạo trước
        private void dgvMedList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvMedList.SelectedRows.Count > 0)
            {

            }
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
        //Clear hết text trong textbox để thêm mới khách hàng
        void clearTextbox()
        {
            txtCusID.Text = "";
            txtCusName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }              

        void sumMoney()
        {
            double tongtien = 0;
            for (int i = 0; i < lstvBill.Items.Count; i++)
            {
                tongtien += double.Parse(lstvBill.Items[i].SubItems[3].Text);
            }
            txtTotalMoney.Text = string.Format("{0:#,##}", Convert.ToDecimal(tongtien.ToString()));
        }
          
       
        #region BUTTON HANDLING
        //------------------------------------------------------------------------------
        //Tìm kiếm thuốc
        private void btnFind_Click(object sender, EventArgs e)
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
                if (dgvMedList.SelectedRows.Count > 0)
                {
                    dgvMedList.CurrentRow.Selected = false; // Không bôi xanh dòng hiện tại
                }
                dgvMedList.Rows[pos].Selected = true; //Bôi xanh dòng thuộc tính tìm được
                dgvMedList.CurrentCell = dgvMedList.Rows[pos].Cells[0]; //Chỉ mũi tên đến dòng tìm được
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //------------------------------------------------------------------------------
        //Tìm kiếm khách hàng
        private void btnFindCus_Click(object sender, EventArgs e)
        {
            if (txtSearchCus.Text == "")
            {
                MessageBox.Show("Nhập thông tin cần tìm kiếm !", "Không có dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string key = txtSearchCus.Text;
            int pos = searchCus(key);
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

        //Sự kiện chọn nút chọn thuốc
        private void btnChoose_Click(object sender, EventArgs e)
        {
            string id = dgvMedList.SelectedRows[0].Cells[0].Value.ToString();
            string name = dgvMedList.SelectedRows[0].Cells[1].Value.ToString();
            double money = double.Parse(dgvMedList.SelectedRows[0].Cells[4].Value.ToString());

            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (int.Parse(txtQuantity.Text) < 1)
            {
                MessageBox.Show("Số lượng phải ít nhất là 1 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            int result = bB.subtractQuantity(id, int.Parse(txtQuantity.Text)); // Trừ số lượng đã nhập
            if (result == -1)
            {
                MessageBox.Show("Số lượng hàng trong kho không còn đủ !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvMedList.DataSource = bMed.getAllMedecine(); // Load lại danh sách

            double medMoney = money * double.Parse(txtQuantity.Text); // Tính thành tiền của thuốc được chọn

            ListViewItem lvi;
            lvi = new ListViewItem(new string[] { id, name, txtQuantity.Text, string.Format("{0:#,##}", Convert.ToDecimal(medMoney.ToString()))});
            this.lstvBill.Items.Add(lvi);

            sumMoney(); // Tính thành tiền

            btnCancelBill.Enabled = true;
            btnPay.Enabled = true;
        }

        //NÚT XÓA THUỐC TRÊN LIST VIEW
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lstvBill.SelectedItems.Count > 0)
            {
                string id = this.lstvBill.SelectedItems[0].SubItems[0].Text;
                int quantity = int.Parse(this.lstvBill.SelectedItems[0].SubItems[2].Text);
                bB.addQuantity(id, quantity); // Cộng lại số lượng đã xóa
                dgvMedList.DataSource = bMed.getAllMedecine();
                foreach (ListViewItem eachItem in lstvBill.SelectedItems)
                {
                    lstvBill.Items.Remove(eachItem); //Xóa item khỏi list view
                }

            }
            if (lstvBill.Items.Count == 0)
            {
                btnCancelBill.Enabled = false;
                btnPay.Enabled = false;
            }
            sumMoney(); // Tính lại thành tiền
        }

        //NÚT HỦY HÓA ĐƠN
        private void btnCancelBill_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn hủy hóa đơn ?", "HỦY HĐ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Cộng lại toàn bộ số lượng thuốc đã lấy trong kho
                for (int i = 0; i < lstvBill.Items.Count; i++)
                {
                    string id = this.lstvBill.Items[i].SubItems[0].Text;
                    int quantity = int.Parse(this.lstvBill.Items[i].SubItems[2].Text);
                    bB.addQuantity(id, quantity);
                }
                dgvMedList.DataSource = bMed.getAllMedecine();

                //Load lại list view
                lstvBill.Clear();
                InsertColumnsListView();
                btnCancelBill.Enabled = false;
                btnPay.Enabled = false;
                txtTotalMoney.Text = "0";
            }
        }

        //NÚT THANH TOÁN
        private void btnPay_Click(object sender, EventArgs e)
        {
            eBill or = new eBill();
            or.OrderDate = DateTime.Now;
            or.CustomerID = txtCusID.Text;
            or.EmployeeID = empID;

            int orderID = bB.insertOrders(or);

            List<eBillDetail> listBill = new List<eBillDetail>();

            //Thêm chi tiết vào hóa đơn đã tạo
            for (int i = 0; i < lstvBill.Items.Count; i++)
            {
                eBillDetail ord = new eBillDetail();
                ord.BillID = orderID.ToString();
                ord.MedicineID = this.lstvBill.Items[i].SubItems[0].Text;
                ord.Quantity = int.Parse(this.lstvBill.Items[i].SubItems[2].Text);
                ord.Price = double.Parse(this.lstvBill.Items[i].SubItems[3].Text);
                ord.Discount = 0.1;

                listBill.Add(ord);
            }
            bBD.insertOrderDetail(listBill);
            MessageBox.Show("Thêm hóa đơn mới thành công !", "Thêm HĐ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lstvBill.Clear();
            InsertColumnsListView();
            btnCancelBill.Enabled = false;
            btnPay.Enabled = false;
            txtTotalMoney.Text = "0";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearTextbox();
            if (!btnNew.Text.Equals("HỦY THÊM"))
            {
                btnSave.Enabled = true;
                btnSave.Text = "LƯU THÊM";
                btnSave.BackColor = Color.FromArgb(109, 255, 84);
                btnNew.Text = "HỦY THÊM";
                btnNew.BackColor = Color.FromArgb(255, 68, 78);
                lblNotify.Text = "*Nhập đầy đủ thông tin khách hàng vào form";
                setOnOffEditTextbox(1);
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.Text = "LƯU THÊM";
                btnSave.BackColor = Color.Gainsboro;
                btnNew.Text = "THÊM KHÁCH HÀNG";
                btnNew.BackColor = Color.Gainsboro;
                lblNotify.Text = "";
                setOnOffEditTextbox(0);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            eCustomer cus = new eCustomer();

            cus.CustomerID = txtCusID.Text;
            cus.CustomerName = txtCusName.Text;
            cus.Address = txtAddress.Text;
            cus.Phone = txtPhone.Text;

            if (btnSave.Text.Equals("LƯU THÊM"))
            {
                //try
                // {
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

                    MessageBox.Show("Thêm nhân viên mới thành công !", "Thêm thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCusList.DataSource = bCus.getAllCustomer();
                }
                else
                    MessageBox.Show("Mã nhân viên bị trùng ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //   catch (Exception ex)
                //  {
                //  MessageBox.Show(ex.Message);
                // }
            }
        }
        #endregion


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lstvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstvBill_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("aaa");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
