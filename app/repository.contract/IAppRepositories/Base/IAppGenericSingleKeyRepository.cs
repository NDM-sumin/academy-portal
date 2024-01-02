using entityframework;

namespace repository.contract.IAppRepositories.Base
{
    public interface IAppGenericSingleKeyRepository<TEntity, TKey> :  IGenericSingleKeyRepository<AppDbContext, TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
    }
}
