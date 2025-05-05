using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCP_DAO;
using QLCP_DTO;
namespace QLCP_BUS
{
    public class SanPham_BUS
    {
        private SanPham_DAO dao = new SanPham_DAO();

       
        public static List<SanPham> LayDSSanPham()
        {
            return SanPham_DAO.LoadDSSanPham();
        }

        public static bool ThemSanPham(SanPham sp)
        {
            return SanPham_DAO.ThemSanPham(sp);
        }

        public static bool SuaSanPham(SanPham sp)
        {
            return SanPham_DAO.SuaSanPham(sp);
        }

        public static bool XoaSanPham(int maSP)
        {
            return SanPham_DAO.XoaSanPham(maSP);
        }

        public static List<SanPham> LayDanhSachMaVaTen()
        {
            return SanPham_DAO.LayDanhSachMaVaTen();
        }

        public static decimal LayGiaBan(int maSP)
        {
            return SanPham_DAO.LayGiaBanTheoMaSP(maSP);
        }

        public static decimal TinhThanhTien(int maSP, int soLuong)
        {
            decimal gia = LayGiaBan(maSP);
            return gia * soLuong;
        }
    }
}
