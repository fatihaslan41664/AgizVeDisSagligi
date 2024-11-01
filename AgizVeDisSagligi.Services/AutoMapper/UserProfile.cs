using AgizVeDisSagligi.Entity.DTOs;
using AgizVeDisSagligi.Entity.Entites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDto, User>().ReverseMap();
        }
    }
}
