using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public class AppCRUDDefaultKeyController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> : AppCRUDSingleKeyController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, Guid>
        where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public AppCRUDDefaultKeyController(IAppCRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> appCRUDService) : base(appCRUDService)
        {
        }
    }
}
