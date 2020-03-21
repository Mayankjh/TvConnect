using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Connect_App.Models
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public string Channel_Name { get; set; }
        public decimal ChannelPrice { get; set; }
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }

    }
}
