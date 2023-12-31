using Microsoft.EntityFrameworkCore;

namespace service.contract
{
    public interface ICRUDAbstractKeyService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity, TKey> : ICRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity>
        where TEntity : class
        where TEntityDto : class
        where TDbContext : DbContext
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {

        Task<TEntityDto> Delete(TKey keys);
        Task<TEntityDto> Get(TKey key, bool includeChild = true);
    }
}
