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
    /// Репозиторий по работе с разрешениями пользователей
    /// </summary>
    public interface IPermissionRepository : IRepositoryBase<Permission, int>
    {
        /// <summary>
        /// Получить доступные пермиссии для роли в рабочей группе
        /// </summary>
        /// <param name="roleToWorkgroupId">Идентификатор роли в рабочей группе</param>
        /// <returns>Список пермиссий</returns>
        Task<List<Permission>> GetPermissionsByWorkgroupRoleAsync(int roleToWorkgroupId);

        /// <summary>
        /// Получить доступные пермиссии для роли в рабочей группе
        /// </summary>
        /// <param name="workgroupRolesIds">Идентификаторы ролей в рабочих группах пользователя</param>
        /// <returns>Список пермиссий</returns>
        Task<List<Permission>> GetPermissionsByWorkgroupsRolesAsync(List<int> workgroupRolesIds);

        /// <summary>
        /// Получить доступные пермиссии для пользователя по идентификатору
        /// </summary>
        /// <param name="currentUserId">Идентификатор пользователя</param>
        /// <returns>Список пермиссий</returns>
        Task<List<Permission>> GetPermissionsByUserIdAsync(int currentUserId);

        /// <summary>
        /// Проучить список пермиссий по типам сущностей и действий
        /// </summary>
        /// <param name="permissions"> Список кортежей типов сущнойстей и действий</param>
        /// <returns> Список пермиссий </returns>
        Task<List<Permission>> GetPermissionsByEntityActionTypesAsync(List<KeyValuePair<int?, int?>> permissions);

        /// <summary>
        /// Получить пермиссии для создания/редактирования ролей/рабочих групп
        /// </summary>
        /// <param name="ownerId">Идентификатор пользователя</param>
        /// <returns>Список пермиссий</returns>
        Task<List<Permission>> GetPermissionsForUserEditAsync(int ownerId);

        /// <summary>
        /// Получить постраничный список ролей с пермиссиями для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        Task<PaginationDictionaryResult<RoleToWorkgroup, List<Permission>>> GetPermissionsWithWorkgroupRolesAsync(BaseFilter filter);

        /// <summary>
        /// Получить роль в рабочей группе по идентификаторам роли и рабочей группы
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="workgroupId">Идентификатор рабочей группы</param>
        /// <returns>Роль в рабочей группе</returns>
        Task<RoleToWorkgroup> GetByRoleAndWorkgroupIds(int? roleId, int? workgroupId);

        /// <summary>
        /// Добавить пермиссии к роли в рабочей группе
        /// </summary>
        /// <param name="workgroupRoleId">Идентификатор роли в рабочей группе</param>
        /// <param name="permissionIds">Список пермиссий</param>
        /// <returns>Количество затронутых строк в бд</returns>
        Task<int> AddAndSavePermissionsToWorkgroupRoleAsync(int workgroupRoleId, params int[] permissionIds);
    }
}
