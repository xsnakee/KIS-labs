using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using UMIS.DAL.DomainAuth;

namespace UMIS.DAL.Repositories.Auth
{
    /// <summary>
    /// Репозиторйи для работы с ролями рабочих групп
    /// </summary>
    public class RoleToWorkgroupRepository : AuthRepositoryBase<RoleToWorkgroup>, IRoleToWorkgroupRepository
    {
        public RoleToWorkgroupRepository(AuthDbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public async Task<RoleToWorkgroup> GetByIdWithPermissionsAsync(int id)
        {
            return await GetAll()
                .Include(x => x.Permissions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
