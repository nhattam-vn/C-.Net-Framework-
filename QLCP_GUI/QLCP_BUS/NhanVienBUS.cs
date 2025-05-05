using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCP_DAO;
using QLCP_DTO;
namespace QLCP_BUS
{
    public class NhanVienBUS
    {
        NhanVienDAO dao = new NhanVienDAO();

        public int DangNhap(string username, string password)
        {
            return dao.DangNhapVaLayMaNV(username, password);
        }
        public List<NhanVien> LayDSNhanVien()
        {
            return dao.LayDSNhanVien();
        }

        public int ThemNhanVien(NhanVien nv)
        {
            return dao.ThemNhanVien(nv);
        }

        public bool CapNhatNhanVien(NhanVien nv)
        {
            return dao.CapNhatNhanVien(nv) > 0;
        }

        public bool XoaNhanVien(int maNV)
        {
            return dao.XoaNhanVien(maNV) > 0;
        }
        public static class NguoiDungDangNhap
        {
            public static string MaNV;
        }
        public List<NhanVien> LayDanhSachTenVaMa()
        {
            return dao.LayDanhSachTenVaMa();
        }

        public NhanVien LayThongTinNhanVienTheoMa(int maNV)
        {
            return dao.LayThongTinNhanVienTheoMa(maNV);
        }


    }

}
