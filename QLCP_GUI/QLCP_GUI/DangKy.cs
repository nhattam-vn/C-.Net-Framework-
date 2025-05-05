using QLCP_BUS;
using QLCP_DTO;
using System;
using System.Windows.Forms;

namespace QLCP_GUI
{
    public partial class DangKy : Form
    {
        
        public DangKy()
        {
            InitializeComponent();
        }

    
        private void ResetForm()
        {
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtTenKH.Focus();
        }
        private string TaoMaKhachHangTuDong()
        {
            KhachHangBUS bus = new KhachHangBUS();
            var dsKH = bus.LayDanhSachKhachHang();

            int maxMaKH = 0;

            foreach (var kh in dsKH)
            {
                if (kh.MaKH > maxMaKH)
                {
                    maxMaKH = kh.MaKH;
                }
            }

            int maMoi = maxMaKH + 1;

            return maMoi.ToString("D3");
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (TrangChu f = new TrangChu())
            {
                f.ShowDialog();
            }
            this.Show();

        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = TaoMaKhachHangTuDong();
            txtMaKH.Enabled = false; // Khóa trường mã khách hàng
            txtMaNV.Text = Session.MaNVHienTai.ToString();
            txtMaNV.Enabled = false; // Khóa trường mã nhân viên
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int.TryParse(txtMaKH.Text.Replace("KH", ""), out int maKH);
            int.TryParse(txtMaNV.Text, out int maNV);

            KhachHang kh = new KhachHang
            {
                MaKH = maKH,
                MaNV = maNV,
                TenKH = txtTenKH.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SDT = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                NgayTao = DateTime.Today, // chỉ lấy ngày, không lấy giờ
                TrangThai = 1,
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                User = txtUser.Text.Trim(),
                Pass = txtPass.Text.Trim()
            };

            try
            {
                KhachHangBUS bus = new KhachHangBUS();
                bool result = bus.DangKyKhachHang(kh);

                if (result)
                {
                    MessageBox.Show("Đăng ký thành công!");
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}