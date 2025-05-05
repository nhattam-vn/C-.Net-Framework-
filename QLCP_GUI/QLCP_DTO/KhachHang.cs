using System;

namespace QLCP_DTO
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }

        public DateTime? NgayTao { get; set; }
        public int? TrangThai { get; set; }

        public int MaNV { get; set; } // ➕ Thêm dòng này
    }
}
