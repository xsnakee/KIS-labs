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
using UMIS.BLL.Contracts.Models.Common.Catalogs;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с медицинским обследованием
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int MedicalExaminationId { get; set; } = 0;

        /// <summary>
        /// Получить список всех медицинских обследований.
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        /// <returns>Cписок всех медицинских обследований.</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<MedicalExaminationDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<MedicalExaminationDto>> Get()
        {
            return new JsonResult<List<MedicalExaminationDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<MedicalExaminationDto>()
                {
                    new MedicalExaminationDto
                    {
                        Id = 1,
                        MedicalExaminationType = Common.Enums.MedicalExaminationTypeEnum.Common,
                        MedicalHistoryId = 1,
                        Description = "Словесное описание 1",
                        MedicalTestResults = new List<MedicalTestResultDto>
                        {
                            new MedicalTestResultDto
                            {
                               Id = 1,
                               MedicalExaminationId = 1,
                               PatientId = 1,
                               Description = "Словесное описание 1",
                               CreateDate = DateTime.UtcNow,
                               LastModificationDate = DateTime.UtcNow
                            }
                        },
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new MedicalExaminationDto
                    {
                        Id = 2,
                        MedicalExaminationType = Common.Enums.MedicalExaminationTypeEnum.Emergency,
                        MedicalHistoryId = 2,
                        Description = "Словесное описание 2",
                        MedicalTestResults = new List<MedicalTestResultDto>
                        {
                            new MedicalTestResultDto
                            {
                               Id = 2,
                               MedicalExaminationId = 2,
                               PatientId = 2,
                               Description = "Словесное описание 2",
                               CreateDate = DateTime.UtcNow,
                               LastModificationDate = DateTime.UtcNow
                            }
                        },
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow
                    }
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить медицинское обследование по идентификатору.
        /// </summary>
        /// <returns>Транспортная модель медицинского обследования.</returns>
        /// <param name="id">Идентификатор медицинского обследования.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<MedicalExaminationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<MedicalExaminationDto> GetByMedicalExaminationId([FromRoute]int id)
        {
            return new JsonResult<MedicalExaminationDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new MedicalExaminationDto
                {
                    Id = id,
                    MedicalExaminationType = Common.Enums.MedicalExaminationTypeEnum.Emergency,
                    MedicalHistoryId = 1,
                    Description = "Словесное описание 1",
                    MedicalTestResults = new List<MedicalTestResultDto>
                    {
                        new MedicalTestResultDto
                        {
                            Id = 1,
                            MedicalExaminationId = id,
                            PatientId = 1,
                            Description = "Словесное описание 1",
                            CreateDate = DateTime.UtcNow,
                            LastModificationDate = DateTime.UtcNow
                        }
                    },
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow

                },
            Message = null
            };

        }

        /// <summary>
        /// Пометить медицинское обследование удаленным.
        /// </summary>
        /// <param name="id">Идентификатор медицинского обследования.</param>
        /// <response code="200">Успешное удаление медицинского обследования.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">Медицинское обследование с заданным идентификатором не найден.</response>
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
        /// Редактировать медицинское обследование.
        /// </summary>
        /// <param name="id">Идентификатор медицинское обследование.</param>
        /// <param name="medicalTestResult">Медицинское обследование.</param>
        /// <response code="200">Успешное редактирование назначение.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">Назначение с заданным идентификатором не найден.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] MedicalTestResultDto medicalTestResult)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать медицинское обследование.
        /// </summary>
        /// <param name="medicalTestResult">Медицинское обследование.</param>
        /// <returns>Идентификатор созданного медицинскоего обследования.</returns>
        /// <response code="201">Успешное создание медицинского обследования.</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] MedicalTestResultDto medicalTestResult)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = MedicalExaminationId++,
                Message = null
            };
        }


    }
}
