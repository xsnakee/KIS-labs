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
    /// Контроллер для работы с рабочими группами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WorkGroupsController : BaseApiController
    {
        private readonly IWorkgroupManager _workgroupManager;

        /// <summary>
        /// ctor
        /// </summary>
        public WorkGroupsController(
            IWorkgroupManager workgroupManager)
        {
            _workgroupManager = workgroupManager;
        }


        /// <summary>
        /// Создать рабочую группу
        /// </summary>
        /// Необходимые пермиссии:
        /// 18 - Создание рабочих групп
        /// <param name="workgroupDto">Транспортная модель роли</param>
        /// <returns>Идентификатор новой роли</returns>
        [HttpPost]
        [Route("")]
        [Permissions(18)]
        public async Task<IActionResult> CreateWorkgroup(WorkgroupDto workgroupDto)
        {
            if (workgroupDto == null)
            {
                throw new ArgumentNullException(Messages.Exception_IncorrectData);
            }

            JsonResult<int> result = await ExecuteActionWithResultAsync(async () =>
                await _workgroupManager.CreateWorkgroupAsync(workgroupDto)) as JsonResult<int>;
            result.Message = string.Format(Messages.Information_CreateSuccess_Template, Messages.Entity_Workgroup);

            return result;
        }

        /// <summary>
        /// Метод для получения списка доступных рабочих групп для текущего пользователя
        /// </summary>
        /// Необходимые пермиссии:
        /// 17 - Просмотр все данных рабочих групп
        /// <returns>Список доступных рабочих групп</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        [Permissions(17)]
        public Task<IActionResult> GetAllWorkgroupsForEditAsync()
        {
            return ExecuteActionWithResultAsync(async () =>
            {
                return await _workgroupManager
                    .GetWorkgroupsForUserEditAsync();
            });
        }

    }
}
