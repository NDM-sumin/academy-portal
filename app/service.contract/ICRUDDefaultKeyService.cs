using Microsoft.EntityFrameworkCore;

namespace service.contract
{
    public interface ICRUDDefaultKeyService<TEntityDto, TDbContext, TEntity> : ICRUDAbstractKeyService<TEntityDto, TDbContext, TEntity, Guid>
        where TEntityDto : class
        where TEntity : class
        where TDbContext : DbContext
    {
    }
}
