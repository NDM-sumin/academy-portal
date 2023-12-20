using domain.shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using repository.contract;

namespace repository
{
    public abstract class GenericDefaultKeyRepository<TDbContext, TEntity> : GenericRepository<TDbContext, TEntity>, IGenericDefaultKeyRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        protected GenericDefaultKeyRepository(TDbContext context) : base(context)
        {
        }

        public virtual async Task<TEntity> Delete(Guid entityKey)
        {
            TEntity entity = await Find(entityKey);
            entity = Entities.Remove(entity).Entity;
            return entity;
        }

        public virtual async Task<TEntity> Find(Guid key, bool includeChild = true)
        {
            var data = await Entities.FindAsync(key)
                ?? throw new ClientException(4040);
            if (includeChild)
            {
                foreach (var navigation in Context.Entry(data).Navigations)
                {
                    await navigation.LoadAsync();
                }

            }
            return data;
        }
    }
}
