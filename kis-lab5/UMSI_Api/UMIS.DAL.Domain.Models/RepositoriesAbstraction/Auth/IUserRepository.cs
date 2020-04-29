using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.DAL.Contracts.RepositoriesAbstraction.Base;
using UMIS.DAL.Domain.Contracts.Models.Auth;

namespace UMIS.DAL.Domain.Contracts.RepositoriesAbstraction.Auth
{
    /// <summary>
    /// Репозитория для работы с учетными данными пользователей
    /// </summary>
    public interface IUserRepository : IRepositoryBase<User, int>
    {
        /// <summary>
        /// Получить пользователя по имени со связанными данными
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>Сущность пользователя</returns>
        Task<User> GetUserByNameWithRelatedDataAsync(string userName);

        /// <summary>
        /// Добавить пользователя к роли в рабочей группе
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleWorkgroupId">Идентификатор роли в рабочей группе</param>
        Task AddUserToRoleAndWorkgroupAsync(int userId, int? roleWorkgroupId);

        /// <summary>
        /// Проверить существование роли у пользоавтеля
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleWorkgroupId">Идентификатор роли в рабочей группе</param>
        /// <returns>Отметка о существовании</returns>
        Task<bool> IsExistUserToRoleAndWorkgroupAsync(int userId, int? roleWorkgroupId);

        // <summary>
        /// Получить список пользователей для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        Task<PaginationResult<User>> GetUsersAuthDataByFilterAsync(BaseFilter filter);
    }
}
