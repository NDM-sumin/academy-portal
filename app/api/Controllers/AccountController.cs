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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountDTO accountDTO)
        {
            var response = await _accountService.Login(accountDTO);

            return Ok(response);
        }

        [HttpPut("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            var response = await _accountService.ForgotPassword(forgotPasswordDTO);
            
            return Ok(response);
        }

    }
}
