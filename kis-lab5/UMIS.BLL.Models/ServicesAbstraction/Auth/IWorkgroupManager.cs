using System.Collections.Generic;
using System.Threading.Tasks;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.Contracts.ServicesAbstraction
{
    public interface IWorkgroupManager : IBaseManager
    {
        /// <summary>
        /// Получить список рабочих групп
        /// </summary>
        /// <returns>Список рабочих групп</returns>
        Task<List<WorkgroupDto>> GetWorkGroupsWithRolesAsync();

        /// <summary>
        /// Создать рабочую группу, с пустой(null) ролью
        /// </summary>
        /// <param name="workgroupDto">Транспортная модель рабочей группы</param>
        /// <returns>Идентификатор новой роли в рабочей группы</returns>
        Task<int> CreateWorkgroupAsync(WorkgroupDto workgroupDto);

        /// <summary>
        /// Получить список доступных рабочих групп для прользователя
        /// </summary>
        /// <returns>Список доступных рабочих групп</returns>
        Task<List<WorkgroupDto>> GetWorkgroupsForUserEditAsync();
    }
}
