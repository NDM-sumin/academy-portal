using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.contract;
using repository.contract.IAppRepositories.Base;

namespace repository.AppRepositories.Base
{
    public abstract class AppGenericAbstractKeyRepository<TEntity, TKey> : GenericAbstractKeyRepository<AppDbContext, TEntity, TKey>, IAppGenericAbstractKeyRepository<TEntity, TKey>
        where TKey : class
        where TEntity : class
    {
        protected AppGenericAbstractKeyRepository(AppDbContext context) : base(context)
        {
        }

        DbContext IGenericRepository<DbContext, TEntity>.Context => base.Context;
    }
}
