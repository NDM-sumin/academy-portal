using entityframework;

namespace repository.contract.IAppRepositories.Base
{
    public interface IAppGenericDefaultKeyRepository<TEntity> : IGenericDefaultKeyRepository<AppDbContext, TEntity>
        where TEntity : class
    {

    }
}
