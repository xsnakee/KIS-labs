using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using UMIS.DbSeed.Seeders;

namespace UMIS.DAL.DbSeed
{
    public static class DbSeeder
    {
        public static IWebHost SeedSystemIdentity(this IWebHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                UserManager<User> userManager = services.GetRequiredService<UserManager<User>>();
                RoleManager<Role> roleManager = services.GetRequiredService<RoleManager<Role>>();
                IPermissionRepository permissionRepository = services.GetRequiredService<IPermissionRepository>();
                IUserRepository userRepository = services.GetRequiredService<IUserRepository>();

                // TODO: обязательно в таком порядке
                IdentitySeeder identitySeeder = new IdentitySeeder(userManager, roleManager, userRepository);
                identitySeeder.SeedSystemRolesAsync().Wait();
                identitySeeder.SeedSystemUsersAsync().Wait();
                identitySeeder.SeedUserWorkgroupRoles().Wait();
                PermissionSeeder permissionSeeder = new PermissionSeeder(permissionRepository);
                permissionSeeder.SeedSystemPermissionsAsync().Wait();
            }

            return host;
        }

    }
}
