using System.Threading.Tasks;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction._Base;

namespace UMIS.BLL.Contracts.ServicesAbstraction
{
    /// <summary>
    /// Менеджер по работе с авторизацией
    /// </summary>
    public interface IAuthManager : IBaseManager
    {
        /// <summary>
        /// Валидация пользователя и выдача токена
        /// </summary>
        /// <param name="loginDto">Данные для входа пользователя</param>
        /// <returns>JWT токен</returns>
        Task<string> LoginAsync(UserLoginDto loginDto);

        /// <summary>
        /// Метод получения данных пользователя из контекста запроса
        /// </summary>
        /// <returns></returns>
        Task<UserAuthInfoDto> GetCurrentUseInfoAsync();

        /// <summary>
        /// Проверка пермиссий текщуего пользователя на соответствие
        /// </summary>
        /// <param name="permissionIds">Список пермиссий</param>
        Task<bool> CheckCurrentUserPermissionsAsync(params int[] permissionIds);
    }
}
