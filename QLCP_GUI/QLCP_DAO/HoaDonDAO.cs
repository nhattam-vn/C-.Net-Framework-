using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLCP_DTO;

namespace QLCP_DAO
{
    public class HoaDonDAO
    {
        private readonly string connectionString = @"Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;";

        public List<HoaDon> LayDanhSachHoaDon()
        {
            List<HoaDon> ds = new List<HoaDon>();
            string query = "SELECT * FROM HoaDon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hd = new HoaDon
                    {
                        SoHD = Convert.ToInt32(reader["SoHD"]),
                        MaNV = Convert.ToInt32(reader["MaNV"]),
                        NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                        TienKhachDua = Convert.ToDecimal(reader["TienKhachDua"]),
                        // Thay 'TienKhachNhan' thành 'TienGuiKhach' (hoặc cột khác mà bạn muốn)
                        TienGuiKhach = Convert.ToDecimal(reader["TienGuiKhach"]),
                        TienThua = Convert.ToDecimal(reader["TienThua"]),
                        TrangThaiHD = Convert.ToByte(reader["TrangThaiHD"])
                    };
                    ds.Add(hd);
                }

                reader.Close();
            }

            return ds;
        }

        public bool ThemHoaDon(HoaDon hd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO HoaDon 
        (SoHD, MaNV, MaKH, MaAdmin, NgayLap, TienKhachDua, TienGuiKhach, ThanhTien, TienThua, PhuongThucTT, TrangThaiHD) 
        VALUES 
        (@SoHD, @MaNV, @MaKH, @MaAdmin, @NgayLap, @TienKhachDua, @TienGuiKhach, @ThanhTien, @TienThua, @PhuongThucTT, @TrangThaiHD)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoHD", hd.SoHD);
                cmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
                cmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
                cmd.Parameters.AddWithValue("@MaAdmin", hd.MaAdmin);
                cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmd.Parameters.AddWithValue("@TienKhachDua", hd.TienKhachDua);
                cmd.Parameters.AddWithValue("@TienGuiKhach", hd.TienGuiKhach);
                cmd.Parameters.AddWithValue("@ThanhTien", hd.ThanhTien);
                cmd.Parameters.AddWithValue("@TienThua", hd.TienThua);
                cmd.Parameters.AddWithValue("@PhuongThucTT", hd.PhuongThucTT);
                cmd.Parameters.AddWithValue("@TrangThaiHD", hd.TrangThaiHD);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                return rows > 0;
            }
        }

        public bool XoaHoaDon(int soHD)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Xóa trước các chi tiết hóa đơn (bảng con)
                SqlCommand cmd1 = new SqlCommand("DELETE FROM ChiTietHoaDon WHERE SoHD = @SoHD", conn);
                cmd1.Parameters.AddWithValue("@SoHD", soHD);
                cmd1.ExecuteNonQuery();

                // Sau đó mới xóa hóa đơn (bảng cha)
                SqlCommand cmd2 = new SqlCommand("DELETE FROM HoaDon WHERE SoHD = @SoHD", conn);
                cmd2.Parameters.AddWithValue("@SoHD", soHD);
                int result = cmd2.ExecuteNonQuery();

                return result > 0;
            }
        }


    }
}
