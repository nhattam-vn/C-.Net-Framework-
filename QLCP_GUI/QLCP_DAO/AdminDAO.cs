using QLCP_DTO;
using System;
using System.Data.SqlClient;

namespace QLCP_DAO
{
    public class AdminDAO
    {
        string connectionString = @"Data Source=.;Initial Catalog=DB_BANDienThoai;Integrated Security=True;";

        private static AdminDAO instance;
        public static AdminDAO Instance
        {
            get
            {
                if (instance == null) instance = new AdminDAO();
                return instance;
            }
        }

        private AdminDAO() { }
        public int LayMaAdmin(string username)
        {
            int maAdmin = -1;
            string query = "SELECT MaAdmin FROM Admin WHERE UserName = @username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    maAdmin = Convert.ToInt32(result);
            }

            return maAdmin;
        }

        public Admin LayThongTinAdmin(int maAdmin)
        {
            Admin admin = null;
            string query = "SELECT * FROM Admin WHERE MaAdmin = @MaAdmin";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaAdmin", maAdmin);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    admin = new Admin
                    {
                        MaAdmin = (int)reader["MaAdmin"],
                        TenAdmin = reader["TenAdmin"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }

                reader.Close();
            }

            return admin;
        }


        public bool DoiMatKhau(int adminID, string matKhauMoi)
        {
            string query = "UPDATE Admin SET Password = @MatKhauMoi WHERE MaAdmin = @MaAdmin";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                cmd.Parameters.AddWithValue("@MaAdmin", adminID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
        }
        public bool Login(string username, string password)
        {
            

            string query = "SELECT COUNT(*) FROM Admin WHERE UserName = @username AND Password = @password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }
    }
}
