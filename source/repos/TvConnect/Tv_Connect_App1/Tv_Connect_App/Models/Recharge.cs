using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Entities;

namespace Tv_Connect_App.Models
{
    public class Recharge
    {
        public int RechargeId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime Recharge_time { get; set; }
        public bool Recharge_Status { get; set; }
        public DateTime Recharge_Date_Time { get; set; }
        public DateTime Recharge_Valid_Thru { get; set; }
        public int Duration_In_Months { get; set; }

    }
}
