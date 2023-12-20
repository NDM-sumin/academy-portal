using domain.shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using repository.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class GenericSingleKeyRepository<TDbContext, TEntity, TKey> : GenericAbstractKeyRepository<TDbContext, TEntity, TKey>, IGenericSingleKeyRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class
        where TKey : struct
    {
        public GenericSingleKeyRepository(TDbContext context) : base(context)
        {
        }

        public override async Task<TEntity> Delete(TKey entityKey)
        {
            TEntity entity = await Find(entityKey);
            entity = Entities.Remove(entity).Entity;
            return entity;
        }

        public override async Task<TEntity> Find(TKey key, bool includeChild = true)
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
