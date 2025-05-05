using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLCP_DTO;

public class ChiTietHoaDon_DAO
{
    private static string connectionString = "Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;"; // sửa lại đúng chuỗi kết nối

    // Hàm lấy danh sách chi tiết hóa đơn
    public List<ChiTietHoaDon> LayDSChiTietHoaDon()
    {
        List<ChiTietHoaDon> ds = new List<ChiTietHoaDon>();
        string query = "SELECT * FROM ChiTietHoaDon"; // Hoặc thêm điều kiện WHERE nếu cần, ví dụ: WHERE SoHD = @SoHD

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon
                    {
                        SoHD = Convert.ToInt32(dr["SoHD"]),
                        MaSP = Convert.ToInt32(dr["MaSP"]),
                        SoLuong = Convert.ToInt32(dr["SoLuong"]),
                        DonGia = Convert.ToDecimal(dr["DonGia"]),
                        ThanhTien = Convert.ToDecimal(dr["ThanhTien"])
                    };

                    ds.Add(cthd);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết hóa đơn: " + ex.Message);
            }
        }

        return ds;
    }

    public bool CapNhatChiTietHoaDon(ChiTietHoaDon cthd)
    {
        string query = "UPDATE ChiTietHoaDon SET SoLuong = @SoLuong, DonGia = @DonGia, ThanhTien = @ThanhTien " +
                       "WHERE SoHD = @SoHD AND MaSP = @MaSP";

        SqlParameter[] sp = new SqlParameter[5];
        sp[0] = new SqlParameter("@SoLuong", cthd.SoLuong);
        sp[1] = new SqlParameter("@DonGia", cthd.DonGia);
        sp[2] = new SqlParameter("@ThanhTien", cthd.ThanhTien);
        sp[3] = new SqlParameter("@SoHD", cthd.SoHD);
        sp[4] = new SqlParameter("@MaSP", cthd.MaSP);

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
                MessageBox.Show("Lỗi khi cập nhật chi tiết hóa đơn: " + ex.Message);
                return false;
            }
        }
    }


}
