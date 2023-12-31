using entityframework;
using repository.contract.IAppRepositories.Base;

namespace repository.AppRepositories.Base
{
    public class AppGenericRepository<TEntity, TKey> : GenericRepository<AppDbContext, TEntity>, IAppGenericRepository<TEntity>
        where TEntity : class
        where TKey : struct
    {
        public AppGenericRepository(AppDbContext context) : base(context)
        {
        }
    }
}
