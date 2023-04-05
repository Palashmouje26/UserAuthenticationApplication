using AutoMapper;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.LoginDTO;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.UserRagistrationDTO;
using UserAuthenticationApplication.DomainModel.Models.UserHistory;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.Repository.Login;

namespace UserAuthenticationApplication.DomainModel.ApplicationClass.Mapper
{
    public  class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRagistrationDetailDTO, UserRegistration>().ReverseMap();
            CreateMap< UserRegistration , UserRagistrationDetailDTO>().ReverseMap();
            CreateMap<LoginDetailDTO, Login>().ReverseMap();
            CreateMap<Login , LoginDetailDTO>().ReverseMap();  
            CreateMap<UserRegistration,UserHistory>().ReverseMap();
            
        }
    }
}
