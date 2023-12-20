using domain;
using service.contract.DTOs;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IAccountService : IAppCRUDDefaultKeyService<AccountDTO, Account>
    {
    }
}
