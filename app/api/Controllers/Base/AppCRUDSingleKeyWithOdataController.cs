using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public class AppCRUDSingleKeyWithOdataController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> : AppCRUDAbstractKeyWithOdataController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>
        where TEntityDto : class
        where TEntity : class
        where TKey : struct
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {

        public AppCRUDSingleKeyWithOdataController(IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> appCRUDService)
            : base(appCRUDService)
        {
        }

  
        public override async Task<TEntityDto> Delete([FromODataUri] TKey key)
        {
            return await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>).Delete(key);
        }

        [EnableQuery]
        public override async Task<ActionResult> Get([FromODataUri] TKey key)
        {
            var data = await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>).Get(key);
            return Ok(data);
        }
    }
}
