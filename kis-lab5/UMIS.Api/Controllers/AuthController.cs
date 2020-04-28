using System;
using System.Threading.Tasks;
using Common.Models.Results;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenAuthentication;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для аутентификации и авторизации на основе JWT
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthManager _authManager;

        /// <summary>
        /// Ctor
        /// </summary>
        public AuthController(IAuthManager authManager,
            ITokenService tokenService)
        {
            _authManager = authManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Выполнить вход в систему
        /// </summary>
        /// <param name="loginDto">Модель логина пользователя</param>
        /// <response code="200">Токен для авторизации</response>
        /// <response code="401">Ошибка логина/пароля</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>JWT - токен</returns>
        [HttpPost("Login")]
        [ProducesResponseType(typeof(JsonResult<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAction(UserLoginDto loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(loginDto));
            }

            JsonResult<string> result = await ExecuteActionWithResultAsync(async () =>
                await _authManager.LoginAsync(loginDto)) as JsonResult<string>;
            result.Message = Messages.Information_LoginSuccess;

            return result;
        }

        /// <summary>
        /// Метод получения данных пользователя
        /// </summary>
        /// <returns>Учетные данные пользователя</returns>
        /// <response code="200">Данные пользователя</response>
        /// <response code="401">Пользователь не авторизован</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet]
        [Route("UserInfo")]
        [ProducesResponseType(typeof(JsonResult<UserAuthInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> UserAuthInfo()
        {
            return await ExecuteActionWithResultAsync(async () =>
                await _authManager.GetCurrentUseInfoAsync());
        }
    }
}