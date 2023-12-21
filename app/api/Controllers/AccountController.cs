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


        public AccountController(IAccountService appCRUDService) : base(appCRUDService)
        {

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountDTO accountDTO)
        {
            return Ok(await (appCRUDService as IAccountService).Login(accountDTO));
        }

        [HttpPut("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            await (appCRUDService as IAccountService).ForgotPassword(forgotPasswordDTO);
            return Ok();

        }
        [HttpPut("ChangePassword")]
        public async Task ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            await (appCRUDService as IAccountService).ChangePassword(base.GetUserId(), changePasswordDTO);

        }

    }
}
