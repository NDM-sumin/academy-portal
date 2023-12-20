using api.Controllers.Base;
using domain;
using service.contract.DTOs.Account;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class AccountController : AppCRUDDefaultKeyWithOdataController<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Account>
    {
        public AccountController(IAccountService appCRUDService) : base(appCRUDService)
        {
        }
    }
}
