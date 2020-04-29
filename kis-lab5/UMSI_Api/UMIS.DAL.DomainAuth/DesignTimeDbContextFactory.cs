using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UMIS.DAL.DomainAuth
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AuthDbContext>();
            builder.UseNpgsql(CommonConfigurator.Configuration.GetConnectionString("AuthDb"));
            return new AuthDbContext(builder.Options);
        }
    }
}
