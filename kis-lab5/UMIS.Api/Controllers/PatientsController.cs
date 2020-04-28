using System;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMIS.BLL.Contracts.Models.Common;
using System.Collections.Generic;
using System.Net;
using Common.Enums;
using UMIS.Api.Controllers.Base;
using System.Globalization;
using Common;
using UMIS.BLL.Contracts.ServicesAbstraction.Common;
using System.Threading.Tasks;
using Common.Resources.Messages;
using Common.Attributes;
using UMIS.BLL.Contracts.Models.Views.Common;
using Common.Models.Filters;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с пациентами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : BaseApiController
    {
        private readonly IPatientManager _patientManager;

        /// <summary>
        /// Конструктор
        /// </summary>
        public PatientsController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        /// <summary>
        /// Получить список пациентов
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок пациентов</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<PaginationResult<PatientForViewDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<JsonResult<PaginationResult<PatientForViewDto>>> GetPatientsByFilterAsync([FromQuery]BaseFilter filter)
        {
            JsonResult<PaginationResult<PatientForViewDto>> result =
                await ExecuteActionWithResultAsync(async () => await _patientManager.GetPatientsByFilterAsync(filter)) 
                    as JsonResult<PaginationResult<PatientForViewDto>>;

            return result;
        }


        /// <summary>
        /// Получить пациента по индетификатору
        /// </summary>
        /// <returns>Транспортная модель пациента</returns>
        /// <param name="id">Идентификатор пациента</param>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<PatientForViewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<JsonResult<PatientForViewDto>> GetPatientByIdAsync([FromRoute]int id)
        {
            JsonResult<PatientForViewDto> result = await ExecuteActionWithResultAsync(async () =>
                await _patientManager.GetPatientByIdAsync(id)) as JsonResult<PatientForViewDto>;

            return result;
        }


        /// <summary>
        /// Пометить пациента удаленным
        /// </summary>
        /// <param name="id">Идентификатор пациента</param>
        /// <response code="200">Успешное удаление пациента</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Пациент с заданным идентификатором не найден</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Delete([FromRoute]int id)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Редактировать данные пациента
        /// </summary>
        /// <param name="id">Идентификатор пациента</param>
        /// <param name="patient">Пациент</param>
        /// <response code="200">Успешное редактирование данных пациента</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Пациента с заданным идентификатором не найден</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("")]
        [Produces("application/json")] 
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditPatientAsync([FromBody]PatientDto patient)
        {
            await ExecuteActionAsync(async () => await _patientManager.EditPatientAsync(patient));

            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать нового пациента
        /// </summary>
        /// <param name="patient">Пациент</param>
        /// <returns>Идентификатор созданного пациента</returns>
        /// <response code="201">Успешное создание пациента</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterPatientAsync([FromBody]PatientDto patient)
        {
            JsonResult<int> result = await ExecuteActionWithResultAsync(async () =>
                await _patientManager.RegisterPatientAsync(patient)) as JsonResult<int>;
            result.Message = string.Format(Messages.Information_CreateSuccess_Template, Messages.Entity_Patient);
            result.StatusCode = HttpStatusCode.Created;

            return result;
        }

    }
}
