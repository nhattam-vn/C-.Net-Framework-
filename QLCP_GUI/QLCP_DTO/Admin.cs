using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP_DTO
{
    public class Admin
    {
        public int MaAdmin { get; set; }
        public string TenAdmin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admin() { }

        public Admin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }


}
