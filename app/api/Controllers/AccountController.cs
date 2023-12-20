using api.Controllers.Base;
using domain;
using service.contract.DTOs;
using service.contract.IAppServices;

namespace api.Controllers
{
    public class AccountController : AppCRUDDefaultKeyWithOdataController<AccountDTO, Account>
    {
        public AccountController(IAccountService appCRUDService) : base(appCRUDService)
        {
        }
    }
}
