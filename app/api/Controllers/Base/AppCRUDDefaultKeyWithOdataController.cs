using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public class AppCRUDDefaultKeyWithOdataController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> : AppCRUDSingleKeyWithOdataController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, Guid>
        where TEntityDto : class
        where TEntity : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public AppCRUDDefaultKeyWithOdataController(IAppCRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> appCRUDService) : base(appCRUDService)
        {
        }
    }
}
