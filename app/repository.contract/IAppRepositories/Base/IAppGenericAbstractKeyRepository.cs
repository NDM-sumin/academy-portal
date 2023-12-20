using Microsoft.EntityFrameworkCore;

namespace repository.contract.IAppRepositories.Base
{
    public interface IAppGenericAbstractKeyRepository<TEntity, TKey> : IAppGenericRepository<TEntity>, IGenericAbstractKeyRepository<DbContext, TEntity, TKey>
        where TEntity : class
    {
    }
}
