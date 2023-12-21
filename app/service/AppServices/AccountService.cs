using AutoMapper;
using domain;
using domain.shared.Exceptions;
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

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository genericRepository, IMapper mapper)
            : base(genericRepository, mapper)
        {
            _accountRepository = genericRepository;
        }

        public async Task<Account> GetAccountByUserName(string username)
        {
            var account = await _accountRepository.GetAccountByUserName(username);
            return account;
        }
        public async Task<Account> ChangePassword(Guid id, string password)
        {
            var account = await _accountRepository.GetAccountById(id);
            if (account == null) return null;
            return account;
        }
    }
}
