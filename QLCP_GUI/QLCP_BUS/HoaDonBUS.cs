using System;
using System.Collections.Generic;
using QLCP_DAO;
using QLCP_DTO;

namespace QLCP_BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAO hoaDonDAO;

        HoaDonDAO dao = new HoaDonDAO();
        public bool ThemHoaDon(HoaDon hd)
        {
            return dao.ThemHoaDon(hd);
        }
        public bool XoaHoaDon(int soHD)
        {
            return dao.XoaHoaDon(soHD);
        }
        public HoaDonBUS()
        {
            hoaDonDAO = new HoaDonDAO();
        }

        public List<HoaDon> LayDanhSachHoaDon()
        {
            return hoaDonDAO.LayDanhSachHoaDon(); // Call the method using the instance (hoaDonDAO)
        }
    }
}
