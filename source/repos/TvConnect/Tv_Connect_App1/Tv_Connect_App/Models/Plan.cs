using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Connect_App.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public decimal Pack_Price { get; set; }
        public string Image_url { get; set; }
        public string Pack_Name { get; set; }
        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
        public ICollection<Channel> Channel { get; set; }
    }
}
