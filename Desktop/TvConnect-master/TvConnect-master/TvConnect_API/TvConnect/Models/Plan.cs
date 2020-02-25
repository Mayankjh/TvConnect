using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvConnect.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public decimal Pack_Price { get; set; }
        public string Pack_Name { get; set; }
        public ICollection<Channel> Channel{get;set;}

    }
}
