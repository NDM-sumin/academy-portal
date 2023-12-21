using AutoMapper;
using domain;
using domain.shared.AppSettings;
using service.contract.DTOs.Account;
using service.contract.DTOs.Email;

namespace service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Account, AccountDTO>().ReverseMap();
            this.CreateMap<Account, CreateAccountDTO>().ReverseMap();
            this.CreateMap<Account, UpdateAccountDTO>().ReverseMap();
            this.CreateMap<Account, AccountNoPasswordDTO>().ReverseMap();
            this.CreateMap<MailConfiguration, SmtpConfigModel>().ReverseMap();

        }
    }
}
