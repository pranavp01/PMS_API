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
            CreateMap<UserModel, User>().ReverseMap().ForPath(source => source.RoleName, destination => destination.MapFrom(src => src.RoleNavigation.Rolename));
            CreateMap<RolesModel, Roles>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)).ReverseMap();
        }
    }
}
