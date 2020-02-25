using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Connect_App.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Admin_Email { get; set; }
        public string Admin_Pass { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
