using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using API.DTO;
using API.Entities;


namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(){

            //CreateMap<RegisterDto, AppUser>();
            try
            {
                CreateMap<RegisterDto, AppUser>();
             //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }
    }
}