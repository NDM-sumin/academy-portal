using AutoMapper;
using entityframework;
using repository.contract;
using service.contract.IAppServices.Base;

namespace service.AppServices.Base
{
    public abstract class AppCRUDAbstractKeyService<TEntityDto, TEntity, TKey> : AppCRUDService<TEntityDto, TEntity>, IAppCRUDAbstractKeyService<TEntityDto, TEntity, TKey>
        where TEntity : class
        where TEntityDto : class
    {
        protected AppCRUDAbstractKeyService(IGenericAbstractKeyRepository<AppDbContext, TEntity, TKey> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public abstract Task<TEntityDto> Delete(TKey keys);

        public abstract Task<TEntityDto> Get(TKey key, bool includeChild = true);
    }
}
