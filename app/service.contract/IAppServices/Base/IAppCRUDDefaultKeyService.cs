using entityframework;

namespace service.contract.IAppServices.Base
{
    public interface IAppCRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> : IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, Guid>, ICRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, AppDbContext, TEntity>
        where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
    }
}
