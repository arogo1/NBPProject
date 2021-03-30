using Account.Service.Models.DTO;
using AutoMapper;

namespace Account.Service.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AccountDto, Domain.Account>()
                .ForMember(dest => dest.Role, src => src.MapFrom(map => map.Role));

            CreateMap<Domain.Account, AccountDto > ()
                .ForMember(dest => dest.Role, src => src.MapFrom(map => map.Role)); ;
        }
    }
}
