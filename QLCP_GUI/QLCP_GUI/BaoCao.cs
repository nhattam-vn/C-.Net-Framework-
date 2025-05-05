using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLCP_GUI
{
    public partial class BaoCao : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;");

        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            try
            {
                conn.Open();

                string query = @"SELECT 
                    (SELECT COUNT(*) FROM HoaDon) AS SoLuongHoaDon,
                    (SELECT ISNULL(SUM(SoLuong), 0) FROM ChiTietHoaDon) AS TongSoSanPham,
                    (SELECT ISNULL(SUM(ThanhTien), 0) FROM HoaDon) AS TongDoanhThu";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblSoHD.Text = reader["SoLuongHoaDon"].ToString();
                    lblSoSanPham.Text = reader["TongSoSanPham"].ToString();
                    decimal doanhThu = reader["TongDoanhThu"] != DBNull.Value ? Convert.ToDecimal(reader["TongDoanhThu"]) : 0;
                    lblDoanhThu.Text = doanhThu.ToString("N0");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
