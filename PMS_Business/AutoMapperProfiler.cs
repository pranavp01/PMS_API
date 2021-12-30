using System;
using System.Collections.Generic;
using System.Text;
using PMS_Models;
using PMS_Repository.Dtos;
using AutoMapper;

namespace PMS_Business
{

    public class SingleObjectToListConverter<T> : ITypeConverter<T, List<T>>
    {
        public List<T> Convert(T source, List<T> destination, ResolutionContext context)
        {
            return new List<T>() { source };
        }
    }
    public class AutoMapperProfiler:Profile
    {


        public AutoMapperProfiler()
        {
            //CreateMap<AllergyModel, List<AllergyModel>>().ConvertUsing<SingleObjectToListConverter<AllergyModel>>();
            //CreateMap<EmergencyContactInfoModel, List<EmergencyContactInfoModel>>().ConvertUsing<SingleObjectToListConverter<EmergencyContactInfoModel>>();
            CreateMap<PatientModel, Patient>().ForMember(dest=>dest.Allergies,opt=>opt.MapFrom(src=>src.Allergys)).ForMember(dest=>dest.EmergencyContactInfo,opt=>opt.MapFrom(src=>src.EmergencyContactInfos)).ReverseMap();
            CreateMap<AllergyModel, Allergies>().ReverseMap();
            CreateMap<EmergencyContactInfoModel,EmergencyContactInfo>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap().ForPath(source => source.RoleName, destination => destination.MapFrom(src => src.RoleNavigation.Rolename));
            CreateMap<Roles, RolesModel>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)).ReverseMap();
        }
    }
}
