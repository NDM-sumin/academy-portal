using AutoMapper;
using repository.contract.IAppRepositories.Base;
using service.contract.IAppServices.Base;

namespace service.AppServices.Base
{
    public class AppCRUDDefaultKeyService<TEntityDto, TEntity> : AppCRUDAbstractKeyService<TEntityDto, TEntity, Guid>, IAppCRUDDefaultKeyService<TEntityDto, TEntity>
        where TEntityDto : class
        where TEntity : class
    {
        public AppCRUDDefaultKeyService(IAppGenericDefaultKeyRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public override async Task<TEntityDto> Delete(Guid keys)
        {

            var data = await (Repository as IAppGenericDefaultKeyRepository<TEntity>).Delete(keys);
            return Mapper.Map<TEntityDto>(data);
        }

        public override async Task<TEntityDto> Get(Guid key, bool includeChild = true)
        {
            var data = await (Repository as IAppGenericDefaultKeyRepository<TEntity>).Find(key, includeChild);
            return Mapper.Map<TEntityDto>(data);
        }
    }
}
