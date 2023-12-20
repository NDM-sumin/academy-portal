using api.Controllers.Base;
using domain;
using domain.shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using service.contract.DTOs;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class AccountController : AppCRUDDefaultKeyWithOdataController<AccountDTO, Account>
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService appCRUDService) : base(appCRUDService)
        {
            _accountService = appCRUDService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountDTO accountDTO)
        {
            var isValid = await _accountService.ValidateCredentials(accountDTO.Username, accountDTO.Password);

            if (!isValid)
            {
                return Unauthorized(new { Message = "Login failed" });
            }

            return Ok(new { Message = "Login successful" });
        }

        public IActionResult Logout()
        {
            return Ok(new { Message = "Logout successful" });
        }
    }
}
