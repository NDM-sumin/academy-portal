using Microsoft.EntityFrameworkCore;

namespace repository.contract
{
    public interface IGenericDefaultKeyRepository<TDbContext, TEntity> : IGenericSingleKeyRepository<TDbContext, TEntity, Guid>
        where TDbContext : DbContext
        where TEntity : class
    {

    }
}
