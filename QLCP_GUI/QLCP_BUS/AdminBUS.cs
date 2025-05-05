using QLCP_DAO;
using QLCP_DTO;

namespace QLCP_BUS
{
    public class AdminBUS
    {
        public bool Login(string username, string password)
        {
            return AdminDAO.Instance.Login(username, password);
        }

        public int LayMaAdminTuDangNhap(string username)
        {
            return AdminDAO.Instance.LayMaAdmin(username);
        }

        public Admin LayThongTinAdmin(int maAdmin)
        {
            return AdminDAO.Instance.LayThongTinAdmin(maAdmin);
        }

        public bool DoiMatKhau(int adminID, string matKhauMoi)
        {
            return AdminDAO.Instance.DoiMatKhau(adminID, matKhauMoi);
        }
    }
}
