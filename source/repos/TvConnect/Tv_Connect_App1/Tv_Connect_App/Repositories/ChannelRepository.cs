using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Helpers;
using Tv_Connect_App.Interfaces;
using Tv_Connect_App.Models;

namespace Tv_Connect_App.Repositories
{

    public class ChannelRepository : IChannelRepository
    {
        private readonly DataContext _context;
        public ChannelRepository(DataContext context)
        {

            _context = context;

        }
        public List<Channel> GetChannelList(Plan plan)
        {
            return _context.channels.Where(c=>c.PlanId == plan.PlanId).ToList();
        }
    }
}
