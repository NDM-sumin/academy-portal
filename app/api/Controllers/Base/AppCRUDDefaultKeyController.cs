using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public class AppCRUDDefaultKeyController<TEntityDto, TEntity> : AppCRUDAbstractKeyController<TEntityDto, TEntity, Guid>
        where TEntity : class
        where TEntityDto : class
    {
        public AppCRUDDefaultKeyController(IAppCRUDDefaultKeyService<TEntityDto, TEntity> appCRUDService) : base(appCRUDService)
        {
        }
    }
}
