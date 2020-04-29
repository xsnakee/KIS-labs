using System.Collections.Generic;
using System.Threading.Tasks;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using UMIS.DbSeed.DataSeed;

namespace UMIS.DbSeed.Seeders
{
    public class PermissionSeeder
    {
        public PermissionSeeder(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        private IPermissionRepository _permissionRepository { get; set; }

        public async Task SeedSystemPermissionsAsync()
        {
            List<Permission> permissionsForSeed = Permissions.PermissionsForSeed;

            foreach (Permission permission in permissionsForSeed)
            {
                await _permissionRepository.AddOrUpdateAsync(permission);
            }

            await _permissionRepository.SaveChangesAsync();
            await _permissionRepository.AddAndSavePermissionsToWorkgroupRoleAsync(1, 1);
        }
    }
}
