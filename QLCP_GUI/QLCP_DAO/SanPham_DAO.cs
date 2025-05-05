using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCP_DTO;
namespace QLCP_DAO
{
    public class SanPham_DAO
    {
        

        
        static string strKetNoi = "Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;";

        public static List<SanPham> LoadDSSanPham()
        {
            List<SanPham> dsSanPham = new List<SanPham>();
            SqlConnection conn = new SqlConnection(strKetNoi);
            try
            {
                conn.Open();
                string query = "SELECT * FROM SanPham"; // tên bảng trong CSDL
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    SanPham sp = new SanPham();
                    sp.MaSP = int.Parse(dr["MaSP"].ToString());
                    sp.TenSP = dr["TenSP"].ToString();
                    sp.GiaBan = decimal.Parse(dr["GiaBan"].ToString());
                    sp.SoLuong = int.Parse(dr["SoLuong"].ToString());
                    sp.TrangThai = byte.Parse(dr["TrangThai"].ToString());

                    dsSanPham.Add(sp);
                }

                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                // Tùy bạn có dùng Winform thì dùng MessageBox, còn không thì in ra lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return dsSanPham;
        }

        public static bool ThemSanPham(SanPham sp)
        {
            SqlConnection conn = new SqlConnection(strKetNoi);
            try
            {
                conn.Open();
                string query = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuong, TrangThai) " +
                               "VALUES (@MaSP, @TenSP, @GiaBan, @SoLuong, @TrangThai)";

                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.Add(new SqlParameter("@MaSP", sp.MaSP));
                comm.Parameters.Add(new SqlParameter("@TenSP", sp.TenSP));
                comm.Parameters.Add(new SqlParameter("@GiaBan", sp.GiaBan));
                comm.Parameters.Add(new SqlParameter("@SoLuong", sp.SoLuong));
                comm.Parameters.Add(new SqlParameter("@TrangThai", sp.TrangThai));

                int kq = comm.ExecuteNonQuery();
                conn.Close();
                return kq > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Nếu dùng WinForm
                                             // Console.WriteLine(ex.Message); // Nếu dùng Console App
            }
            return false;
        }


        public static bool SuaSanPham(SanPham sp)
        {
            SqlConnection conn = new SqlConnection(strKetNoi);
            try
            {
                conn.Open();
                string query = "UPDATE SanPham SET TenSP=@TenSP, GiaBan=@GiaBan, SoLuong=@SoLuong, TrangThai=@TrangThai WHERE MaSP=@MaSP";

                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.Add(new SqlParameter("@MaSP", sp.MaSP));
                comm.Parameters.Add(new SqlParameter("@TenSP", sp.TenSP));
                comm.Parameters.Add(new SqlParameter("@GiaBan", sp.GiaBan));
                comm.Parameters.Add(new SqlParameter("@SoLuong", sp.SoLuong));
                comm.Parameters.Add(new SqlParameter("@TrangThai", sp.TrangThai));

                int kq = comm.ExecuteNonQuery();
                conn.Close();
                return kq > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool XoaSanPham(int maSP)
        {
            SqlConnection conn = new SqlConnection(strKetNoi);
            try
            {
                conn.Open();
                string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.Add(new SqlParameter("@MaSP", maSP));

                int kq = comm.ExecuteNonQuery();
                conn.Close();
                return kq > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message);
            }
            return false;
        }

        public static List<SanPham> LayDanhSachMaVaTen()
        {
            List<SanPham> ds = new List<SanPham>();

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                conn.Open();
                string query = "SELECT MaSP, TenSP FROM SanPham";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SanPham sp = new SanPham
                    {
                        MaSP = Convert.ToInt32(dr["MaSP"]),
                        TenSP = dr["TenSP"].ToString()
                        // Không cần gán các trường còn lại
                    };
                    ds.Add(sp);
                }

                dr.Close();
            }

            return ds;
        }

        public static decimal LayGiaBanTheoMaSP(int maSP)
        {
            decimal gia = 0;
            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                conn.Open();
                string query = "SELECT GiaBan FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    gia = Convert.ToDecimal(result);
                }
            }
            return gia;
        }

    }

}



