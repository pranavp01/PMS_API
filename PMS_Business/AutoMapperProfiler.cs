using System;
using System.Collections.Generic;
using System.Text;
using PMS_Models;
using PMS_Repository.Dtos;
using AutoMapper;

namespace PMS_Business
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<PatientModel, Patient>().ReverseMap();
            CreateMap<UserModel, User>().ForMember(dest => dest.RoleNavigation, opt => opt.MapFrom(src => src.Roles)).
                ReverseMap();
           
            CreateMap<RolesModel, Roles>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)).ReverseMap();
        }
    }
}
