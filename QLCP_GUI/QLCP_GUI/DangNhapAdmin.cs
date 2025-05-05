using QLCP_BUS;
using QLCP_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCP_GUI
{
    public partial class DangNhapAdmin: Form
    {
        private AdminBUS adminBUS = new AdminBUS();

        public DangNhapAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            AdminBUS adminBUS = new AdminBUS();
            // Ví dụ kiểm tra login xong:


            if (adminBUS.Login(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                int maAdmin = adminBUS.LayMaAdminTuDangNhap(username);  // Viết hàm này ở BUS
                Session.MaAdminHienTai = maAdmin;
                this.Hide(); 
                ClearForm();
                Admin adminForm = new Admin(); 
                adminForm.ShowDialog();        

                this.Show(); 
            }
            else
            {
                ClearForm();
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();

            DangNhap frmDangNhap = new DangNhap();
            frmDangNhap.ShowDialog();
        }
        //thoat

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void ckViewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckViewPass.Checked)
            {
                // Hiện mật khẩu
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu bằng ký tự *
                txtPassword.PasswordChar = '*';
            }
        }

    }
}
