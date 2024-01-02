using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface IPaymentTransactionRepository : IAppGenericDefaultKeyRepository<PaymentTransaction>
    {
        Task<PaymentTransaction> FindByTxnRef(string txnRef);
    }
}
