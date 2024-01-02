using AutoMapper;
using entityframework;
using repository.contract;
using service.contract.IAppServices.Base;

namespace service.AppServices.Base
{
    public abstract class AppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey> : CRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, AppDbContext, TEntity, TKey>, IAppCRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntity, TKey>
        where TEntity : class
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        protected AppCRUDAbstractKeyService(IGenericAbstractKeyRepository<AppDbContext, TEntity, TKey> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

    }
}
