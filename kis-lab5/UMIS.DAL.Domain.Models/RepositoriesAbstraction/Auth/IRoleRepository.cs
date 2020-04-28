using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.DAL.Contracts.RepositoriesAbstraction.Base;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;

namespace UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth
{
    /// <summary>
    /// Репозиторий для работы с ролями
    /// </summary>
    public interface IRoleRepository : IRepositoryBase<Role, int>
    {
        /// <summary>
        /// Получить постраничный список ролей с пермиссиями для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        Task<PaginationResult<Role>> GetRolesWithPermissionsByFilterAsync(BaseFilter filter);

        /// <summary>
        /// Добавить роль в рабочую группу
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="workgroupId">Идентификатор рабочей группы</param>
        /// <returns>Идентификатор роли в рабочей группе</returns>
        Task<RoleToWorkgroup> AddRoleToWorkgroup(int? roleId, int? workgroupId);

        /// <summary>
        /// Получить постраничный список ролей с пермиссиями для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        Task<PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>> GetWorkgroupsRolesWithPermissionsAsync(BaseFilter filter);

        /// <summary>
        /// Проверить существование роли
        /// </summary>
        /// <param name="role">Роль</param>
        /// <returns>Результат сущестования</returns>
        Task<bool> IsExistAsync(Role role);
    }
}
