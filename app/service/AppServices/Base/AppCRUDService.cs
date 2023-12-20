using AutoMapper;
using entityframework;
using repository.contract;
using service.contract.IAppServices.Base;

namespace service.AppServices.Base
{
    public class AppCRUDService<TEntityDto, TEntity> : CRUDService<TEntityDto, AppDbContext, TEntity>, IAppCRUDService<TEntityDto, TEntity>
        where TEntity : class
        where TEntityDto : class
    {
        public AppCRUDService(IGenericRepository<AppDbContext, TEntity> genericRepository, IMapper mapper)
            : base(genericRepository, mapper)
        {
        }
    }
}
