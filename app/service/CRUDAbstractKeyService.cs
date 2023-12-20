using AutoMapper;
using Microsoft.EntityFrameworkCore;
using repository.contract;
using service.contract;

namespace service
{
    public class CRUDAbstractKeyService<TEntityDto, TDbContext, TEntity, TKey> : CRUDService<TEntityDto, TDbContext, TEntity>, ICRUDAbstractKeyService<TEntityDto, TDbContext, TEntity, TKey>
        where TEntity : class
        where TEntityDto : class
        where TDbContext : DbContext

    {
        public CRUDAbstractKeyService(IGenericAbstractKeyRepository<TDbContext, TEntity, TKey> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public async Task<TEntityDto> Delete(TKey keys)
        {

            var deletedEntity = await (Repository as IGenericAbstractKeyRepository<TDbContext, TEntity, TKey>).Delete(keys);
            return Mapper.Map<TEntityDto>(deletedEntity);
        }

        public async Task<TEntityDto> Get(TKey key, bool includeChild = true)
        {
            var data = await (Repository as IGenericAbstractKeyRepository<TDbContext, TEntity, TKey>).Find(key, includeChild);
            return Mapper.Map<TEntityDto>(data);
        }

    }
}
