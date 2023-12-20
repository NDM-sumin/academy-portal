using entityframework;

namespace repository.contract.IAppRepositories.Base
{
    public interface IAppGenericRepository<TEntity> : IGenericRepository<AppDbContext, TEntity>
        where TEntity : class
    {
    }
}
