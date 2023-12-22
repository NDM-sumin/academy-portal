using domain;
using service.contract.DTOs.Account;
using service.contract.IAppServices.Base;

namespace service.contract.IAppServices
{
    public interface IAccountService : IAppCRUDDefaultKeyService<AccountDTO, CreateAccountDTO, UpdateAccountDTO, Account>
    {
        Task<AccountNoPasswordDTO> GetAccountById(Guid accountId);
        Task ChangePassword(Guid id, ChangePasswordDTO changePasswordDTO);
        Task<(string token, DateTime expire)> Login(AccountDTO accountDTO);
        Task ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
    }
}
