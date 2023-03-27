using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserAuthenticationApplication.DomainModel.Models.LoginDetails;
using UserAuthenticationApplication.DomainModel.Models.UserHistory;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;
using UserAuthenticationApplication.Repository.Login;

namespace UserAuthenticationApplication.DomainModel.ApplicationClass.Mapper
{
    public  class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap< UserRagistrationDetail, UserRegistration>().ReverseMap();
            CreateMap< UserRegistration , UserRagistrationDetail>().ReverseMap();
            CreateMap<LoginDetail, Login>().ReverseMap();
            CreateMap<Login , LoginDetail>().ReverseMap();  
            CreateMap<UserRegistration,UserHistory>().ReverseMap();
            
        }
    }
}
