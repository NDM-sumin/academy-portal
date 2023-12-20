
using Microsoft.EntityFrameworkCore;

namespace service.contract
{
    public interface ICRUDService<TEntityDto, TDbContext, TEntity>
        where TEntityDto : class
        where TEntity : class
        where TDbContext: DbContext
    {

        Task<TEntityDto> Create(TEntityDto entityDto);
        Task<TEntityDto> Update(TEntityDto entityDto);
     
        Task<IQueryable<TEntity>> GetQueryable();
        Task<IEnumerable<TEntityDto>> GetAll(); 
    }
}
