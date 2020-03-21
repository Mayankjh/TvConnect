using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Tv_Connect_App.Models;
using Channel = Tv_Connect_App.Models.Channel;

namespace Tv_Connect_App.Interfaces
{
    public interface IChannelRepository
    {
        public List<Channel> GetChannelList(Plan plan);
    
    }
}
