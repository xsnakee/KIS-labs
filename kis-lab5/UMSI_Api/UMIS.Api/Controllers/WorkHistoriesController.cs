using System;
using System.Collections.Generic;
using System.Net;
using Common.Enums;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Common;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с трудовыми анамнезами пациентов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WorkHistoriesController : BaseApiController
    {
        /// <summary>
        /// Получить список трудовых анамнезов по идентификатору пациента
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок трудовых анамнезов пациента</returns>
        [HttpGet("patient/{patientId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<WorkHistoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<WorkHistoryDto>> GetByPatientId([FromRoute]int patientId)
        {
            return new JsonResult<List<WorkHistoryDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<WorkHistoryDto>()
                {
                    new WorkHistoryDto
                    {
                        Id = 1,
                        Note = "Строитель",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        PatientId = patientId
                    },
                    new WorkHistoryDto
                    {
                        Id = 2,
                        Note = "Таксист",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        PatientId = patientId
                    },
                    new WorkHistoryDto
                    {
                        Id = 3,
                        Note = "На учете в центре занятости",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        PatientId = patientId
                    }
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить трудовой анамнез по идентификатору
        /// </summary>
        /// <returns>Транспортная модель трудового анамнеза</returns>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<WorkHistoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<WorkHistoryDto> GetById([FromRoute]int id)
        {
            return new JsonResult<WorkHistoryDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new WorkHistoryDto
                {
                    Id = id,
                    Note = "Студент",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow,
                    PatientId = 1
                },
                Message = null
            };
        }

        /// <summary>
        /// Создать новый трудовой анамнез
        /// </summary>
        /// <returns>Идентификатор созанных трудового анамнеза</returns>
        /// <response code="201">Успешное создание трудового анамнеза</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найден пациент</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки трудового анамнеза к пациента указывается внешний ключ в поле PatientId
        /// </remarks>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] WorkHistoryDto workHistory)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = new Random().Next(),
                Message = null
            };
        }


        /// <summary>
        /// Привязать трудовой анамнез к пациенту
        /// </summary>
        /// <param name="id">Идентификатор пациента</param>
        /// <param name="workHistory">Трудовой анамнез</param>
        /// <returns>Идентификатор созданной связи</returns>
        /// <response code="201">Успешная привязка трудового анамнеза к пациенту</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найден пациент</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки трудового анамнеза к пациенту указывается внешний ключ в поле PatientId
        /// </remarks>
        [HttpPost("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult LinkFieldToCatalog([FromRoute]int id, [FromBody] WorkHistoryDto workHistory)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new Random().Next(),
                Message = null
            };
        }

        /// <summary>
        /// Редактировать трудовой анамнез
        /// </summary>
        /// <param name="id">Идентификатор трудового анамнеза</param>
        /// <param name="workHistory">Трудовой анамнез</param>
        /// <response code="200">Успешное редактирование трудового анамнеза</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Трудовой анамнез с заданным идентификатором не найдено</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] WorkHistoryDto workHistory)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Поменить трудовой удаленными
        /// </summary>
        /// <param name="id">Идентификатор трудового анамнеза</param>
        /// <response code="200">Успешное удаление трудового анамнеза</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Трудовой анамнез с заданным идентификатором не найдено</response>
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
    }
}
