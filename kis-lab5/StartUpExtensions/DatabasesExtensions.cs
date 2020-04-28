using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UMIS.DAL.Domain;
using UMIS.DAL.DomainAuth;

namespace StartUpExtensions
{
    public static class DatabasesExtensions
    {
        public static IServiceCollection ResolveDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommonDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("CommonDb"));
            });

            ///Identity database
            services.AddDbContext<AuthDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("AuthDb"));
            });

            return services;
        }
    }
}
