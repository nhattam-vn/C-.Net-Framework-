using System;
using System.Collections.Generic;
using QLCP_DTO;
using QLCP_DAO;

namespace QLCP_BUS
{
    public class ChiTietHoaDon_BUS
    {
        private ChiTietHoaDon_DAO chiTietHoaDonDAO;

        public ChiTietHoaDon_BUS()
        {
            chiTietHoaDonDAO = new ChiTietHoaDon_DAO();
        }

        // Phương thức cập nhật chi tiết hóa đơn
        public bool CapNhatChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return chiTietHoaDonDAO.CapNhatChiTietHoaDon(cthd);
        }

        // Phương thức lấy danh sách chi tiết hóa đơn
        public List<ChiTietHoaDon> LayDSChiTietHoaDon()
        {
            return chiTietHoaDonDAO.LayDSChiTietHoaDon();
        }
    }
}
