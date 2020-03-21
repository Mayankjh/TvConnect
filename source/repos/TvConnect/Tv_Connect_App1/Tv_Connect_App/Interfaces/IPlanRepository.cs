using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Models;
using Plan = Tv_Connect_App.Models.Plan;

namespace Tv_Connect_App.Interfaces
{
   public interface IPlanRepository
    {
        public List<Plan> GetPlanList(Vendor vendor);
    }
}
