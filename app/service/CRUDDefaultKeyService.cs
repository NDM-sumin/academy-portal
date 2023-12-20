using AutoMapper;
using Microsoft.EntityFrameworkCore;
using repository.contract;
using service.contract;

namespace service
{
    public class CRUDDefaultKeyService<TEntityDto, TDbContext, TEntity> : CRUDAbstractKeyService<TEntityDto, TDbContext, TEntity, Guid>, ICRUDDefaultKeyService<TEntityDto, TDbContext, TEntity>
        where TEntityDto : class
        where TEntity : class
        where TDbContext : DbContext
    {
        public CRUDDefaultKeyService(IGenericDefaultKeyRepository<TDbContext, TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
