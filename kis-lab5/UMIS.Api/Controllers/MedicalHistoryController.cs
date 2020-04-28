using System;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Common;
using System.Collections.Generic;
using System.Net;
using Common.Enums;
using System.Threading.Tasks;
using UMIS.BLL.Contracts.ServicesAbstraction.Common;
using Common.Resources.Messages;
using UMIS.BLL.Contracts.Models.Views.Common;
using Common.Models.Filters;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с историями болезней
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int MedicalHistoryId { get; set; } = 0;

        private readonly IMedicalHistoryManager _medicalHistoryManager;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MedicalHistoryController(IMedicalHistoryManager medicalHistoryManager)
        {
            _medicalHistoryManager = medicalHistoryManager;
        }

        /// <summary>
        /// Получить все истории болезни.
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        /// <returns>Cписок всех историй болезни.</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<MedicalHistoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<JsonResult<PaginationResult<MedicalHistoryForViewDto>>> GetMedicalHistoriesByFilteredAsync([FromQuery]BaseFilter filter)
        {
            JsonResult<PaginationResult<MedicalHistoryForViewDto>> result =
               await ExecuteActionWithResultAsync(async () => await _medicalHistoryManager.GetMedicalHistoriesByFilterAsync(filter))
                   as JsonResult<PaginationResult<MedicalHistoryForViewDto>>;

            return result;
        }

        /// <summary>
        /// Получить  историю болезни по индетификатору.
        /// </summary>
        /// <returns>Транспортная модель истории болезни.</returns>
        /// <param name="id">Идентификатор истории болезни.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<MedicalHistoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<JsonResult<MedicalHistoryForViewDto>> GetById([FromRoute]int id)
        {
            JsonResult<MedicalHistoryForViewDto> result = await ExecuteActionWithResultAsync(async () =>
               await _medicalHistoryManager.GetMedicalHistoryByIdAsync(id)) as JsonResult<MedicalHistoryForViewDto>;

            return result;
        }


        /// <summary>
        /// Пометить историю болезни удаленным
        /// </summary>
        /// <param name="id">Идентификатор истории болезни</param>
        /// <response code="200">Успешное удаление истории болезнт</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">История болезни с заданным идентификатором не найден</response>
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
        /// Редактировать историю болезни.
        /// </summary>
        /// <param name="id">Идентификатор истории болезни.</param>
        /// <param name="medicalHistory">История болезни.</param>
        /// <response code="200">Успешное редактирование истории болезни.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">История болезни с заданным идентификатором не найден.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] MedicalHistoryDto medicalHistory)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать новую историю болезни.
        /// </summary>
        /// <param name="medicalHistory">История болезни.</param>
        /// <returns>Идентификатор созданной истории болезни.</returns>
        /// <response code="201">Успешное создание истории болезни.</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMedicalHistoryAsync([FromBody] MedicalHistoryDto medicalHistory)
        {
            JsonResult<int> result = await ExecuteActionWithResultAsync(async () =>
               await _medicalHistoryManager.CreateMedicalHistoryAsync(medicalHistory)) as JsonResult<int>;
            result.Message = string.Format(Messages.Information_CreateSuccess_Template, Messages.Entity_MedicalHistory);
            result.StatusCode = HttpStatusCode.Created;

            return result;
        }

    }
}
