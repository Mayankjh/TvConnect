using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TvConnect.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string User_Email { get; set; }
        public string Password { get; set; }
        public string User_Phone { get; set; }
        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }
        public bool Recharge_status { get; set; }
        public DateTime Recharge_Due_Date { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
