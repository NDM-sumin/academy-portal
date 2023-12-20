using entityframework;
using repository.contract;

namespace repository.AppRepositories.Base
{
    public class AppGenericDefaultKeyRepository<TEntity> : GenericDefaultKeyRepository<AppDbContext, TEntity>, IGenericDefaultKeyRepository<AppDbContext, TEntity>
        where TEntity : class
    {
        public AppGenericDefaultKeyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
