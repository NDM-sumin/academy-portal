using repository;
using repository.AppRepositories;
using repository.AppRepositories.Base;
using repository.contract;
using repository.contract.IAppRepositories;
using repository.contract.IAppRepositories.Base;
using service;
using service.AppServices;
using service.AppServices.Base;
using service.contract;
using service.contract.IAppServices;
using service.contract.IAppServices.Base;

namespace api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {

            return services
                 .AddScoped<IAccountService, AccountService>()
                .AddScoped<IAccountRepository, AccountRepository>()
/*                .AddScoped(typeof(IAppGenericDefaultKeyRepository<>), typeof(AppGenericDefaultKeyRepository<>))
                .AddScoped(typeof(IAppGenericSingleKeyRepository<,>), typeof(AppGenericSingleKeyRepository<,>))
                .AddScoped(typeof(IGenericSingleKeyRepository<,,>), typeof(GenericSingleKeyRepository<,,>))
                .AddScoped(typeof(IAppGenericAbstractKeyRepository<,>), typeof(AppGenericAbstractKeyRepository<,>))
                .AddScoped(typeof(IAppGenericRepository<>), typeof(AppGenericRepository<,>))
                .AddScoped(typeof(IGenericDefaultKeyRepository<,>), typeof(IGenericSingleKeyRepository<,,>))
                .AddScoped(typeof(IGenericAbstractKeyRepository<,,>), typeof(GenericAbstractKeyRepository<,,>))
                .AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>))
                .AddScoped(typeof(IAppCRUDDefaultKeyService<,,,>), typeof(AppCRUDDefaultKeyService<,,,>))
                .AddScoped(typeof(IAppCRUDAbstractKeyService<,,,,>), typeof(AppCRUDAbstractKeyService<,,,,>))
                .AddScoped(typeof(IAppCRUDService<,,,>), typeof(AppCRUDService<,,,>))
                .AddScoped(typeof(ICRUDDefaultKeyService<,,,,>), typeof(CRUDDefaultKeyService<,,,,>))
                .AddScoped(typeof(ICRUDAbstractKeyService<,,,,,>), typeof(CRUDAbstractKeyService<,,,,,>))
                .AddScoped(typeof(ICRUDService<,,,,>), typeof(CRUDService<,,,,>))*/

               ;
        }

    }
}
