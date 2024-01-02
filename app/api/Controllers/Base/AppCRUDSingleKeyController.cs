using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public class AppCRUDSingleKeyController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> : AppCRUDAbstractKeyController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>
        where TEntityDto : class
        where TEntity : class
        where TKey : struct
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {

        public AppCRUDSingleKeyController(IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> appCRUDService)
            : base(appCRUDService)
        {
        }
    }
}
