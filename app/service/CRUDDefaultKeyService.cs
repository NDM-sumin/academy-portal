using AutoMapper;
using Microsoft.EntityFrameworkCore;
using repository.contract;
using service.contract;

namespace service
{
    public class CRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity> : CRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity, Guid>, ICRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity>
        where TEntityDto : class
        where TEntity : class
        where TDbContext : DbContext
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
        public CRUDDefaultKeyService(IGenericDefaultKeyRepository<TDbContext, TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
