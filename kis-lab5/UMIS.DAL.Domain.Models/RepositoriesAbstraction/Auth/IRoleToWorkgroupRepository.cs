using System.Threading.Tasks;
using UMIS.DAL.Contracts.RepositoriesAbstraction.Base;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;

namespace UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth
{
    /// <summary>
    /// Репозиторйи для работы с ролями рабочих групп
    /// </summary>
    public interface IRoleToWorkgroupRepository : IRepositoryBase<RoleToWorkgroup, int>
    {
        /// <summary>
        /// Получить доменную роль в рабочей группе с пермиссиями
        /// </summary>
        /// <param name="id">Иднетификато роли в рабочей группе</param>
        /// <returns>Доменная роль в рабочей группе</returns>
        Task<RoleToWorkgroup> GetByIdWithPermissionsAsync(int id);
    }
}
