using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface IAccountRepository : IAppGenericDefaultKeyRepository<Account>
    {
        Task<Account> GetAccountById(Guid id);
        Task<Account> GetAccountByUserName(string userName);
    }
}
