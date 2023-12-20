using entityframework;

namespace repository.contract.IAppRepositories.Base
{
    public interface IAppGenericDefaultKeyRepository<TEntity> : IAppGenericSingleKeyRepository<TEntity, Guid>, IGenericDefaultKeyRepository<AppDbContext, TEntity>
        where TEntity : class
    {

    }
}
