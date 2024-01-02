using Microsoft.EntityFrameworkCore;

namespace repository.contract
{
    public interface IGenericSingleKeyRepository<TDbContext, TEntity, TKey> : IGenericAbstractKeyRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class
        where TKey : struct
    {
    }
}
