using entityframework;

namespace service.contract.IAppServices.Base
{
    public interface IAppCRUDService<TEntityDto, TEntity> : ICRUDService<TEntityDto, AppDbContext, TEntity>
        where TEntity : class
        where TEntityDto : class
    {

    }
}
