using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Entities;
using Tv_Connect_App.Models;
using Tv_Connect_App.Models.Users;

namespace Tv_Connect_App.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<AdminRegisterModel, Admin>();
            CreateMap<UpdateModel, User>();
        }
    }
}
