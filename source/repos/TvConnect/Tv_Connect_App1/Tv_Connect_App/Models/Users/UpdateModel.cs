using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Connect_App.Models.Users
{
    public class UpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string User_Email { get; set; }
        public string User_Phone { get; set; }
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public ICollection<Recharge> Recharge { get; set; }
    }
}
