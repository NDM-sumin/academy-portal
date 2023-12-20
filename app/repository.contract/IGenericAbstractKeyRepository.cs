using Microsoft.EntityFrameworkCore;

namespace repository.contract
{
    public interface IGenericAbstractKeyRepository<TDbContext, TEntity, TKey> : IGenericRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {

        Task<TEntity> Delete(TKey entityKey);
        Task<TEntity> Find(TKey key, bool includeChild = true);
    }
}
