using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{

    [ODataRouteComponent("odata")]
    public abstract class AppCRUDSingleKeyWithOdataController<TEntityDto, TEntity, TKey> : AppCRUDAbstractKeyController<TEntityDto, TEntity, TKey>
        where TEntityDto : class
        where TEntity : class
        where TKey : struct
    {

        public AppCRUDSingleKeyWithOdataController(IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey> appCRUDService)
            : base(appCRUDService)
        {
        }

        public override async Task<TEntityDto> Create([FromBody] TEntityDto entityDto)
        {

            return await appCRUDService.Create(entityDto);
        }

        public override async Task<TEntityDto> Delete([FromODataUri] TKey key)
        {
            return await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey>).Delete(key);
        }

        [EnableQuery]
        [HttpGet("single")]
        public override async Task<ActionResult> Get([FromODataUri] TKey key)
        {
            var data = await (appCRUDService as IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey>).Get(key);
            return Ok(data);
        }
        [EnableQuery()]
        public override IActionResult GetQueryable()
        {
            return Ok(appCRUDService.GetQueryable());
        }

        public override async Task<TEntityDto> Update([FromBody] TEntityDto entityDto)
        {
            return await appCRUDService.Update(entityDto);
        }
    }
}
