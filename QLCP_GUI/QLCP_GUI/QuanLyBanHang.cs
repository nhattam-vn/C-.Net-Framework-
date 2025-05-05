using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QLCP_DTO;
using QLCP_BUS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCP_GUI
{
    public partial class QuanLyBanHang : Form
    {
        List<SanPham> ds = SanPham_BUS.LayDanhSachMaVaTen();  //  hỗ trợ Insert
        private HoaDonBUS hoaDonBUS;

        public QuanLyBanHang()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
        }
        private void LoadDanhSachHoaDon()
        {
            HoaDonBUS hoaDonBUS = new HoaDonBUS();
            List<HoaDon> dsHoaDon = hoaDonBUS.LayDanhSachHoaDon(); 

            dgvHoaDon.DataSource = dsHoaDon;

            dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            dgvdssanpham.DataSource = SanPham_BUS.LayDSSanPham();

            Dictionary<string, byte> trangThaiItems = new Dictionary<string, byte>();
            trangThaiItems.Add("Đang bán", 1);
            trangThaiItems.Add("Ngừng bán", 0);

            cbTrangThai.DataSource = new BindingSource(trangThaiItems, null);
            cbTrangThai.DisplayMember = "Key";   // Hiển thị cho người dùng
            cbTrangThai.ValueMember = "Value";   // Giá trị thực lưu


            ds.Insert(0, new SanPham { MaSP = 0, TenSP = "-- Chọn sản phẩm --" });

            cboSanPham.DataSource = ds;
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";

            cboSanPham.SelectedIndex = 0;
            cboSanPham.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            txtDonGia.Text = "";
            txtMaSP.Text = "";

            txtSoHoaDon.Text = TaoMaHoaDonTuDong(); // Tạo mã hóa đơn tự động
            LoadDanhSachHoaDon();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) ||
         string.IsNullOrWhiteSpace(txtTen.Text) ||
         string.IsNullOrWhiteSpace(txtGia.Text) ||
         string.IsNullOrWhiteSpace(txtSL.Text) ||
         cbTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                SanPham sp = new SanPham();
                sp.MaSP = int.Parse(txtMa.Text);
                sp.TenSP = txtTen.Text;
                sp.GiaBan = decimal.Parse(txtGia.Text);
                sp.SoLuong = int.Parse(txtSL.Text);
                sp.TrangThai = (byte)((KeyValuePair<string, byte>)cbTrangThai.SelectedItem).Value;

                if (SanPham_BUS.ThemSanPham(sp))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    dgvdssanpham.DataSource = SanPham_BUS.LayDSSanPham(); // cập nhật lại grid
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại!");
                }
            }
        }

        private void BtnSuaa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) ||
        string.IsNullOrWhiteSpace(txtTen.Text) ||
        string.IsNullOrWhiteSpace(txtGia.Text) ||
        string.IsNullOrWhiteSpace(txtSL.Text) ||
        cbTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                SanPham sp = new SanPham();
                sp.MaSP = int.Parse(txtMa.Text);
                sp.TenSP = txtTen.Text;
                sp.GiaBan = decimal.Parse(txtGia.Text);
                sp.SoLuong = int.Parse(txtSL.Text);
                sp.TrangThai = (byte)((KeyValuePair<string, byte>)cbTrangThai.SelectedItem).Value;

                if (SanPham_BUS.SuaSanPham(sp))
                {
                    MessageBox.Show("Sửa sản phẩm thành công!");
                    dgvdssanpham.DataSource = SanPham_BUS.LayDSSanPham(); // Load lại danh sách
                }
                else
                {
                    MessageBox.Show("Sửa sản phẩm thất bại!");
                }
            }
        }

        private void dgvdssanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdssanpham.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaSP"].Value.ToString();
                txtTen.Text = row.Cells["TenSP"].Value.ToString();
                txtGia.Text = row.Cells["GiaBan"].Value.ToString();
                txtSL.Text = row.Cells["SoLuong"].Value.ToString();

                byte trangThai = byte.Parse(row.Cells["TrangThai"].Value.ToString());
                cbTrangThai.SelectedValue = trangThai;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!");
                return;
            }

            int maSP = int.Parse(txtMa.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (SanPham_BUS.XoaSanPham(maSP))
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    dgvdssanpham.DataSource = SanPham_BUS.LayDSSanPham(); // Load lại danh sách
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!");
                }
            }
        }
        private void ClearForm()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtGia.Clear();
            txtSL.Clear();
            cbTrangThai.SelectedIndex = -1; // Bỏ chọn combobox
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMa.Focus();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTintk frmThongTin = new ThongTintk();
            frmThongTin.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu frmTrangChu = new TrangChu();
            frmTrangChu.ShowDialog();
            this.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)// lua chon ten sp
        {
            if (cboSanPham.SelectedValue != null && int.TryParse(cboSanPham.SelectedValue.ToString(), out int maSP))
            {
                
                txtMaSP.Text = maSP.ToString();

                
                decimal donGia = SanPham_BUS.LayGiaBan(maSP);
                txtDonGia.Text = donGia.ToString("N0");
            }
            else
            {
                txtMaSP.Text = "";
                txtDonGia.Text = "";
            }

        }
      


        private void btnXoahd_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int rowIndex = dgvHoaDon.SelectedRows[0].Index;
                int soHD = Convert.ToInt32(dgvHoaDon.Rows[rowIndex].Cells["SoHD"].Value);

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (hoaDonBUS.XoaHoaDon(soHD))
                    {
                        MessageBox.Show("Xóa hóa đơn thành công!");
                        LoadDanhSachHoaDon(); // Hàm reload lại danh sách hóa đơn
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xoá!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSoHoaDon.Clear();
            cboSanPham.SelectedIndex = -1;
            txtMaSP.Clear();
            nudSoLuong.Value = 1;
            txtDonGia.Clear();
            txtThanhTien.Clear();
            txtMaKhachHang.Clear();
        }

        private void button11_Click(object sender, EventArgs e) //thoát 
        {
            this.Hide();
            TrangChu frmTrangChu = new TrangChu();
            frmTrangChu.ShowDialog();
            this.Show();
        }



        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra sản phẩm
            if (cboSanPham.SelectedIndex <= 0) // 0 là "-- Chọn sản phẩm --"
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            // Kiểm tra số lượng
            if (nudSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                return;
            }

            // Kiểm tra đơn giá
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            // Kiểm tra thành tiền
            if (!decimal.TryParse(txtThanhTien.Text, out decimal thanhTien) || thanhTien <= 0)
            {
                MessageBox.Show("Thành tiền không hợp lệ!");
                return;
            }
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thanh toán?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //try
                //{
                //    HoaDon hd = new HoaDon
                //    {
                //        SoHD = int.Parse(txtSoHoaDon.Text.Replace("HD", "")),
                //        MaNV = Session.MaNVHienTai,
                //        MaKH = string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ? 0 : int.Parse(txtMaKhachHang.Text), // <--- đây nè!
                //        MaAdmin = 0,
                //        NgayLap = DateTime.Now,
                //        TienKhachDua = decimal.Parse(txtTienKD.Text),
                //        TienGuiKhach = decimal.Parse(txtTienGK.Text),
                //        ThanhTien = decimal.Parse(txtThanhTien.Text),
                //        TienThua = decimal.Parse(lblTienKD.Text) - decimal.Parse(txtThanhTien.Text),
                //        PhuongThucTT = "Tiền mặt",
                //        TrangThaiHD = 1 // ví dụ: 1 = hoàn thành
                //    };


                //    HoaDonBUS hoaDonBUS = new HoaDonBUS();
                //    bool kq = hoaDonBUS.ThemHoaDon(hd);

                //    if (kq)
                //    {
                //        MessageBox.Show("Thanh toán và lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        LoadDanhSachHoaDon();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Thêm hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }


        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            // Lấy số lượng từ NumericUpDown
            int soLuong = (int)nudSoLuong.Value;

            // Lấy đơn giá từ TextBox, chuyển sang số
            if (decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                // Tính thành tiền = số lượng * đơn giá
                decimal thanhTien = soLuong * donGia;

                // Hiển thị thành tiền ra TextBox, format đẹp
                txtThanhTien.Text = thanhTien.ToString("N0"); // VD: 1,000; 10,000
            }
            else
            {
                // Nếu đơn giá không hợp lệ, reset thành tiền về 0
                txtThanhTien.Text = "0";
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string MaKhachHang = txtMaKhachHang.Text;
            string soHoaDon = txtSoHoaDon.Text;
            string tenSanPham = cboSanPham.Text;
            string maSanPham = txtMaSP.Text;
            int soLuong = Convert.ToInt32(nudSoLuong.Value);
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);
            decimal thanhTien = soLuong * donGia;

            // Gọi form in hóa đơn
            GiaoDienInHoaDon hoaDonForm = new GiaoDienInHoaDon(
                MaKhachHang, soHoaDon, tenSanPham, maSanPham, soLuong, donGia, thanhTien
            );
            hoaDonForm.ShowDialog();
        }
        private string TaoMaHoaDonTuDong()
        {
            List<HoaDon> dsHoaDon = hoaDonBUS.LayDanhSachHoaDon();

            int maxSoHD = 0;

            foreach (var hd in dsHoaDon)
            {
                if (hd.SoHD > maxSoHD)
                {
                    maxSoHD = hd.SoHD;
                }
            }

            // Tăng số lớn nhất lên 1
            int soMoi = maxSoHD + 1;

            // Format hiển thị: 001, 002 (chỉ để hiển thị trên giao diện)
            return soMoi.ToString("D3");
        }


        private void dgvdssanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdssanpham.Rows[e.RowIndex];

                txtMa.Text = row.Cells["MaSP"].Value.ToString();
                txtTen.Text = row.Cells["TenSP"].Value.ToString();
                txtGia.Text = row.Cells["GiaBan"].Value.ToString();
                txtSL.Text = row.Cells["SoLuong"].Value.ToString();

                byte trangThai = byte.Parse(row.Cells["TrangThai"].Value.ToString());
                cbTrangThai.SelectedValue = trangThai;
            }
        
    }
    }
}
