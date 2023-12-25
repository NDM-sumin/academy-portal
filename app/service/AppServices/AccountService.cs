using AutoMapper;
using domain;
using domain.shared.AppSettings;
using domain.shared.Exceptions;
using Microsoft.Extensions.Options;
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
        readonly JwtConfiguration jwtConfiguration;
        readonly IEmailService emailService;
        public AccountService(IAccountRepository genericRepository, IMapper mapper, IOptions<JwtConfiguration> jwtOptions, IEmailService emailService)
            : base(genericRepository, mapper)
        {
            _accountRepository = genericRepository;
            jwtConfiguration = jwtOptions.Value;
            this.emailService = emailService;
        }

        public override Task<AccountDTO> Create(CreateAccountDTO entityDto)
        {
            HashService hashService = new HashService(entityDto.Password, jwtConfiguration.HashSalt);
            entityDto.Password = hashService.EncryptedPassword;
            return base.Create(entityDto);
        }
        public async Task<AccountNoPasswordDTO> GetAccountById(Guid accountId)
        {
       
            return Mapper.Map<AccountNoPasswordDTO>(await _accountRepository.Find(accountId));
        }

        public async Task ChangePassword(Guid id, ChangePasswordDTO changePasswordDTO)
        {
            var user = await _accountRepository.Find(id);
            HashService hashService = new HashService(changePasswordDTO.Password, jwtConfiguration.HashSalt);
            if (!hashService.IsPassed(user.Password))
            {
                throw new ClientException(5003);
            }
            user.Password = new HashService(changePasswordDTO.Password, jwtConfiguration.HashSalt).EncryptedPassword;
            await _accountRepository.Update(user);
        }

        public async Task<(string token, DateTime expire)> Login(LoginDTO accountDTO)
        {
            var account = await _accountRepository.GetAccountByUserName(accountDTO.Username);
            var hashService = new HashService(accountDTO.Password, jwtConfiguration.HashSalt);
            if (!hashService.IsPassed(account.Password))
            {
                throw new UnauthorizeException(5002);
            }
            return JwtService.GenerateJwtToken(jwtConfiguration.Key, jwtConfiguration.Subject, jwtConfiguration.Issuer, jwtConfiguration.Audience, jwtConfiguration.ValidTime, account.Id);
        }

        public async Task ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var account = await _accountRepository.GetAccountByUserName(forgotPasswordDTO.Username);
            if (account.Email != forgotPasswordDTO.Email) throw new ClientException(5001);
            string newPassword = Guid.NewGuid().GetHashCode().ToString();
            account.Password = new HashService(newPassword, jwtConfiguration.HashSalt).EncryptedPassword;
            var emailMessage = emailService.CreateMailMessage("CHANGE PASSWORD", $"Your password is {newPassword}", receivers: account.Email);
            await emailService.SendMessage(emailMessage);
            await _accountRepository.Update(account);
        }
    }
}
