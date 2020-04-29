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
    /// Контроллер для работы с пермиссиями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : BaseApiController
    {
        private readonly IPermissionManager _permissionManager;

        /// <summary>
        /// сtor
        /// </summary>
        /// <param name="premissionManager"></param>
        public PermissionsController(
            IPermissionManager premissionManager)
        {
            _permissionManager = premissionManager;
        }

        /// <summary>
        /// Получить список пермиссий доступных текущему пользователю для назначения
        /// </summary>
        /// Необходимые пермиссии:
        /// 23 - Просмотр пермиссий
        /// <returns>Спиок пермиссий</returns>
        [HttpGet]
        [Route("")]
        [Permissions(23)]
        public async Task<IActionResult> GetPermissionsForCurrentUser()
        {
            return await ExecuteActionWithResultAsync(async () => await _permissionManager
                .GetPermissionsForUserEditAsync());
        }

        /// <summary>
        /// Получить список пермиссий по идентификатору роли в рабочей группы
        /// </summary>
        /// Необходимые пермиссии:
        /// 26 - Назначение пермиссий ролям и рабочим группам
        /// <param name="workgroupRoleId">Идентификатор роли в рабочей группы</param>
        /// <returns>Спиок пермиссий</returns>
        [HttpGet]
        [Route("{workgroupRoleId}")]
        [Permissions(26)]
        public async Task<IActionResult> GetPermissionsByWorkgroupRoleId(int workgroupRoleId)
        {
            return await ExecuteActionWithResultAsync(async () => await _permissionManager
                .GetPermissionsByWorkgroupRoleIdAsync(workgroupRoleId));
        }
    }
}
