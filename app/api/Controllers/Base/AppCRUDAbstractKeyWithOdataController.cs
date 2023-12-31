using AutoMapper;
using AutoMapper.AspNet.OData;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using service.contract.DTOs;
using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{

    public abstract class AppCRUDAbstractKeyWithOdataController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> : AppCRUDAbstractKeyController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>
         where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public AppCRUDAbstractKeyWithOdataController(IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> appCRUDService) : base(appCRUDService)
        {
        }
        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> Get()
        {
            return Ok(await appCRUDService.GetQueryable());
        }

        [HttpGet]
        public async Task<IActionResult> Get(ODataQueryOptions<TEntityDto> odataOptions)
        {
            var mapper = this.HttpContext.RequestServices.GetService<IMapper>()!;
            var odataFeature = HttpContext.ODataFeature();
            var data = await (await appCRUDService.GetQueryable()).GetQueryAsync<TEntityDto, TEntity>(mapper, odataOptions);
            var response = new PageResponse<TEntityDto>()
            {
                TotalItems =data.Count(),
                Items = data,
            };
            return Ok(response);

        }
    }
}
