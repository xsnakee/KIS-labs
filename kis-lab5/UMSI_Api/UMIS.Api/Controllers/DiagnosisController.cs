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
using UMIS.BLL.Contracts.Models.Common;
using System.Collections.Generic;
using System.Net;
using Common.Enums;
using UMIS.BLL.Contracts.Models.Common.Catalogs;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы c диагнозом
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int DiagnosisId { get; set; } = 0;

        /// <summary>
        /// Получить список всех диагназов.
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        /// <returns>Cписок всех диагнозов.</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<DiagnosisDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<DiagnosisDto>> Get()
        {
            return new JsonResult<List<DiagnosisDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<DiagnosisDto>()
                {
                    new DiagnosisDto
                    {
                        Id = 1,
                        AnamnesisType = DiagnosisTypeEnum.Estimated,
                        Description = "Описание 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new DiagnosisDto
                    {
                        Id = 2,
                        AnamnesisType = DiagnosisTypeEnum.Confirmed,
                        Description = "Описание 2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new DiagnosisDto
                    {
                        Id = 3,
                        AnamnesisType = DiagnosisTypeEnum.Some,
                        Description = "Описание 3",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                },
                Message = null
            };
        }


        /// <summary>
        /// Получить  диагноз по индетификатору.
        /// </summary>
        /// <returns>Транспортная модель диагноза.</returns>
        /// <param name="id">Идентификатор диагноза.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<DiagnosisDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<DiagnosisDto> GetById([FromRoute]int id)
        {
            return new JsonResult<DiagnosisDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new DiagnosisDto
                {
                    Id = id,
                    AnamnesisType = DiagnosisTypeEnum.Some,
                    Description = "Описание 3",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow

                },
                Message = null
            };
        }

        /// <summary>
        /// Пометить диагноз.
        /// </summary>
        /// <param name="id">Идентификатор диагноза.</param>
        /// <response code="200">Успешное удаление диагноза.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">Диагноз с заданным идентификатором не найден.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
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
        /// Редактировать диагноз.
        /// </summary>
        /// <param name="id">Идентификатор диагноза.</param>
        /// <param name="assignment">Диагноз.</param>
        /// <response code="200">Успешное редактирование диагноз.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">Диагноз с заданным идентификатором не найден.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] DiagnosisDto diagnosis)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать новый диагноз
        /// </summary>
        /// <param name="allergy">Дигноз.</param>
        /// <returns>Идентификатор созданного диагноза.</returns>
        /// <response code="201">Успешное создание диагноза.</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] DiagnosisDto diagnosis)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = DiagnosisId++,
                Message = null
            };
        }
    }
}
