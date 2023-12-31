using AutoMapper;
using Microsoft.EntityFrameworkCore;
using repository.contract;
using service.contract;

namespace service
{
    public class CRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity, TKey> : CRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity>, ICRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity, TKey>
        where TEntity : class
        where TEntityDto : class
        where TDbContext : DbContext
        where TCreateEntityDto : class
        where TUpdateEntityDto : class

    {
        public CRUDAbstractKeyService(IGenericAbstractKeyRepository<TDbContext, TEntity, TKey> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public virtual async Task<TEntityDto> Delete(TKey keys)
        {

            var deletedEntity = await (Repository as IGenericAbstractKeyRepository<TDbContext, TEntity, TKey>).Delete(keys);
            return Mapper.Map<TEntityDto>(deletedEntity);
        }

        public virtual async Task<TEntityDto> Get(TKey key, bool includeChild = true)
        {
            var data = await (Repository as IGenericAbstractKeyRepository<TDbContext, TEntity, TKey>).Find(key, includeChild);
            return Mapper.Map<TEntityDto>(data);
        }

    }
}
