using QLCP_BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLCP_BUS.NhanVienBUS;

namespace QLCP_GUI
{
    public partial class DangNhap: Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();

            DangNhapAdmin frmAdminLogin = new DangNhapAdmin();
            frmAdminLogin.ShowDialog();

            this.Show();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text;

            NhanVienBUS bus = new NhanVienBUS();
            int maNV = bus.DangNhap(username, password);  // chỉ gọi 1 lần

            if (maNV != -1)
            {
                // Lưu vào session để các form khác dùng
                Session.MaNVHienTai = maNV;
                txtTaiKhoan.Clear();
                txtMatKhau.Clear();
                TrangChu frmTrangChu = new TrangChu();
                this.Hide();
                frmTrangChu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void ckViewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckViewPass.Checked)
            {
                // Hiện mật khẩu
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu bằng ký tự *
                txtMatKhau.PasswordChar = '*';
            }
        }
    }
}
