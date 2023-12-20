using entityframework;

namespace service.contract.IAppServices.Base
{
    public interface IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey> : IAppCRUDService<TEntityDto, TEntity>, ICRUDAbstractKeyService<TEntityDto, AppDbContext, TEntity, TKey>
        where TEntityDto : class
        where TEntity : class
    {
    }
}
