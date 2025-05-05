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
    public partial class TrangChu: Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTintk thongTintk = new ThongTintk();
            thongTintk.ShowDialog();
            this.Show();
        }

        private void btnQuanLyBanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyBanHang frmQLBH = new QuanLyBanHang();
            frmQLBH.ShowDialog();
            this.Show();
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)// dangky
        {
            this.Hide();
            DangKy frmDangKy = new DangKy();
            frmDangKy.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Bạn có chắc muốn đăng xuất không?",
       "Xác nhận đăng xuất",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                DangNhap frmDangNhap = new DangNhap();
                frmDangNhap.ShowDialog();
                this.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
           BaoCao baoCao = new BaoCao();
            baoCao.ShowDialog();
            this.Hide();
            this.Show();
        }
    }
}
