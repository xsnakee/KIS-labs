using System;
using System.Threading.Tasks;
using Common.Attributes;
using Common.Models.Filters;
using Common.Models.Results;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        /// <summary>
        /// Менеджер по работе с учетными данными пользователей.
        /// </summary>
        protected readonly IUserManager _userManager;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="userManager"></param>
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Метод для регистрации нового пользователя.
        /// </summary>
        /// <param name="userRegistrationDto">Регистрационная модель.</param>
        /// <returns>Учетные данные пользователя.</returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        [Permissions(4)]
        public async Task<IActionResult> UserPermissionsAuthInfo(UserRegistrationDto userRegistrationDto)
        {
            if (userRegistrationDto == null)
            {
                throw new ArgumentNullException(Messages.Exception_IncorrectData);
            }

            JsonResult<int> result = await ExecuteActionWithResultAsync(async () =>
                await _userManager.RegisterUser(userRegistrationDto)) as JsonResult<int>;
            result.Message = string.Format(Messages.Information_CreateSuccess_Template, Messages.Entity_User);

            return result;
        }

        /// <summary>
        /// Метод для получения списка пользователей.
        /// </summary>
        /// <param name="filter">Модель фильтра.</param>
        /// <returns>Список учетных записей пользователей.</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        [Permissions(3)]
        public async Task<IActionResult> GetUsersList(BaseFilter filter)
        {
            if (filter == null)
            {
                filter = new BaseFilter();
            }

            return await ExecuteActionWithResultAsync(async () =>
                await _userManager.GetUsersAuthDataByFilterAsync(filter));
        }

        /// <summary>
        /// Метод для пометки пользователя удаленным.
        /// </summary>
        /// <param name="id">Идентификатор польователя.</param>
        /// <returns>Результат успешного удаления.</returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        [Permissions(7)]
        public async Task<IActionResult> UserSoftDeleteAsync(int id)
        {
            JsonResult<bool> result = await ExecuteActionWithResultAsync(async () =>
                await _userManager.UserSoftDeleteAsync(id)) as JsonResult<bool>;
            result.Message = Messages.Information_SaveSuccess;

            return result;  
        }
    }
}
