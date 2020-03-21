using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Helpers;
using Tv_Connect_App.Interfaces;
using Tv_Connect_App.Models;

namespace Tv_Connect_App.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly DataContext _context;
        public  PlanRepository(DataContext context)
        {

            _context = context;

        }
        public List<Plan> GetPlanList(Vendor vendor)
        {
            return _context.plans.Where(c => c.VendorId == vendor.VendorId).ToList();
        }
    }
}
