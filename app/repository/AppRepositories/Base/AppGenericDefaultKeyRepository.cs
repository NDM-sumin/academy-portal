using entityframework;
using repository.contract;
using repository.contract.IAppRepositories.Base;

namespace repository.AppRepositories.Base
{
    public class AppGenericDefaultKeyRepository<TEntity> : GenericDefaultKeyRepository<AppDbContext, TEntity>, IAppGenericDefaultKeyRepository<TEntity>
        where TEntity : class
    {
        public AppGenericDefaultKeyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
