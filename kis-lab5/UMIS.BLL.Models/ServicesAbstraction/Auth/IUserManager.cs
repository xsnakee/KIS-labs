using System.Threading.Tasks;
using Common.Models.Filters;
using Common.Models.Results;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.Contracts.ServicesAbstraction
{
    public interface IUserManager : IBaseManager
    {
        /// <summary>
        /// Зарегистрировать нового пользователя
        /// </summary>
        /// <param name="userDto">Модель пользователя для регистрации</param>
        /// <returns>Идентификатор пользователя</returns>
        Task<int> RegisterUser(UserRegistrationDto userDto);

        /// <summary>
        /// Добавить пользователя к роли в рабочей группе
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleWorkgroupId">Идентификатор роли в рабочей группе</param>
        Task AddUserToRoleWorkgroup(int userId, int roleWorkgroupId);

        /// <summary>
        /// Получить список пользователей для просмотра
        /// </summary>
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Постраничный результат</returns>
        Task<PaginationResult<UserAuthInfoDto>> GetUsersAuthDataByFilterAsync(BaseFilter filter);

        /// <summary>
        /// Метод для пометки пользователя удаленным
        /// </summary>
        /// <param name="id">Идентификатор польователя</param>
        /// <returns>Результат успешного удаления</returns>
        Task<bool> UserSoftDeleteAsync(int id);
    }
}
