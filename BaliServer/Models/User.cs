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
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string avatar { get; set; }
        public int gender { get; set; }
        public int total_score { get; set; }
        public int total_battle { get; set; }
        public int total_win { get; set; }

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

        // FUNCTION
        public void Connect()
        {
            this.dataBase = new DataBase();
            try
            {
                connect = new SqlConnection(dataBase.GetConn());
                connect.Open();
                Console.WriteLine("Connection DataBase Successful Models User");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Connection " + ex.ToString());
            }
        }

        public bool Select(string username, string password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Users WHERE username = @USERNAME and password = @PASSWORD";
            cmd.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar).Value = password;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    this.username = reader.GetString(1);
                    this.password = "****";
                    this.fullname = reader.GetString(3);
                    this.avatar = reader.GetString(4);
                    this.gender = reader.GetInt32(5);
                    this.total_score = reader.GetInt32(6);
                    this.total_win = reader.GetInt32(7);
                    this.total_battle = reader.GetInt32(8);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool Select(string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM Users WHERE username = @USERNAME";
            cmd.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar).Value = username;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    this.username = reader.GetString(1);
                    this.password = "****";
                    this.fullname = reader.GetString(3);
                    this.avatar = reader.GetString(4);
                    this.gender = reader.GetInt32(5);
                    this.total_score = reader.GetInt32(6);
                    this.total_win = reader.GetInt32(7);
                    this.total_battle = reader.GetInt32(8);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool Insert()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO Users(username,password,fullname,gender,avatar,total_score,total_win,total_battle)" +
                " VALUES(@USERNAME,@PASSWORD,@FULLNAME,@GENDER,@AVATAR,@TOTAL_SCORE,@TOTAL_WIN,@TOTAL_BATTLE)";
            cmd.Parameters.Add("@USERNAME",System.Data.SqlDbType.VarChar).Value = this.username;
            cmd.Parameters.Add("@PASSWORD",System.Data.SqlDbType.VarChar).Value = this.password;
            cmd.Parameters.Add("@FULLNAME",System.Data.SqlDbType.NVarChar).Value = this.fullname;
            cmd.Parameters.Add("@GENDER",System.Data.SqlDbType.Int).Value = this.gender;
            cmd.Parameters.Add("@TOTAL_SCORE",System.Data.SqlDbType.Int).Value = this.total_score;
            cmd.Parameters.Add("@TOTAL_WIN",System.Data.SqlDbType.Int).Value = this.total_win;
            cmd.Parameters.Add("@TOTAL_BATTLE",System.Data.SqlDbType.Int).Value = this.total_battle;
            cmd.Parameters.Add("@AVATAR", System.Data.SqlDbType.VarChar).Value = this.avatar;
            int count = cmd.ExecuteNonQuery();
            return count != 0;
        }

        public bool UpdatePlusWin(string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE Users SET total_score=total_score+1, total_battle=total_battle+1,total_win=total_win+1 WHERE username = @USERNAME";
            cmd.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar).Value = username;
            int count = cmd.ExecuteNonQuery();
            return count != 0;
        } // Cộng điểm cho người thắng

        public bool UpdatePlusLost(string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE Users SET total_battle=total_battle+1 WHERE username = @USERNAME";
            cmd.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar).Value = username;
            int count = cmd.ExecuteNonQuery();
            return count != 0;
        } // Cộng điểm cho người thua
    }
}
