using repository.AppRepositories;
using repository.contract.IAppRepositories;
using service.AppServices;
using service.contract.IAppServices;

namespace api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {

            return services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IAccountRepository, AccountRepository>();
        }

    }
}
