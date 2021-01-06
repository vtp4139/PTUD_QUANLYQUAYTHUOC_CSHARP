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

namespace DOAN_PTUD_DRUGSTORE_MANAGER_NHOM9
{
    public partial class frmLogin : Form
    {
        bAccount bAcc;
        public frmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.ActiveControl = label1; //Đặt trỏ chuột vào lable để tránh focus lên textbox khi bật form       
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            bAcc = new bAccount();
        }
        //Tạo icon exit cho form login
        private void lblExitLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Tạo placeholder cho textbox
        //---------------------------------------------------------------------
        private void txtAccount_Enter(object sender, EventArgs e)//Sử lý khi click chuột vào textbox
        {
            /*
             - Nếu người dùng click vào textbox thì chuỗi sẽ biến thành rỗng 
             - Màu của chữ đưa về lại đen
            */
            if(txtAccount.Text == "Nhập mã nhân viên")
            {
                txtAccount.Text = "";
                txtAccount.ForeColor = Color.Black;
            }
        }

        private void txtAccount_Leave(object sender, EventArgs e)//Sử lý khi rời chuột khỏi text box 
        {
            /*
             - Nếu người dùng rời chuột khỏi textbox thì chuỗi sẽ biến thành placeholder nếu 
             người dùng vẫn chưa nhập liệu mà để trống
             - Màu của chữ đưa về lại bạc
            */
            if (txtAccount.Text == "")
            {
                txtAccount.Text = "Nhập mã nhân viên";
                txtAccount.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Nhập mật khẩu")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Nhập mật khẩu";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        //Xử lý dữ liệu nhập vào để đăng nhập
        //---------------------------------------------------------------------
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool result = bAcc.checkIDExist(txtAccount.Text.Trim(),txtPassword.Text);
            if (result == true)
            {
                //Bật một form mới và ẩn form hiện hiện tại đi
                this.Hide();
                var form = new frmMenu(txtAccount.Text.Trim());
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
            //Kiểm tra dữ liệu nhập
            else if (txtAccount.Text == "Nhập mã nhân viên" || txtPassword.Text == "Nhập mật khẩu")
            {
                MessageBox.Show("Dữ liệu không được bỏ trống !", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng !", "Đăng nhập thất bại",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
