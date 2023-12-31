using Microsoft.EntityFrameworkCore;
using repository.contract;

namespace repository
{
    public abstract class GenericAbstractKeyRepository<TDbContext, TEntity, TKey> : GenericRepository<TDbContext, TEntity>, IGenericAbstractKeyRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class
    {
        protected GenericAbstractKeyRepository(TDbContext context) : base(context)
        {
        }

        public abstract Task<TEntity> Delete(TKey entityKey);

        public abstract Task<TEntity> Find(TKey key, bool includeChild = true);
    }
}
