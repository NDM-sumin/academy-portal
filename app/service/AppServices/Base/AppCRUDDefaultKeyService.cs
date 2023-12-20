using AutoMapper;
using entityframework;
using repository.contract.IAppRepositories.Base;
using service.contract.IAppServices.Base;

namespace service.AppServices.Base
{
    public class AppCRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity> : CRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, AppDbContext, TEntity>, IAppCRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity>
        where TEntityDto : class
        where TEntity : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public AppCRUDDefaultKeyService(IAppGenericDefaultKeyRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
