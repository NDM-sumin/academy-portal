using Microsoft.EntityFrameworkCore;

namespace repository.contract.IAppRepositories.Base
{
    public interface IAppGenericAbstractKeyRepository<TEntity, TKey> : IGenericAbstractKeyRepository<DbContext, TEntity, TKey>
        where TEntity : class
    {
    }
}
