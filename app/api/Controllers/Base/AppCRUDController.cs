using Microsoft.AspNetCore.Mvc;
using service.contract.IAppServices.Base;

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
        public virtual IActionResult GetAll()
        {
            return Ok(appCRUDService.GetQueryable());
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
