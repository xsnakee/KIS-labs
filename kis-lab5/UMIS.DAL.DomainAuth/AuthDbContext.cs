using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.DomainAuth.ModelsConfigurator;

namespace UMIS.DAL.DomainAuth
{
    public class AuthDbContext : IdentityDbContext<User, Role, int>
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected AuthDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleModelConfiguration());
            modelBuilder.ApplyConfiguration(new UserModelConfiguration());
            modelBuilder.ApplyConfiguration(new WorkgroupModelConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionModelConfiguration());
            modelBuilder.ApplyConfiguration(new RoleToWorkgroupModelConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionsToWorkgroupRoleModelConfiguration());
            modelBuilder.ApplyConfiguration(new UserToRoleWorkgroupModelConfiguration());
        }

        public DbSet<Workgroup> Workgroups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionsToWorkgroupRole> PermissionsToWorkgroupRoles { get; set; }
        public DbSet<RoleToWorkgroup> RoleToWorkgroup { get; set; }
        public DbSet<UserToRoleWorkgroup> UserToRoleWorkgroup { get; set; }
    }
}
