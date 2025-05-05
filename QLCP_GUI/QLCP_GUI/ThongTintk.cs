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
using static QLCP_BUS.NhanVienBUS;

namespace QLCP_GUI
{
    public partial class ThongTintk: Form
    {
        private readonly NhanVienBUS bus = new NhanVienBUS();
        public ThongTintk()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ThongTintk_Load(object sender, EventArgs e)
        {
            NhanVienBUS bus = new NhanVienBUS();

            // Lấy mã nhân viên đang đăng nhập từ Session
            int maNV = Session.MaNVHienTai;

            // Lấy thông tin nhân viên
            NhanVien nv = bus.LayThongTinNhanVienTheoMa(maNV);

            if (nv != null)
            {
                txtMaNV.Text = nv.MaNV.ToString();
                txtTenNV.Text = nv.TenNV;
                txtGioiTinh.Text = nv.GioiTinh;
                txtSDT.Text = nv.SDT;
                txtDiaChi.Text = nv.DiaChi;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trangChu = new TrangChu();
            trangChu.ShowDialog();
            this.Close();
        }
    }
}
