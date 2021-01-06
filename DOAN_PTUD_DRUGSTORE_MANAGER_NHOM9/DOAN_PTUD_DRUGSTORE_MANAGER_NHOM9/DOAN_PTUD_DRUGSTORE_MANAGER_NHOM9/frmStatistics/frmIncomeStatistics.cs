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
using System.Globalization;

namespace DOAN_PTUD_DRUGSTORE_MANAGER_NHOM9
{
    public partial class frmIncomeStatistics : Form
    {
        bBill bB;
        bBillDetail bBD;
        public frmIncomeStatistics()
        {
            InitializeComponent();
        }

        private void frmIncomeStatistics_Load(object sender, EventArgs e)
        {
            dtpIS.Format = DateTimePickerFormat.Custom;
            dtpIS.CustomFormat = "MM/yyyy";

            bB = new bBill();
            bBD = new bBillDetail();

            dgvBillList.DataSource = bB.getAllBill();
            FormatDgvIS();

            rdoMonth.Checked = true;

            List<eBill> ls = new List<eBill>();
            //DateTime date = new DateTime(Convert.ToInt32(dtpIS.Value.Year), Convert.ToInt32(dtpIS.Value.Month), Convert.ToInt32(dtpIS.Value.Day));
            //MessageBox.Show(date.ToString());
            ls = bB.getAllBill();

            double total = 0;
            foreach (eBill b in ls)
            {
                total = total + bBD.totalMoney(b.BillID);
            }

            dgvBillList.DataSource = ls;

            lblIncome.Text = string.Format("{0:C}", Convert.ToDecimal(total.ToString()));
            lblsl.Text = dgvBillList.RowCount.ToString();

        }       

        //tong so luong
        private void quantitiesCount()
        {
            int sum = 0;
            for (int i = 0; i < dgvBillList.RowCount - 1; i++)
            {
                sum += (int)dgvBillList.Rows[i].Cells[2].Value;
            }
            lblsl.Text = sum.ToString();
        }

        //ham tinh tong gia tri
        private void priceCount()
        {
            double sum = 0;
            for (int i = 0; i < dgvBillList.RowCount - 1; i++)
            {
                sum += (double)dgvBillList.Rows[i].Cells[3].Value;
            }
            lblIncome.Text = sum.ToString();
        }

        void FormatDgvIS()
        {
            dgvBillList.Columns[0].HeaderText = "Mã HĐ";
            dgvBillList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 116, 71);
            dgvBillList.EnableHeadersVisualStyles = false;

            dgvBillList.Columns[0].HeaderText = "Mã HĐ";
            dgvBillList.Columns[1].HeaderText = "Ngày lập HĐ";
            dgvBillList.Columns[1].Width = 150;
            dgvBillList.Columns[2].HeaderText = "Tên KH";
            dgvBillList.Columns[2].Width = 400;
            dgvBillList.Columns[3].HeaderText = "Tên NV";
            dgvBillList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {
            dtpIS.Format = DateTimePickerFormat.Custom;
            dtpIS.CustomFormat = "MM/yyyy";
            dtpIS.ShowUpDown = true;
        }

        private void rdoYear_CheckedChanged(object sender, EventArgs e)
        {
            dtpIS.Format = DateTimePickerFormat.Custom;
            dtpIS.CustomFormat = "yyyy";
            dtpIS.ShowUpDown = true;
        }


        private void btnInput_Click(object sender, EventArgs e)
        {
            List<eBill> ls = new List<eBill>();
            if (rdoMonth.Checked)

            {

                DateTime date = new DateTime(Convert.ToInt32(dtpIS.Value.Year), Convert.ToInt32(dtpIS.Value.Month), Convert.ToInt32(dtpIS.Value.Day));
                //MessageBox.Show(date.ToString());
                ls = bB.orderStatistic_M(date).ToList();

                double total = 0;
                foreach(eBill b in ls)
                {
                    total = total + bBD.totalMoney(b.BillID);
                }
                dgvBillList.DataSource = ls;

                lblIncome.Text = string.Format("{0:C}", Convert.ToDecimal(total.ToString()));
                lblsl.Text = dgvBillList.RowCount.ToString();

            }
            if (rdoYear.Checked)
            {
                DateTime date = new DateTime(Convert.ToInt32(dtpIS.Value.Year), Convert.ToInt32(dtpIS.Value.Month), Convert.ToInt32(dtpIS.Value.Day));
                //MessageBox.Show(date.ToString());
                ls = bB.orderStatistic_Y(date).ToList();
                dgvBillList.DataSource = ls;


                double total = 0;
                foreach (eBill b in ls)
                {
                    total = total + bBD.totalMoney(b.BillID);
                }
                dgvBillList.DataSource = ls;

                lblIncome.Text = string.Format("{0:C}", Convert.ToDecimal(total.ToString()));
                lblsl.Text = dgvBillList.RowCount.ToString();
            }
        }

        private void dgvIS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvIS_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvIS_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvIS_Validated(object sender, EventArgs e)
        {

        }

        private void lblsl_Click(object sender, EventArgs e)
        {

        }

    }
}
