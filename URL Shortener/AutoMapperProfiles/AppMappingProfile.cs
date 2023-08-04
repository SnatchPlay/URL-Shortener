using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.DTO;

namespace URL_Shortener.AutoMapperProfiles
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<Role,RoleDTO>().ReverseMap();
            CreateMap<ShortLink,ShortLinkDTO>().ReverseMap();
        }
    }
}
