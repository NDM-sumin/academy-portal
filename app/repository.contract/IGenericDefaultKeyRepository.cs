using Microsoft.EntityFrameworkCore;

namespace repository.contract
{
    public interface IGenericDefaultKeyRepository<TDbContext, TEntity> : IGenericAbstractKeyRepository<TDbContext, TEntity, Guid>
        where TDbContext : DbContext
        where TEntity : class
    {

    }
}
