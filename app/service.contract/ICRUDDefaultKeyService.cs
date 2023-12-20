using Microsoft.EntityFrameworkCore;

namespace service.contract
{
    public interface ICRUDDefaultKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity> : ICRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity, Guid>
        where TEntityDto : class
        where TEntity : class
        where TDbContext : DbContext
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {
    }
}
