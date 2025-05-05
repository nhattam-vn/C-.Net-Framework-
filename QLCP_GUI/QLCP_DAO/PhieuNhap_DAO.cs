using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLCP_DTO;

namespace QLCP_DAO
{
    public class PhieuNhap_DAO
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;");

        public List<PhieuNhap> LayDSPhieuNhap()
        {
            List<PhieuNhap> ds = new List<PhieuNhap>();
            string query = "SELECT * FROM PhieuNhap";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PhieuNhap pn = new PhieuNhap
                {
                    MaPhieuNhap = Convert.ToInt32(dr["MaPhieuNhap"]),
                    MaNCC = Convert.ToInt32(dr["MaNCC"]),
                    NgayNhap = Convert.ToDateTime(dr["NgayNhap"]),
                    MaNV = Convert.ToInt32(dr["MaNV"])
                };

                ds.Add(pn);
            }

            dr.Close();
            conn.Close();
            return ds;
        }

        public int ThemPhieuNhap(PhieuNhap pn)
        {
            string strInsert = "INSERT INTO PhieuNhap (MaPhieuNhap, MaNCC, NgayNhap, MaNV, MaAdmin) " +
                   "VALUES (@MaPhieuNhap, @MaNCC, @NgayNhap, @MaNV, @MaAdmin)";


            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaPhieuNhap", pn.MaPhieuNhap); // mới thêm
            sp[1] = new SqlParameter("@MaNCC", pn.MaNCC);
            sp[2] = new SqlParameter("@NgayNhap", pn.NgayNhap);
            sp[3] = new SqlParameter("@MaNV", pn.MaNV);
            sp[4] = new SqlParameter("@MaAdmin", pn.MaAdmin);


            SqlCommand cmd = new SqlCommand(strInsert, conn);
            cmd.Parameters.AddRange(sp);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm phiếu nhập: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public int CapNhatPhieuNhap(PhieuNhap pn)
        {
            string strUpdate = "UPDATE PhieuNhap SET MaNCC = @MaNCC, NgayNhap = @NgayNhap, MaNV = @MaNV, MaAdmin = @MaAdmin WHERE MaPhieuNhap = @MaPhieuNhap";

            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@MaNCC", pn.MaNCC);
            sp[1] = new SqlParameter("@NgayNhap", pn.NgayNhap);
            sp[2] = new SqlParameter("@MaNV", pn.MaNV);
            sp[3] = new SqlParameter("@MaAdmin", pn.MaAdmin);
            sp[4] = new SqlParameter("@MaPhieuNhap", pn.MaPhieuNhap);

            SqlCommand cmd = new SqlCommand(strUpdate, conn);
            cmd.Parameters.AddRange(sp);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phiếu nhập: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public bool XoaPN(int maPN)
        {
            string query = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @maPN";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@maPN", maPN);

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xoá phiếu nhập: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
