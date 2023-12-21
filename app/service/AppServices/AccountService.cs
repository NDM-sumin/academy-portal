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

        public async Task<string> Login(AccountDTO accountDTO)
        {
            var account = await _accountRepository.GetAccountByUserName(accountDTO.Username);

            if (account == null)
            {
                throw new ClientException(5001);
            }

            if (accountDTO.Password.Equals(account.Password))
            {
                throw new ClientException(5002);
            }

            return JwtService.GenerateJwtToken(String.Empty, String.Empty, String.Empty, String.Empty, 45, account.Id).token;
        }
        public async Task<Account> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var account = await _accountRepository.GetAccountByUserNameAndEmail(forgotPasswordDTO.Username, forgotPasswordDTO.Email);

            if (account != null)
            {
              
            }
            else
            {
                throw new ClientException(5001);
            }
        }
    }
}
