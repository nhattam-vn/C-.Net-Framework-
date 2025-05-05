using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP_DTO
{
    class GiamGia
    {
        public int MaGG { get; set; }
        public string TenGG { get; set; }
        public decimal GiaTriGiamGia { get; set; }
        public decimal? GiaTriToiDa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public bool TrangThai { get; set; }
    }
}
