using entityframework;
using repository.contract;

namespace repository.AppRepositories.Base
{
    public abstract class AppGenericAbstractKeyRepository<TEntity, TKey> : GenericAbstractKeyRepository<AppDbContext, TEntity, TKey>, IGenericAbstractKeyRepository<AppDbContext, TEntity, TKey>
        where TKey : class
        where TEntity : class
    {
        protected AppGenericAbstractKeyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
