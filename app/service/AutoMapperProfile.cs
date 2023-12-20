using AutoMapper;
using domain;
using service.contract.DTOs;

namespace service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Account, AccountDTO>().ReverseMap();

        }
    }
}
