using AutoMapper;
using Microsoft.EntityFrameworkCore;
using repository.contract;
using service.contract;

namespace service
{
    public class CRUDService<TEntityDto, TDbContext, TEntity> : ICRUDService<TEntityDto, TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntityDto : class
        where TEntity : class
    {
        public readonly IGenericRepository<TDbContext, TEntity> Repository;
        public readonly IMapper Mapper;
        public CRUDService(IGenericRepository<TDbContext, TEntity> genericRepository, IMapper mapper)
        {
            this.Repository = genericRepository;
            this.Mapper = mapper;
        }

        public async Task<TEntityDto> Create(TEntityDto entityDto)
        {

            var entity = Mapper.Map<TEntity>(entityDto);
            var createdEntity = await Repository.Create(entity);

            return Mapper.Map<TEntityDto>(createdEntity);
        }


        public async Task<IQueryable<TEntity>> GetQueryable()
        {
            return await Repository.GetAll();
        }

        public async Task<TEntityDto> Update(TEntityDto entityDto)
        {

            var entity = Mapper.Map<TEntity>(entityDto);
            var deletedEntity = await Repository.Update(entity);
            return Mapper.Map<TEntityDto>(deletedEntity);
        }

        public async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var data = await Repository.GetAll();
            return Mapper.Map<IEnumerable<TEntityDto>>(data.AsEnumerable());
        }
    }
}
