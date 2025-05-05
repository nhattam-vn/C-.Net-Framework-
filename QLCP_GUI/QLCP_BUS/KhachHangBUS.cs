    using QLCP_DAO;
    using QLCP_DTO;
    using System;
    using System.Collections.Generic;

    namespace QLCP_BUS
    {
        public class KhachHangBUS
        {
            private readonly KhachHangDAO dao = new KhachHangDAO();


            public bool DangKyKhachHang(KhachHang kh)
            {
                if (dao.KiemTraTrungUser(kh.User))
                {
                    throw new System.Exception("Tên đăng nhập đã tồn tại!");
                }

                // Gọi DAO để thêm khách hàng
                return dao.ThemKhachHang(kh);
            }
            public List<KhachHang> LayDanhSachKhachHang()
            {
                KhachHangDAO dao = new KhachHangDAO();
                return dao.LayDanhSachKhachHang();
            }




        }
    }
