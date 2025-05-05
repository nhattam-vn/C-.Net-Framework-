using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP_DTO
{
   public  class HoaDon
    {
        public int SoHD { get; set; }  // Số hóa đơn
        public int MaNV { get; set; }  // Mã nhân viên
        public int MaKH { get; set; }  // Mã khách hàng
        public int MaAdmin { get; set; }  // Mã admin
        public int? MaGG { get; set; }  // Mã giảm giá (nullable nếu không áp dụng giảm giá)
        public DateTime NgayLap { get; set; }  // Ngày lập hóa đơn
        public decimal TienKhachDua { get; set; }  // Tiền khách đưa
        public decimal TienGuiKhach { get; set; }  // Tiền giữ khách (nếu có)
        public decimal ThanhTien { get; set; }  // Tổng tiền (sau giảm giá nếu có)
        public decimal TienThua { get; set; }  // Tiền thừa (nếu có)
        public string PhuongThucTT { get; set; }  // Phương thức thanh toán (string hoặc enum nếu cố định)
        public  byte TrangThaiHD { get; set; }
    }
}
