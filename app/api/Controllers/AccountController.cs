using api.Controllers.Base;
using domain;
using domain.shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using service.AppServices;
using service.contract.DTOs;
using service.contract.DTOs.Account;
using service.contract.IAppServices;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace api.Controllers
{
    public class AccountController : AppCRUDDefaultKeyWithOdataController<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Account>
    {


        public AccountController(IAccountService appCRUDService) : base(appCRUDService)
        {

        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO accountDTO)
        {
            var result = await (appCRUDService as IAccountService).Login(accountDTO);
            return Ok(new { Token = result.token, Expires = result.expire });
        }

        [HttpPut("ForgotPassword")]
        [AllowAnonymous]
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
        [HttpGet("CurrentUser")]
        public async Task<AccountNoPasswordDTO> GetCurrenUser()
        {

            var userId = this.GetUserId();
            return await (appCRUDService as IAccountService).GetAccountById(userId);

        }

    }
}
