using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.DbSeed.Helpers;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для проверки реализованного функционала
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TestsController : BaseApiController
    {
        /// <summary>
        /// ctor
        /// </summary>
        public TestsController()
        {
        }

        /// <summary>
        /// Метод проверки пост запроса
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IActionResult CheckGetRequest()
        {
            return ExecuteActionWithResult(() => "It's Alive!");
        }

        /// <summary>
        /// Метод проверки пост запроса
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ConfigurationTransformations")]
        public IActionResult CheckConfigurationTransformations()
        {
            return ExecuteActionWithResult(() => Common.CommonConfigurator.GetAppSettingsValue("StandName", "None"));
        }


        /// <summary>
        /// Метод проверки успешной авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Authorize")]
        [Authorize]
        public IActionResult CheckAuthorizedAccess()
        {
            return ExecuteActionWithResult(() =>
            {
                return "Access Denied";
            });
        }

        /// <summary>
        /// Проверка динамической привязки пермиссий
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Permissions")]
        public IActionResult GetPermissions()
        {
            return ExecuteActionWithResult(() =>
            {
                return PermissionGenerator.Permissions;
            });
        }
    }
}