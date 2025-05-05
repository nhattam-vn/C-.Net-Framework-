using QLCP_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCP_GUI
{
    public partial class GiaoDienInHoaDon: Form
    {
        public GiaoDienInHoaDon(string maKhachHang, string soHoaDon, string tenSanPham,
                                 string maSanPham, int soLuong, decimal donGia, decimal thanhTien)
        {
            InitializeComponent();

            // Gán dữ liệu cho các label (bạn phải tạo label13, label1,... trong Designer)
            label13.Text = maKhachHang;
            label1.Text = soHoaDon;
            label2.Text = tenSanPham;
            label3.Text = maSanPham;
            label4.Text = soLuong.ToString();
            label5.Text = donGia.ToString("N0") + " đ";
            label6.Text = thanhTien.ToString("N0") + " đ";
        }
        public GiaoDienInHoaDon()
        {
            InitializeComponent();

            
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyBanHang frmQuanLyBanHang = new QuanLyBanHang();
            frmQuanLyBanHang.ShowDialog();
            this.Show();
        }
    }
}
