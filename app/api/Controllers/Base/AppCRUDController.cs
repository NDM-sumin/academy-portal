using Microsoft.AspNetCore.Mvc;
using service.contract.IAppServices.Base;

namespace api.Controllers.Base
{
    public abstract class AppCRUDController<TEntityDto, TEntity> : AppController
        where TEntityDto : class
        where TEntity : class
    {
        protected readonly IAppCRUDService<TEntityDto, TEntity> appCRUDService;

        public AppCRUDController(IAppCRUDService<TEntityDto, TEntity> appCRUDService)
        {
            this.appCRUDService = appCRUDService;
        }

        [HttpGet]
        public virtual IActionResult GetQueryable()
        {
            return Ok(appCRUDService.GetQueryable());
        }

        [HttpPost]
        public virtual async Task<TEntityDto> Create(TEntityDto entityDto)
        {
            return await appCRUDService.Create(entityDto);
        }
        [HttpPut]
        public virtual async Task<TEntityDto> Update(TEntityDto entityDto)
        {
            return await appCRUDService.Update(entityDto);
        }

    }
}
