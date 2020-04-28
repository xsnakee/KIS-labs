using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.Contracts.ServicesAbstraction
{
    /// <summary>
    /// Менеджер по работе с пермиссиями
    /// </summary>
    public interface IPermissionManager : IBaseManager
    {
        /// <summary>
        /// Получить пермиссии доступные пользователю
        /// </summary>
        /// <returns>Список пермиссий</returns>
        Task<List<PermissionDto>> GetPermissionsForUserEditAsync();

        /// <summary>
        /// Получить роли рабочих групп с пермиссиями
        /// </summary>
        /// <param name="filter">Модель базового фильтра</param>
        /// <returns>Постраничный список ролей рабочих групп с пермиссиями</returns>
        Task<PaginationResult<WorkgroupRolePermissionDto>> GetPermissionsWithWorkgroupRolesAsync(BaseFilter filter);

        /// <summary>
        /// Создает/редактирует роль в рабочей группе и/или возвращает её идентификатор
        /// </summary>
        /// <param name="workgroupId">Идентификатор рабочей группы</param>
        /// <param name="roleId">Идентификатор роли</param>
        /// <returns>Идентификатор роли в рабочей группе</returns>
        Task<int> CreateOrEditRoleWorkgroupPermissionsAsync(RoleToWorkroupDto workgroupRole);

        /// <summary>
        /// Получить список пермиссий по идентификатора роли в рабочей группе
        /// </summary>
        /// <param name="workgroupRoleId">Идентификатор роли в рабочей группе</param>
        /// <returns>Список пермиссий</returns>
        Task<List<PermissionDto>> GetPermissionsByWorkgroupRoleIdAsync(int workgroupRoleId);

        /// <summary>
        /// Назначить/обновить пермиссии роли в рабочей группе
        /// </summary>
        /// <param name="workgroupRoleId">Идентификатор роли в рабочей группе</param>
        /// <param name="permissionsIds">Список идентификаторов пермиссий</param>
        Task UpdateWorkgroupRolePermissionsAsync(int workgroupRoleId, List<int> permissionsIds);

        /// <summary>
        /// Метод для пометки роли в рабочей группе удаленной
        /// </summary>
        /// <param name="id">Идентификатор роли в рабочей группе</param>
        /// <returns>Результат успешного удаления</returns>
        Task<bool> WorkgroupRoleSoftDeleteAsync(int id);
    }
}
