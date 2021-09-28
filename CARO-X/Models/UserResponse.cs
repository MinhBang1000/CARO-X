using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARO_X.Models
{
    public class UserResponse
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string avatar { get; set; }
        public int gender { get; set; }
        public int total_score { get; set; }
        public int total_battle { get; set; }
        public int total_win { get; set; }
    }
}
