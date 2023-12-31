using AutoMapper;
using entityframework;
using repository.contract;
using service.contract.IAppServices.Base;

namespace service.AppServices.Base
{
    public class AppCRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> : CRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, AppDbContext, TEntity>, IAppCRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity>
        where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public AppCRUDService(IGenericRepository<AppDbContext, TEntity> genericRepository, IMapper mapper)
            : base(genericRepository, mapper)
        {
        }
    }
}
