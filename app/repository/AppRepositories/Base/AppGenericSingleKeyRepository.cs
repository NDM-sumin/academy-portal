using entityframework;
using repository.contract.IAppRepositories.Base;

namespace repository.AppRepositories.Base
{
    public class AppGenericSingleKeyRepository<TEntity, TKey> : GenericSingleKeyRepository<AppDbContext, TEntity, TKey>, IAppGenericSingleKeyRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        public AppGenericSingleKeyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
