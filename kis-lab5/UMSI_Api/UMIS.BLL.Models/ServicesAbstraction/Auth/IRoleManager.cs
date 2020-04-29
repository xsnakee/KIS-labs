using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.Contracts.ServicesAbstraction
{
    /// <summary>
    /// Менеджер по работе с ролями
    /// </summary>
    public interface IRoleManager : IBaseManager
    {
        /// <summary>
        /// Получить список доступных ролей
        /// </summary>
        /// <returns>Список доступных ролей</returns>
        Task<List<RoleDto>> GetRolesForUserEditAsync();

        /// <summary>
        /// Получить постраничный список ролей с пермиссиями для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        Task<PaginationResult<RoleDto>> GetRolesByFilterAsync(BaseFilter filter);

        /// <summary>
        /// Получить роли рабочих групп с пермиссиями
        /// </summary>
        /// <param name="filter">Модель базового фильтра</param>
        /// <returns>Постраничный список ролей рабочих групп с пермиссиями</returns>
        Task<PaginationResult<WorkgroupRolePermissionDto>> GetWorkgroupsRolesWithPermissionsAsync(BaseFilter filter);

        /// <summary>
        /// Создать роль
        /// </summary>
        /// <param name="roleDto">Транспортная модель роли</param>
        /// <returns>Идентификатор новой роли</returns>
        Task<int> CreateRoleAsync(RoleDto roleDto);
    }
}
