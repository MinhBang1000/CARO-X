using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARO_X.Models
{
    class User
    {
        private SqlConnection connect;
        private DataBase dataBase;
        public string username;
        public string password;
        public string fullname;
        public string avatar;
        public int gender;
        public int total_score;
        public int total_battle;
        public int total_win;

        public User()
        {
            this.dataBase = new DataBase();
            try
            {
                connect = new SqlConnection(dataBase.GetConn());
                connect.Open();
                Console.WriteLine("Connection DataBase Successful Models User");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't Connection "+ex.ToString());
            }
        }

        /// <summary>
        /// Hàm thêm tài khoản
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            string query = "INSERT INTO Users(username,password) VALUES(@username,@password)";
            SqlCommand stmt = connect.CreateCommand();
            stmt.CommandText = query;
            SqlParameter username = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
            SqlParameter password = new SqlParameter("@password", System.Data.SqlDbType.VarChar);
            username.Value = this.username;
            password.Value = this.password;
            stmt.Parameters.Add(username);
            stmt.Parameters.Add(password);
            int check = stmt.ExecuteNonQuery();
            return check != 0;
        }

        /// <summary>
        /// Kiểm tra tài khoản có tồn tại hay không
        /// </summary>
        /// <returns>
        /// Trả về user_id tìm được
        /// </returns>
        public int Select()
        {
            string query = "SELECT * FROM Users WHERE username = @username AND password = @password";
            SqlCommand stmt = connect.CreateCommand();
            stmt.CommandText = query;
            SqlParameter username = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
            SqlParameter password = new SqlParameter("@password", System.Data.SqlDbType.VarChar);
            username.Value = this.username;
            password.Value = this.password;
            stmt.Parameters.Add(username);
            stmt.Parameters.Add(password);
            DbDataReader reader = stmt.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int user_id = Convert.ToInt32(reader.GetValue(0));
                return user_id;
            }
            return -1;
        }
    }
}
