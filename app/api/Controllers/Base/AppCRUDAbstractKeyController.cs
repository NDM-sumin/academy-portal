using Microsoft.AspNetCore.Mvc;
using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public abstract class AppCRUDAbstractKeyController<TEntityDto, TEntity, TKey> : AppCRUDController<TEntityDto, TEntity>
        where TEntity : class
        where TEntityDto : class
    {
        public AppCRUDAbstractKeyController(IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey> appCRUDService) : base(appCRUDService)
        {
        }
        [HttpGet("{key}")]
        public virtual async Task<ActionResult> Get(TKey key)
        {
            var data = await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey>).Get(key);
            return Ok(data);
        }
        [HttpDelete("{key}")]
        public virtual async Task<TEntityDto> Delete(TKey key)
        {
            return await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey>).Delete(key);
        }
    }
}
