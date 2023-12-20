using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public class AppCRUDDefaultKeyWithOdataController<TEntityDto, TEntity> : AppCRUDSingleKeyWithOdataController<TEntityDto, TEntity, Guid>
        where TEntityDto : class
        where TEntity : class
    {
        public AppCRUDDefaultKeyWithOdataController(IAppCRUDDefaultKeyService<TEntityDto, TEntity> appCRUDService) : base(appCRUDService)
        {
        }
    }
}
