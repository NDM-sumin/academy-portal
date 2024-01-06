using domain;
using entityframework;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class FeeDetailRepository : AppGenericDefaultKeyRepository<FeeDetail>, IFeeDetailRepository
    {
        public FeeDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
