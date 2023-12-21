using domain;
using service.contract.DTOs.Account;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IAccountService : IAppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Account>
    {
        Task<Account> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        Task<string> Login(AccountDTO accountDTO);
    }
}
