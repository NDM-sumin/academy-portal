using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace repository.contract
{
    public interface IGenericRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        DbSet<TEntity> Entities { get; }
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<int> SaveChange();
        Task<int> SaveChange(IDbContextTransaction dbContextTransaction);
    }
}
