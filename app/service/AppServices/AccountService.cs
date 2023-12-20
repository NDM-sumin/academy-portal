using AutoMapper;
using domain;
using domain.shared.Exceptions;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs;
using service.contract.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.AppServices
{
    public class AccountService : AppCRUDDefaultKeyService<AccountDTO, Account>, IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository genericRepository, IMapper mapper)
            : base(genericRepository, mapper)
        {
            _accountRepository = genericRepository;
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            var user = await _accountRepository.GetAccountByUserName(username);

            return user != null && user.Password == password;
        }
    }
}
