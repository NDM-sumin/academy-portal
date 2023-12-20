using entityframework;

namespace service.contract.IAppServices.Base
{
    public interface IAppCRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> : ICRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, AppDbContext, TEntity>
        where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {

    }
}
