using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;

namespace UserAuthenticationApplication.DomainModel.ApplicationClass.Mapper
{
    public  class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap< UserRagistrationDetail, UserRegistration>().ReverseMap();
            CreateMap< UserRegistration , UserRagistrationDetail>().ReverseMap();
            
        }
    }
}
