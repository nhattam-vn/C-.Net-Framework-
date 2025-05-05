using System.Collections.Generic;
using QLCP_DAO;
using QLCP_DTO;

namespace QLCP_BUS
{
    public class PhieuNhap_BUS
    {
        private readonly PhieuNhap_DAO dao = new PhieuNhap_DAO();

        public List<PhieuNhap> LayDanhSachPhieuNhap()
        {
            return dao.LayDSPhieuNhap();
        }

        public static int ThemPN(PhieuNhap pn)
        {
            PhieuNhap_DAO dao = new PhieuNhap_DAO();
            return dao.ThemPhieuNhap(pn);
        }
        public static int CapNhatPN(PhieuNhap pn)
        {
            return (new PhieuNhap_DAO()).CapNhatPhieuNhap(pn);
        }
        public static bool XoaPN(int maPN)
        {
            PhieuNhap_DAO dao = new PhieuNhap_DAO();
            return dao.XoaPN(maPN);
        }


    }
}
