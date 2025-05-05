using QLCP_BUS;
using QLCP_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCP_GUI
{
    public partial class Admin : Form
    {

        NhanVienBUS bus = new NhanVienBUS();
        PhieuNhap_BUS busPN = new PhieuNhap_BUS();
        public Admin()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadData(); // P: Load danh sách nhân viên
            LoadDanhSachSanPham();
            LoadDanhSachChiTietHoaDon();
            LoadPhieuNhap();
            //Tạo mã nhân viên tự động
            txtMaNV.Text = TaoMaNhanVienTuDong(); // Tạo mã tự động
            //Tạo mã sản phẩm tự động
            txtMaSP1.Text = TaoMaSanPhamTuDong(); // Tạo mã tự động
            //Khóa các TextBox không cho nhập liệu
            txtMaNV.Enabled = false;
            txtThanhTien.Enabled = false;
            //Quản lý doanh thu
            TinhTongSoHoaDon();
            TinhTongSoSanPham();
            TinhTongDoanhThu();
            //Textbox Trạng Thái
            txtTrangThai.Enabled = false;
        }
        private void LoadData()
        {
            dgvNhanVien.DataSource = bus.LayDSNhanVien();
        }
        private void LoadDanhSachSanPham()
        {
            List<SanPham> dsSanPham = SanPham_BUS.LayDSSanPham();
            dtgvSanPham.DataSource = dsSanPham;
        }

        private void LoadDanhSachChiTietHoaDon()
        {
            // Tạo đối tượng của lớp ChiTietHoaDon_BUS
            ChiTietHoaDon_BUS chiTietHoaDonBUS = new ChiTietHoaDon_BUS();

            // Lấy danh sách chi tiết hóa đơn từ lớp BUS và gán vào DataSource của DataGridView
            dgvChiTietHoaDon.DataSource = chiTietHoaDonBUS.LayDSChiTietHoaDon();

            dgvChiTietHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "0";
            dgvChiTietHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "0";

        }

        private void LoadPhieuNhap()
        {
            dgvPhieuNhap.DataSource = busPN.LayDanhSachPhieuNhap();
        }


        //xoa nhanvien

        //lam moi thanh nhap lieu
        private void button4_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = TaoMaNhanVienTuDong(); // Tạo mã tự động
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            txtUser.Clear();
            txtPass.Clear();

            radioNam.Checked = false;
            radioNu.Checked = false;


            LoadData();
        }

        //lam moi thanh nhap lieu
        private void btnLamMoiNL_Click(object sender, EventArgs e)
        {
            txtMaSP1.Clear();
            txtTenSP.Clear();
            txtGiaNhap.Clear();
            txtSoLuong.Clear();
            cboTrangThai.SelectedIndex = 0;

        }
        //sua cthd
        private void btnThemhd_Click(object sender, EventArgs e)
        {
            try
            {
                int soHD = int.Parse(txtSoHD.Text);
                int maSP = int.Parse(txtMaSP.Text);
                int soLuong = int.Parse(txtSoLuongcthd.Text);
                decimal donGia = decimal.Parse(txtDonGia.Text);
                decimal thanhTien = soLuong * donGia;

                // Sửa lại định dạng hiển thị thành tiền
                txtThanhTien.Text = thanhTien.ToString("0");


                ChiTietHoaDon cthd = new ChiTietHoaDon
                {
                    SoHD = soHD,
                    MaSP = maSP,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                };

                ChiTietHoaDon_BUS chiTietHoaDonBUS = new ChiTietHoaDon_BUS();
                bool ketQua = chiTietHoaDonBUS.CapNhatChiTietHoaDon(cthd); // Đã chuyển sang cập nhật

                if (ketQua)
                {
                    MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!");
                    LoadDanhSachChiTietHoaDon();
                    txtSoHD.Clear();
                    txtMaSP.Clear();
                    txtSoLuongcthd.Clear();
                    txtDonGia.Clear();
                    txtThanhTien.Clear();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txtSoHD.Clear();
            txtMaSP.Clear();
            txtSoLuongcthd.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();


        }

        private void btnThempn_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuNhap pn = new PhieuNhap
                {
                    MaNCC = int.Parse(txtMaNCC.Text),
                    NgayNhap = dtpNgayNhap.Value,
                    MaPhieuNhap = int.Parse(txtMaPhieuNhap.Text),  // thêm dòng này
                    MaNV = int.Parse(txtMaNV.Text), // thêm dòng này    
                    MaAdmin = int.Parse(txtMaAdmin.Text)
                };

                int kq = PhieuNhap_BUS.ThemPN(pn);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm phiếu nhập thành công!");
                    LoadPhieuNhap();  // bạn viết thêm hàm này để reload DataGridView
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSuapn_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuNhap pn = new PhieuNhap
                {
                    MaPhieuNhap = int.Parse(txtMaPhieuNhap.Text), // lấy mã để WHERE
                    MaNCC = int.Parse(txtMaNCC.Text),
                    NgayNhap = dtpNgayNhap.Value,
                    MaNV = int.Parse(txtMaNVpn.Text),
                    MaAdmin = int.Parse(txtMaAdmin.Text)
                };

                int kq = PhieuNhap_BUS.CapNhatPN(pn);
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật phiếu nhập thành công!");
                    txtMaPhieuNhap.Clear();
                    txtMaNCC.Clear();
                    dtpNgayNhap.Value = DateTime.Now;
                    txtMaNVpn.Clear();
                    txtMaAdmin.Clear();
                    LoadPhieuNhap(); // reload danh sách
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaPhieuNhap.Text, out int maPN))
                {
                    MessageBox.Show("Mã phiếu nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool kq = PhieuNhap_BUS.XoaPN(maPN);
                    if (kq)
                    {
                        MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo");
                        LoadPhieuNhap();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhap.Clear();
            txtMaAdmin.Clear();
            txtMaNCC.Clear();

            dtpNgayNhap.Value = DateTime.Now;
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTintkAdmin frm = new ThongTintkAdmin();
            frm.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            capnhatmatkhau frm = new capnhatmatkhau();
            frm.ShowDialog();
            this.Show();
        }

        private void CHUCNANG_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaNV.Text, out int maNV))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool kq = bus.XoaNhanVien(maNV);
                    if (kq)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = int.Parse(txtMaNV.Text),
                    TenNV = txtTenNV.Text,
                    GioiTinh = radioNam.Checked ? "Nam" : "Nữ",
                    SDT = txtSDT.Text,
                    Luong = int.TryParse(txtLuong.Text, out int luong) ? luong : (int?)null,
                    DiaChi = txtDiaChi.Text,
                    UserName = txtUser.Text,
                    Password = txtPass.Text,
                    MaAdmin = 1,

                };

                bool kq = bus.CapNhatNhanVien(nv);
                if (kq)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        //Load trạng thái
        private void LoadTrangThai()
        {
            var danhSachTrangThai = new List<KeyValuePair<byte, string>>()
    {
        new KeyValuePair<byte, string>(1, "Hoạt động"),
        new KeyValuePair<byte, string>(0, "Ngừng hoạt động")
    };

            cboTrangThai.DataSource = danhSachTrangThai;
            cboTrangThai.DisplayMember = "Value";
            cboTrangThai.ValueMember = "Key";
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvSanPham.Rows[e.RowIndex];

                txtMaSP1.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtGiaNhap.Text = row.Cells["GiaBan"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();

                LoadTrangThai(); // Load trạng thái vào ComboBox


                if (byte.TryParse(row.Cells["TrangThai"].Value.ToString(), out byte trangThai))
                {
                    cboTrangThai.SelectedValue = trangThai;
                }
                else
                {
                    cboTrangThai.SelectedIndex = -1; // Không chọn gì nếu lỗi parse
                }

            }
        }
        private void TinhTongSoHoaDon()
        {
            int tongSoHD = dgvChiTietHoaDon.Rows.Count;
            lblSoHD.Text = tongSoHD.ToString();
        }
        //Tính tổng số sản phẩm
        private void TinhTongSoSanPham()
        {
            int tongSoSP = 0;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Cells["SoLuong"].Value != null && int.TryParse(row.Cells["SoLuong"].Value.ToString(), out int soLuong))
                {
                    tongSoSP += soLuong;
                }
            }
            lblSoSanPham.Text = tongSoSP.ToString();
        }
        //Tính tổng doanh thu
        private void TinhTongDoanhThu()
        {
            decimal tongDoanhThu = 0;
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null && decimal.TryParse(row.Cells["ThanhTien"].Value.ToString(), out decimal thanhTien))
                {
                    tongDoanhThu += thanhTien;
                }
            }
            lblDoanhThu.Text = tongDoanhThu.ToString("N0"); // format 1,000
        }
        //Tải sản phẩm lên textbox
        private void dgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTietHoaDon.Rows[e.RowIndex];

                txtSoHD.Text = row.Cells["SoHD"].Value.ToString();
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtSoLuongcthd.Text = row.Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtThanhTien.Text = Convert.ToDecimal(row.Cells["ThanhTien"].Value).ToString("N0");
            }
        }
        //Tính thành tiền
        private void txtSoLuongcthd_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongcthd.Text, out int soLuong) &&
                decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                decimal thanhTien = soLuong * donGia;
                txtThanhTien.Text = thanhTien.ToString("N0"); // format 1,000
            }
            else
            {
                txtThanhTien.Text = "0";
            }

        }
        //kiêm tra nhập số
        private void txtSoLuongcthd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //kiêm tra nhập số
        private void txtMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //thoát
        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhapAdmin frm = new DangNhapAdmin();
            frm.ShowDialog();
            this.Close();
        }
        //Tải nhân viên lên textbox
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtLuong.Text = row.Cells["Luong"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtUser.Text = row.Cells["UserName"].Value.ToString();
                txtPass.Text = row.Cells["Password"].Value.ToString();
                int trangThai = int.Parse(row.Cells["TrangThai"].Value.ToString());
                if (trangThai == 1)
                {
                    txtTrangThai.Text = "Hoạt động";
                }
                else
                {
                    txtTrangThai.Text = "Ngừng hoạt động";
                }
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    radioNam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    radioNu.Checked = true;
                }
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];

                txtMaPhieuNhap.Text = row.Cells["MaPhieuNhap"].Value.ToString();
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtMaAdmin.Text = row.Cells["MaAdmin"].Value.ToString();
                txtMaNVpn.Text = row.Cells["MaNV"].Value.ToString();
                // Nếu cột NgayNhap là kiểu DateTime, chuyển về DateTimePicker
                if (DateTime.TryParse(row.Cells["NgayNhap"].Value.ToString(), out DateTime ngayNhap))
                {
                    dtpNgayNhap.Value = ngayNhap;
                }
            }
        }
        private string TaoMaNhanVienTuDong()
        {
            List<NhanVien> danhSachNV = bus.LayDSNhanVien();

            int maxMa = 0;
            foreach (var nv in danhSachNV)
            {
                if (nv.MaNV > maxMa)
                {
                    maxMa = nv.MaNV;
                }
            }

            int maMoi = maxMa + 1;

            // Chỉ format để hiển thị trên textbox, database vẫn lưu kiểu int
            return maMoi.ToString("000");
        }

        //Thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = int.Parse(txtMaNV.Text),
                    TenNV = txtTenNV.Text,
                    GioiTinh = radioNam.Checked ? "Nam" : "Nữ",
                    SDT = txtSDT.Text,
                    Luong = int.TryParse(txtLuong.Text, out int luong) ? luong : 0,
                    DiaChi = txtDiaChi.Text,
                    UserName = txtUser.Text,
                    Password = txtPass.Text,
                    MaAdmin = 1

                };

                int kq = bus.ThemNhanVien(nv);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        //Tạo mã tự động cho sản phẩm
        private string TaoMaSanPhamTuDong()
        {
            List<SanPham> danhSachSP = SanPham_BUS.LayDSSanPham();

            int maxMa = 0;
            foreach (var sp in danhSachSP)
            {
                if (sp.MaSP > maxMa)
                {
                    maxMa = sp.MaSP;
                }
            }

            int maMoi = maxMa + 1;

            // Hiển thị trên giao diện dạng SP001
            return maMoi.ToString("000");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra mã nhân viên có hợp lệ không
                if (!int.TryParse(txtMaNV.Text.Replace("NV", ""), out int maNV))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận người dùng có chắc chắn muốn xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool kq = bus.XoaNhanVien(maNV);
                    if (kq)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
                        LoadData(); // reload danh sách nhân viên
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }

}

