using AutoMapper;
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
        public async Task<IActionResult> Get(ODataQueryOptions<TEntity> odataOptions)
        {
            var mapper = this.HttpContext.RequestServices.GetService<IMapper>()!;
            var data = odataOptions.ApplyTo(await appCRUDService.GetQueryable()) as IQueryable<TEntity>;
            var odataFeature = HttpContext.ODataFeature();

            var response = new PageResponse<TEntityDto>()
            {
                TotalItems = odataFeature.TotalCount ?? 0,
                Items = mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityDto>>(data?.AsEnumerable() ?? Enumerable.Empty<TEntity>()),
            };
            return Ok(response);

        }
    }
}
