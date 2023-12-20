using AutoMapper;
using domain;
using service.contract.DTOs.Account;

namespace service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Account, AccountDTO>().ReverseMap();
            this.CreateMap<Account, CreateAccountDTO>().ReverseMap();
            this.CreateMap<Account, UpdateAccountDTO>().ReverseMap();

        }
    }
}
