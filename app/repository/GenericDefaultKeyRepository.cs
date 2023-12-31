using domain.shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using repository.contract;

namespace repository
{
    public abstract class GenericDefaultKeyRepository<TDbContext, TEntity> : GenericSingleKeyRepository<TDbContext, TEntity, Guid>, IGenericDefaultKeyRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        protected GenericDefaultKeyRepository(TDbContext context) : base(context)
        {
        }

     
    }
}
