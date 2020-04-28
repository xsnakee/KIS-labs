using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UMIS.DAL.Domain
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CommonDbContext>
    {
        public CommonDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CommonDbContext>();
            builder.UseNpgsql(CommonConfigurator.Configuration.GetConnectionString("CommonDb"));
            return new CommonDbContext(builder.Options);
        }
    }
}
