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
    public partial class frmExpiredDrugsStatistics : Form
    {
        bMedecine bMed;
        public frmExpiredDrugsStatistics()
        {
            InitializeComponent();
        }
        private void frmExpiredDrugsStatistics_Load(object sender, EventArgs e)
        {
            bMed = new bMedecine();

            //Thống kê số liệu
            label1.Text = bMed.getAllMedecine().Count.ToString();
            lblExpiredDrug.Text = bMed.getExpiredMedecine().Count.ToString();
            lblNearlyExpiredDrug.Text = bMed.getNearlyExpiredMedecine().Count.ToString();

            dgvMedList.DataSource = bMed.getExpiredMedecine();
            FormatDataGridview();
            radioButton1.Checked = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //i++;
            //label1.Text = i.ToString();
        }
        void FormatDataGridview()
        {
            dgvMedList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 87, 154);
            dgvMedList.EnableHeadersVisualStyles = false;

            dgvMedList.Columns[0].HeaderText = "Mã thuốc";
            dgvMedList.Columns[1].HeaderText = "Tên thuốc";
            dgvMedList.Columns[1].Width = 300;
            dgvMedList.Columns[2].HeaderText = "Số lượng";
            dgvMedList.Columns[3].HeaderText = "Giá gốc";
            dgvMedList.Columns[4].HeaderText = "Đơn vị tính";
            dgvMedList.Columns[4].Width = 110;
            dgvMedList.Columns[5].HeaderText = "Loại thuốc";
            dgvMedList.Columns[5].Width = 150;
            dgvMedList.Columns[6].HeaderText = "Nhà cung cấp";
            dgvMedList.Columns[6].Width = 300;
            dgvMedList.Columns[7].HeaderText = "HSD";
            dgvMedList.Columns[8].HeaderText = "Mô tả";
            dgvMedList.Columns[9].HeaderText = "Quốc gia";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dgvMedList.DataSource = bMed.getExpiredMedecine();
        }

        private void rdoNearlyExpired_CheckedChanged(object sender, EventArgs e)
        {
            dgvMedList.DataSource = bMed.getNearlyExpiredMedecine();
        }
    }
}
