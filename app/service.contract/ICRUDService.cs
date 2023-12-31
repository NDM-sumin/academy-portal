
using Microsoft.EntityFrameworkCore;

namespace service.contract
{
    public interface ICRUDService<TEntityDto, TCreateEntityDto, TUpdateEntityDto, TDbContext, TEntity>
        where TEntityDto : class
        where TEntity : class
        where TDbContext: DbContext
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
    {

        Task<TEntityDto> Create(TCreateEntityDto entityDto);
        Task<TEntityDto> Update(TUpdateEntityDto entityDto);
     
        Task<IQueryable<TEntity>> GetQueryable();
        Task<IEnumerable<TEntityDto>> GetAll(); 
    }
}
