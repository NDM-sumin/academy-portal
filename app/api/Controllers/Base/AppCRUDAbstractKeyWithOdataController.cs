using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{

    [ODataRouteComponent("odata")]
    public class AppCRUDAbstractKeyWithOdataController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> : AppCRUDAbstractKeyController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>
         where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public AppCRUDAbstractKeyWithOdataController(IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> appCRUDService) : base(appCRUDService)
        {
        }
        [EnableQuery()]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }
    }
}
