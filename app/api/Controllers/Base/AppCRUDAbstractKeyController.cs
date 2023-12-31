using Microsoft.AspNetCore.Mvc;
using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public class AppCRUDAbstractKeyController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> : AppCRUDController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity>
        where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public AppCRUDAbstractKeyController(IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> appCRUDService) : base(appCRUDService)
        {
        }
        [HttpGet("{key}")]
        public virtual async Task<ActionResult> Get([FromRoute] TKey key)
        {
            var data = await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>).Get(key);
            return Ok(data);
        }
        [HttpDelete("{key}")]
        public virtual async Task<TEntityDto> Delete([FromRoute] TKey key)
        {
            return await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>).Delete(key);
        }
    }
}
