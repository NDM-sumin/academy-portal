using Microsoft.EntityFrameworkCore;

namespace repository.contract
{
    public interface IGenericRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        DbSet<TEntity> Entities { get; }
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> Create(TEntity entityDto);
        Task<TEntity> Update(TEntity entityDto);
    }
}
