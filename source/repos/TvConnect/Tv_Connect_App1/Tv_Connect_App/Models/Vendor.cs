using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tv_Connect_App.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Vendor_Name { get; set; }
        public string Image_url { get; set; }
        public string Email { get; set; }
        public string Vendor_Pass { get; set; }
        public string Vendor_Address { get; set; }
        public string Vendor_contact { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public ICollection<Plan> Plans { get; set; }
    }
}
