using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Connect_App.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string User_Email { get; set; }
        public string User_Phone { get; set; }
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }
        public bool Recharge_status { get; set; }
        public DateTime Recharge_Due_Date { get; set; }
    }
}
