using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP_DTO
{
    class Kho
    {
        public int MaKho { get; set; }
        public int MaNL { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime NgayXuat { get; set; }
        public string GhiChu { get; set; }
        public int MaAdmin { get; set; }
    }
}
