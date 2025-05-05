using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCP_DTO;

namespace QLCP_DAO
{
    public class NhanVienDAO
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;");


        public int DangNhapVaLayMaNV(string username, string password)
        {
            int maNV = -1; // Mặc định không tìm thấy

            string sql = "SELECT MaNV FROM NhanVien WHERE UserName = @user AND Password = @pass AND TrangThai = 1";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    maNV = Convert.ToInt32(result);
                }
            }

            return maNV; // Nếu login fail → trả về -1
        }


        public List<NhanVien> LayDSNhanVien()
        {
            List<NhanVien> ds = new List<NhanVien>();
            string query = "SELECT * FROM NhanVien WHERE TrangThai = 1";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = Convert.ToInt32(dr["MaNV"]),
                    MaAdmin = Convert.ToInt32(dr["MaAdmin"]),
                    TenNV = dr["TenNV"].ToString(),
                    GioiTinh = dr["GioiTinh"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    Luong = dr["Luong"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["Luong"]),
                    DiaChi = dr["DiaChi"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    Password = dr["Password"].ToString(),
                    TrangThai = dr["TrangThai"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["TrangThai"])
                };

                ds.Add(nv);
            }

            dr.Close();
            conn.Close();
            return ds;
        }

        // Thêm nhân viên
        public int ThemNhanVien(NhanVien nv)
        {
            string strInsert = "INSERT INTO NhanVien(MaNV, TenNV, GioiTinh, SDT, Luong, DiaChi, UserName, Password, TrangThai, MaAdmin) " +
                               "VALUES(@MaNV, @TenNV, @GioiTinh, @SDT, @Luong, @DiaChi, @User, @Pass, 1, @MaAdmin)";

            SqlParameter[] sp = new SqlParameter[9];
            sp[0] = new SqlParameter("@MaNV", nv.MaNV);
            sp[1] = new SqlParameter("@TenNV", nv.TenNV);
            sp[2] = new SqlParameter("@GioiTinh", nv.GioiTinh);
            sp[3] = new SqlParameter("@SDT", nv.SDT);
            sp[4] = new SqlParameter("@Luong", nv.Luong ?? (object)DBNull.Value);
            sp[5] = new SqlParameter("@DiaChi", nv.DiaChi);
            sp[6] = new SqlParameter("@User", nv.UserName);
            sp[7] = new SqlParameter("@Pass", nv.Password);
            sp[8] = new SqlParameter("@MaAdmin", nv.MaAdmin);

            SqlCommand cmd = new SqlCommand(strInsert, conn);
            cmd.Parameters.AddRange(sp);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Thêm log hoặc hiển thị lỗi nếu muốn
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
            }
            finally
            {
                conn.Close(); // luôn đóng connection kể cả lỗi
            }
        }


        // Cập nhật nhân viên
        public int CapNhatNhanVien(NhanVien nv)
        {
            string strUpdate = "UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, SDT = @SDT, Luong = @Luong, " +
                               "DiaChi = @DiaChi, UserName = @User, Password = @Pass, MaAdmin = @MaAdmin WHERE MaNV = @MaNV";

            SqlParameter[] sp = new SqlParameter[9];
            sp[0] = new SqlParameter("@TenNV", nv.TenNV);
            sp[1] = new SqlParameter("@GioiTinh", nv.GioiTinh);
            sp[2] = new SqlParameter("@SDT", nv.SDT);
            sp[3] = new SqlParameter("@Luong", nv.Luong ?? (object)DBNull.Value);
            sp[4] = new SqlParameter("@DiaChi", nv.DiaChi);
            sp[5] = new SqlParameter("@User", nv.UserName);
            sp[6] = new SqlParameter("@Pass", nv.Password);
            sp[7] = new SqlParameter("@MaAdmin", nv.MaAdmin);
            sp[8] = new SqlParameter("@MaNV", nv.MaNV); // đúng rồi

            SqlCommand cmd = new SqlCommand(strUpdate, conn);
            cmd.Parameters.AddRange(sp);

            conn.Open();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq;
        }

        // Xóa nhân viên
        public int XoaNhanVien(int maNV)
        {
            string strDelete = "UPDATE NhanVien SET TrangThai = 0 WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(strDelete, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery(); // trả về số dòng bị ảnh hưởng
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<NhanVien> LayDanhSachTenVaMa()
        {
            List<NhanVien> ds = new List<NhanVien>();
            string query = "SELECT MaNV, TenNV FROM NhanVien WHERE TrangThai = 1";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = Convert.ToInt32(dr["MaNV"]),
                    TenNV = dr["TenNV"].ToString()
                };
                ds.Add(nv);
            }

            dr.Close();
            conn.Close();

            return ds;
        }

        public NhanVien LayThongTinNhanVien(int maNV)
        {
            NhanVien nv = null;
            string query = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";

            using (conn)
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nv = new NhanVien
                    {
                        MaNV = (int)reader["MaNV"],
                        TenNV = reader["TenNV"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SDT = reader["SDT"].ToString(),
                        DiaChi = reader["DiaChi"].ToString()

                    };
                }

                reader.Close();
            }

            return nv;
        }
        public NhanVien LayThongTinNhanVienTheoMa(int maNV)
        {
            NhanVien nv = null;

            try
            {
                string query = "SELECT MaNV, TenNV, GioiTinh, SDT, DiaChi FROM NhanVien WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            nv = new NhanVien
                            {
                                MaNV = int.Parse(dr["MaNV"]?.ToString()),
                                TenNV = dr["TenNV"].ToString(),
                                GioiTinh = dr["GioiTinh"]?.ToString(),
                                SDT = dr["SDT"]?.ToString(),
                                DiaChi = dr["DiaChi"]?.ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log hoặc thông báo nếu cần
                throw new Exception("Lỗi khi lấy thông tin nhân viên theo mã: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return nv;
        }






    }
}




  
    

