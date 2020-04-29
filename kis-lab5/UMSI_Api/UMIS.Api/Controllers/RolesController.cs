using System;
using Common.Attributes;
using Common.Models.Filters;
using Common.Models.Results;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Auth;
using UMIS.BLL.Contracts.ServicesAbstraction;
namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с ролями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseApiController
    {
        private readonly IRoleManager _rolesManager;

        /// <summary>
        /// ctor
        /// </summary>
        public RolesController(
            IRoleManager rolesManager)
        {
            _rolesManager = rolesManager;
        }

        /// <summary>
        /// Метод для получения списка доступных ролей для текущего пользователя
        /// </summary>
        /// <returns>Список доступных ролей</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        [Permissions(10)]
        public Task<IActionResult> GetAllRolesForEditAsync()
        {
            return ExecuteActionWithResultAsync(async () =>
            {
                return await _rolesManager
                    .GetRolesForUserEditAsync();
            });
        }

        /// <summary>
        /// Создать роль
        /// </summary>
        /// Необходимые пермиссии:
        /// 11 - Создание ролей
        /// <param name="roleDto">Транспортная модель роли</param>
        /// <returns>Идентификатор новой роли</returns>
        [HttpPost]
        [Route("")]
        [Permissions(11)]
        public async Task<IActionResult> CreateRoleAsync(RoleDto roleDto)
        {
            if (roleDto == null)
            {
                throw new ArgumentNullException(Messages.Exception_IncorrectData);
            }

            JsonResult<int> result = await ExecuteActionWithResultAsync(async () =>
                await _rolesManager.CreateRoleAsync(roleDto)) as JsonResult<int>;
            result.Message = string.Format(Messages.Information_CreateSuccess_Template, Messages.Entity_Role);

            return result;
        }

        /// <summary>
        /// Метод для получения списка ролей рабочих групп с пермиссиями
        /// </summary>
        /// Необходимые пермиссии:
        /// 10 - Просмотр полной инф. о ролях
        /// 17 - Просмотр полной инф. рабочих групп
        /// 23 - Просмотр пермиссий
        /// <param name="filter">Модель фильтра</param>
        /// <returns>Список учетных записей пользователей</returns>
        [HttpPost]
        [Route("filtered")]
        [Authorize]
        [Permissions(10, 17, 23)]
        public async Task<IActionResult> GetRolesList([FromBody]BaseFilter filter)
        {
            if (filter == null)
            {
                filter = new BaseFilter();
            }

            return await ExecuteActionWithResultAsync(async () =>
                await _rolesManager.GetWorkgroupsRolesWithPermissionsAsync(filter));
        }

    }
}
