using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth;
using UMIS.DAL.DomainAuth;

namespace UMIS.DAL.Repositories.Auth
{
    /// <summary>
    /// Репозиторий для работы с рабочими группами
    /// </summary>
    public class WorkgroupRepository : AuthRepositoryBase<Workgroup>, IWorkgroupRepository
    {
        public WorkgroupRepository(AuthDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить список рабочих групп доступных пользователю
        /// </summary>
        /// <returns>Список рабочих групп</returns>
        public async Task<List<Workgroup>> GetWorkGroupsWithRolesAsync(int ownerId)
        {
            return await GetAllForOwner<Workgroup>(ownerId)
                .Include(x => x.RoleToWorkgroup)
                    .ThenInclude(y => y.Role)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<RoleToWorkgroup> AddRoleToWorkgroup(int? roleId, int? workgroupId)
        {
            RoleToWorkgroup roleWorkgroup = new RoleToWorkgroup
            {
                RoleId = roleId,
                WorkgroupId = workgroupId
            };

            return (await DbContext.AddAsync(roleWorkgroup)).Entity;
        }

        /// <inheritdoc />
        public async Task<bool> IsExistAsync(Workgroup workgroup)
        {
            Workgroup entity = await GetAll()
                .FirstOrDefaultAsync(x => x.Id == workgroup.Id
                    || x.Name == workgroup.Name);

            return entity != null
                ? true
                : false;
        }
    }
}
