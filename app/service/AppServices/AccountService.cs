using AutoMapper;
using domain;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Account;
using service.contract.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class AccountService : AppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Account>, IAccountService
    {
        public AccountService(IAccountRepository genericRepository, IMapper mapper)
            : base(genericRepository, mapper)
        {
        }
    }
}
