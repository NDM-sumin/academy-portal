using entityframework;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddAppDbContext<T>(this IServiceCollection services, string connectionString)
        where T : DbContext
        {
            return services.AddDbContext<T>((option) =>
            {
                option.UseSqlServer(connectionString);
            });
        }
        public static IServiceCollection AddAppDefaultDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddAppDbContext<AppDbContext>(configuration.GetConnectionString("Default"));
        }
    }
}
