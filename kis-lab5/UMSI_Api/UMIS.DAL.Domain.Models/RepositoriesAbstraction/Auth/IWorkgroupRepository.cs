using System.Collections.Generic;
using System.Threading.Tasks;
using UMIS.DAL.Contracts.RepositoriesAbstraction.Base;
using UMIS.DAL.Domain.Contracts.Models.Auth;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;

namespace UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth
{
    /// <summary>
    /// Репозиторий для работы с рабочими группами
    /// </summary>
    public interface IWorkgroupRepository : IRepositoryBase<Workgroup, int>
    {
        /// <summary>
        /// Получить список рабочих групп доступных пользователю
        /// </summary>
        /// <returns>Список рабочих групп</returns>
        Task<List<Workgroup>> GetWorkGroupsWithRolesAsync(int ownerId);

        /// <summary>
        /// Добавить роль в рабочую группу
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="workgroupId">Идентификатор рабочей группы</param>
        /// <returns>Идентификатор роли в рабочей группе</returns>
        Task<RoleToWorkgroup> AddRoleToWorkgroup(int? roleId, int? workgroupId);

        /// <summary>
        /// Проверить существование рабочей группы
        /// </summary>
        /// <param name="workgroup">Рабочая группа</param>
        /// <returns>Результат сущестования</returns>
        Task<bool> IsExistAsync(Workgroup workgroup);
    }
}
