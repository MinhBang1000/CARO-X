using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARO_X
{
    class DataBase
    {
        /// <summary>
        /// Các thông số để kết nối CSDL
        /// </summary>
        private string username = "sa";
        private string dbname = "CARO-X";
        private string password = "sa";
        private string charset = "utf8";
        private string conn = "";

        public DataBase()
        {
            this.conn = "Data Source=JARVIS\\JARVIS;Initial Catalog="+dbname+";Persist Security Info=True;User ID="+username+";Password="+password+"";
        }

        public string GetConn()
        {
            return this.conn;
        }

    }
}
