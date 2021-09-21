using CARO_X.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARO_X.Controllers
{
    class UserController
    {
        private User user;
        

        public UserController()
        {
            user = new User();
            
        }

        /// <summary>
        /// Xem xem có đăng nhập được hay không
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password, Dictionary<string, Object> data)
        {
            user.username = username;
            user.password = password;
            int check = user.Select(); //user_id here
            
            //DbDataReader reader = personal.Select();
            //if (reader.HasRows)
            //{
            //    reader.Read();
            //    data.Add("username",username);
            //    data.Add("name",reader.GetValue(1));
            //    data.Add("gender", reader.GetValue(2));
            //}
            return check != -1;
        } 

        
    }
}
