using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using repository.contract;

namespace repository
{
    public abstract class GenericRepository<TDbContext, TEntity> : IGenericRepository<TDbContext, TEntity>
            where TDbContext : DbContext
           where TEntity : class
    {
        public DbSet<TEntity> Entities { get; }
        protected TDbContext Context { get; }

        public GenericRepository(TDbContext context)
        {
            this.Context = context;
            Entities = this.Context.Set<TEntity>();
        }
        public virtual async Task<TEntity> Create(TEntity entity)
        {
            entity = (await Entities.AddAsync(entity)).Entity;
            return entity;
        }
        public virtual async Task<int> SaveChange(IDbContextTransaction dbContextTransaction)
        {
            try
            {
                var result = await this.Context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
            finally
            {
                dbContextTransaction.Dispose();
            }
        }
        public virtual async Task<int> SaveChange()
        {
            var transaction = await this.Context.Database.BeginTransactionAsync();
            return await SaveChange(transaction);

        }
        public virtual Task<TEntity> Update(TEntity entity)
        {
            return Task.FromResult(Entities.Update(entity).Entity);
        }
        public Task<IQueryable<TEntity>> GetAll()
        {
            return Task.FromResult(Entities.AsQueryable());
        }

        public async Task AddRange(List<TEntity> entities)
        {
            await Entities.AddRangeAsync(entities);
        }
    }
}
