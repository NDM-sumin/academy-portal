using entityframework;

namespace service.contract.IAppServices.Base
{
    public interface IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> : IAppCRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity>, ICRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, AppDbContext, TEntity, TKey>
        where TEntityDto : class
        where TEntity : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
    }
}
