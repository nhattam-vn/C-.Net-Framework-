using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP_DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public int MaAdmin { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public int? Luong { get; set; }
        public string DiaChi { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? TrangThai { get; set; }
    }
}
