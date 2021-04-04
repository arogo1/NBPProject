using Account.Service.Models.DTO;
using Account.Service.Models.Request;
using AutoMapper;

namespace Account.WebApi.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UpdateAccountRequest, AccountDto>();

            CreateMap<CreateAccountRequest, AccountDto>()
                .ForMember(dest => dest.Role, src => src.MapFrom(map => map.Role));

            CreateMap<AccountDto, Domain.Account>()
                .ForMember(dest => dest.Role, src => src.MapFrom(map => map.Role)); ;

            CreateMap<Domain.Account, AccountDto>()
                .ForMember(dest => dest.Role, src => src.MapFrom(map => map.Role)); ;
        }
    }
}
