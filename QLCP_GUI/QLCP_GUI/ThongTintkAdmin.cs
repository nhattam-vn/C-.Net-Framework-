using QLCP_BUS;
using QLCP_DTO;
using System;
using System.Windows.Forms;

namespace QLCP_GUI
{
    public partial class ThongTintkAdmin : Form
    {
        AdminBUS adminBUS = new AdminBUS();
        private QLCP_DTO.Admin adminHienTai;


        public ThongTintkAdmin()
        {
            InitializeComponent();
        }

        private void ThongTintkAdmin_Load(object sender, EventArgs e)
        {
            int maAdmin = Session.MaAdminHienTai;
            adminHienTai = adminBUS.LayThongTinAdmin(maAdmin);

            if (adminHienTai != null)
            {
                txtMaAdmin.Text = adminHienTai.MaAdmin.ToString();
                txtTenAdmin.Text = adminHienTai.TenAdmin;
                txtUserName.Text = adminHienTai.UserName;
                txtPassword.Text = adminHienTai.Password;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin admin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauMoi = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool kq = adminBUS.DoiMatKhau(adminHienTai.MaAdmin, matKhauMoi);

            if (kq)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            capnhatmatkhau frmCapNhatMatKhau = new capnhatmatkhau();
            frmCapNhatMatKhau.ShowDialog();
            this.Show();
        }
    }
}
