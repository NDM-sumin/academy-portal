using Microsoft.EntityFrameworkCore;

namespace service.contract
{
    public interface ICRUDAbstractKeyService<TEntityDto, TDbContext, TEntity, TKey> : ICRUDService<TEntityDto, TDbContext, TEntity>
        where TEntity : class
        where TEntityDto : class
        where TDbContext : DbContext
    {

        Task<TEntityDto> Delete(TKey keys);
        Task<TEntityDto> Get(TKey key, bool includeChild = true);
    }
}
