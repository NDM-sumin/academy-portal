using api.Controllers.Base;
using domain;
using domain.shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using service.AppServices;
using service.contract.DTOs;
using service.contract.DTOs.Account;
using service.contract.IAppServices;
using System.Security.Principal;

namespace api.Controllers
{
    public class AccountController : AppCRUDDefaultKeyWithOdataController<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Account>
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService appCRUDService) : base(appCRUDService)
        {
            _accountService = appCRUDService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountDTO accountDTO)
        {
            var account = await _accountService.GetAccountByUserName(accountDTO.Username);

            if (account == null)
            {
                throw new ClientException(5001);
            }

            if (!accountDTO.Password.Equals(account.Password))
            {
                throw new ClientException(5002);
            }

            return Ok(new
            {
                Token = JwtService.GenerateJwtToken(account.Id.ToString(), account.CreatedAt.ToString(), account.Username, account.ModifiedAt.ToString(), 45, account.Id).token
            });
        }

        [HttpPut]
        public async Task<IActionResult> ForgotPassword([FromBody] AccountDTO accountDTO)
        {
            var account = await _accountService.GetAccountByUserName(accountDTO.Username);
            if (account == null) throw new ClientException(5001);
            

            var accountAfterChange = await _accountService.ChangePassword(account.Id, accountDTO.Password);
            if (accountAfterChange == null) throw new ClientException();
            return Ok();
        }

    }
}
