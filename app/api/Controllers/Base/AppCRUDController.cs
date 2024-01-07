using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using service.contract.DTOs;
using service.contract.IAppServices.Base;
using System.Linq;

namespace api.Controllers.Base
{
    public abstract class AppCRUDController<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity>
        : AppController
        where TEntityDto : class
        where TEntity : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        protected readonly IAppCRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> appCRUDService;

        public AppCRUDController(IAppCRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> appCRUDService)
        {
            this.appCRUDService = appCRUDService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get(int skip, int? top)
        {
            IMapper mapper = this.Request.HttpContext.RequestServices.GetService<IMapper>()!;
            var queryable = await appCRUDService.GetQueryable();
            var data = queryable.Skip(skip);
            if (top.HasValue)
            {
                data = data.Take(top.Value);
            }
            PageResponse<TEntityDto> response = new PageResponse<TEntityDto>()
            {
                TotalItems = queryable.Count(),
                Items = mapper.Map<IEnumerable<TEntityDto>>(data.AsEnumerable())
            };
            return Ok(response);
        }

        [HttpPost]
        public virtual async Task<TEntityDto> Create(TCreateEntityDto entityDto)
        {
            return await appCRUDService.Create(entityDto);
        }
        [HttpPut]
        public virtual async Task<TEntityDto> Update(TUpdateEntityDto entityDto)
        {
            return await appCRUDService.Update(entityDto);
        }

    }
}
