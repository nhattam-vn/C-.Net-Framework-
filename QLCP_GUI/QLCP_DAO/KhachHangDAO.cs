using QLCP_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLCP_DAO
{
    public class KhachHangDAO
    {
        private readonly string connectionString = @"Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;";
        //tao tai khoan
        public bool ThemKhachHang(KhachHang kh)
        {
            string query = "INSERT INTO KhachHang (MaKH, MaNV, TenKH, DiaChi, SDT, NgayTao, TrangThai, Email, UserName, Password) " +
               "VALUES (@MaKH, @MaNV, @TenKH, @DiaChi, @SDT, @NgayTao, @TrangThai, @Email, @UserName, @Password)";

            SqlParameter[] sp = new SqlParameter[10];
            sp[0] = new SqlParameter("@MaKH", kh.MaKH);
            sp[1] = new SqlParameter("@MaNV", kh.MaNV);
            sp[2] = new SqlParameter("@TenKH", kh.TenKH);
            sp[3] = new SqlParameter("@DiaChi", kh.DiaChi);
            sp[4] = new SqlParameter("@SDT", kh.SDT);
            sp[5] = new SqlParameter("@NgayTao", kh.NgayTao);
            sp[6] = new SqlParameter("@TrangThai", kh.TrangThai);
            sp[7] = new SqlParameter("@Email", kh.Email);
            sp[8] = new SqlParameter("@UserName", kh.User);
            sp[9] = new SqlParameter("@Password", kh.Pass);

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(sp);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<KhachHang> LayDanhSachKhachHang()
        {
            List<KhachHang> danhSachKH = new List<KhachHang>();
            string query = "SELECT MaKH, MaNV, TenKH, DiaChi, SDT, NgayTao, TrangThai, Email, UserName, Password FROM KhachHang";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var kh = new KhachHang
                    {
                        MaKH = reader.GetInt32(reader.GetOrdinal("MaKH")),
                        MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                        TenKH = reader.GetString(reader.GetOrdinal("TenKH")),
                        DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                        SDT = reader.IsDBNull(reader.GetOrdinal("SDT")) ? "" : reader.GetString(reader.GetOrdinal("SDT")),
                        NgayTao = reader.GetDateTime(reader.GetOrdinal("NgayTao")),
                        TrangThai = reader.GetInt32(reader.GetOrdinal("TrangThai")),
                        Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                        User = reader.GetString(reader.GetOrdinal("UserName")),
                        Pass = reader.GetString(reader.GetOrdinal("Password"))
                    };

                    danhSachKH.Add(kh);
                }

                reader.Close();
            }

            return danhSachKH;
        }


        //ktra xem user có bị trùng hay không
        public bool KiemTraTrungUser(string username)
        {
            string query = "SELECT COUNT(*) FROM KhachHang WHERE UserName = @UserName";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
