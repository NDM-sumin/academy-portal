using entityframework;

namespace service.contract.IAppServices.Base
{
    public interface IAppCRUDDefaultKeyService<TEntityDto, TEntity> : IAppCRUDAbstractKeyService<TEntityDto, TEntity, Guid>, ICRUDDefaultKeyService<TEntityDto, AppDbContext, TEntity>
        where TEntity : class
        where TEntityDto : class
    {
    }
}
