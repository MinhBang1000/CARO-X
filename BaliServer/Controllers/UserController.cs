using CARO_X.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
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

        // FUNCTION

        public bool Login(string user, string pass)
        {
            bool check = this.user.Select(user, pass);
            if (check)
            {
                // ....
            }
            else
            {
                return false;
            }
            return true;
        }

        public string SelectInfo(string user)
        {
            bool check = this.user.Select(user);
            string json = null;
            json = JsonConvert.SerializeObject(this.user);
            return json;
        }

    }
}
