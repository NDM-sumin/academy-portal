using domain;
using domain.shared.Exceptions;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class PaymentTransactionRepository : AppGenericDefaultKeyRepository<PaymentTransaction>, IPaymentTransactionRepository
    {
        public PaymentTransactionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PaymentTransaction> FindByTxnRef(string txnRef)
        {

            return await this.Entities.FirstOrDefaultAsync(c => c.TxnRef.Equals(txnRef)) 
                ?? throw new ServerException(5005);
        }
    }
}
