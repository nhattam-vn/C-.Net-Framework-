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

namespace QLCP_GUI
{
    public partial class capnhatmatkhau: Form
    {
        public capnhatmatkhau()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPass.Text) ||
        string.IsNullOrWhiteSpace(txtNewPass.Text) ||
        string.IsNullOrWhiteSpace(txtRePass.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (txtNewPass.Text != txtRePass.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            AdminBUS adminBUS = new AdminBUS();
            bool doiThanhCong = adminBUS.DoiMatKhau(Session.MaAdminHienTai, txtNewPass.Text);

            if (doiThanhCong)
            {
                this.Hide();
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
                ThongTintkAdmin thongTinTkAdmin = new ThongTintkAdmin();
                thongTinTkAdmin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại! Kiểm tra lại mã Admin.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.ShowDialog();
            this.Close();
        }
    }
}
