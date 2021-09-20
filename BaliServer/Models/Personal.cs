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
    class Personal
    {
        private SqlConnection connect;
        private DataBase dataBase;
        public int user_id;
        public string name;
        public int gender;
        public string avatar;

        public Personal()
        {
            this.dataBase = new DataBase();
            try
            {
                connect = new SqlConnection(dataBase.GetConn());
                connect.Open();
                Console.WriteLine("Connection DataBase Successful Models Personal");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Connection " + ex.ToString());
            }
        }

        /// <summary>
        /// Thêm thông tin cá nhân vào lúc đăng ký
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            string query = "INSERT INTO Personals(name,gender,user_id) VALUES (@name,@gender,@user_id)";
            SqlParameter name = new SqlParameter("@name",System.Data.SqlDbType.NVarChar);
            SqlParameter gender = new SqlParameter("@gender",System.Data.SqlDbType.Bit);
            SqlParameter user_id = new SqlParameter("@user_id",System.Data.SqlDbType.Int);
            name.Value = this.name;
            gender.Value = this.gender;
            user_id.Value = this.user_id;
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(gender);
            cmd.Parameters.Add(user_id);
            int check = cmd.ExecuteNonQuery();
            return check != 0;
        }

        /// <summary>
        /// Lấy thông tin người dùng 
        /// </summary>
        /// <returns>
        /// Trả về một đối tượng DataReader
        /// </returns>
        public DbDataReader Select()
        {
            string query = "SELECT * FROM Personals WHERE user_id = @user_id";
            SqlParameter user_id = new SqlParameter("@user_id", System.Data.SqlDbType.Int);
            user_id.Value = this.user_id;
            SqlCommand cmd = connect.CreateCommand();
            cmd.Parameters.Add(user_id);
            cmd.CommandText = query;
            return cmd.ExecuteReader();
        }
    }
}
