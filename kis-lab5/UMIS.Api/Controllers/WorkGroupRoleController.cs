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
    /// Контроллер для работы управления ролями в рабочих группах
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WorkGroupRoleController : BaseApiController
    {
        private readonly IPermissionManager _permissionManager;

        /// <summary>
        /// ctor
        /// </summary>
        public WorkGroupRoleController(
            IPermissionManager permissionManager)
        {
            
            _permissionManager = permissionManager;
        }

        /// <summary>
        /// Метод для пометки роли в рабочей группе удаленной
        /// </summary>
        /// <param name="id">Идентификатор роли в рабочей группе</param>
        /// <returns>Результат успешного удаления</returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        [Permissions(14, 21)]
        public async Task<IActionResult> WorkgroupRoleSoftDeleteAsync(int id)
        {
            JsonResult<bool> result = await ExecuteActionWithResultAsync(async () =>
                await _permissionManager.WorkgroupRoleSoftDeleteAsync(id)) as JsonResult<bool>;
            result.Message = Messages.Information_SaveSuccess;

            return result;
        }

        /// <summary>
        /// Назначить/обновить пермиссии роли в рабочей группе
        /// </summary>
        /// <param name="id">Идентификатор роли в рабочей группе</param>
        /// <param name="permissionsIds">Список идентификаторов пермиссий</param>
        [HttpPut]
        [Route("{id}")]
        [Permissions(26)]
        public async Task<IActionResult> UpdateWorkgroupRolePermissions(int id, [FromBody]List<int> permissionsIds)
        {
            JsonVoidResult result = await ExecuteActionAsync(async () => await _permissionManager
                .UpdateWorkgroupRolePermissionsAsync(id, permissionsIds)) as JsonVoidResult;
            result.Message = Messages.Information_SaveSuccess;

            return result;
        }

        /// <summary>
        /// Получить идентификатор новой/редактируемой роли в рабочей группе
        /// </summary>
        /// Необходимые пермиссии:
        /// 13 - Редактирование ролей
        /// 20 - Редактирование рабочих групп
        /// <param name="workgroupRole"> Идентификатор роли в рабочей группы </param>
        /// <returns>Идентификатор роли в рабочей группе</returns>
        [HttpPost]
        [Route("")]
        [Permissions(13, 20)]
        public async Task<IActionResult> CreateOrGetRoleWorkgroupIdForEdit(RoleToWorkroupDto workgroupRole)
        {
            return await ExecuteActionWithResultAsync(async () => await _permissionManager
                .CreateOrEditRoleWorkgroupPermissionsAsync(workgroupRole));
        }

       

    }
}
