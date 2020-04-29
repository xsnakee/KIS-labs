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
    /// Контроллер для работы с медицинскими осмотрами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalExaminationsController: BaseApiController
    {
        /// <summary>
        /// Получить список медосмотров по идентификатору истории болезни
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок медосмотров истории болезни</returns>
        [HttpGet("medicalHistory/{medicalHistoryId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<PhysicalExaminationDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<PhysicalExaminationDto>> GetByMedicalHistoryId([FromRoute]int medicalHistoryId)
        {
            return new JsonResult<List<PhysicalExaminationDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<PhysicalExaminationDto>()
                {
                    new PhysicalExaminationDto
                    {
                        Id = 1,
                        Description = "Утренний",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        PhysicalExaminationType = PhysicalExaminationTypeEnum.Emergency,
                        MedicalHistoryId = medicalHistoryId
                    },
                    new PhysicalExaminationDto
                    {
                        Id = 2,
                        Description = "Предоперационный",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        PhysicalExaminationType = PhysicalExaminationTypeEnum.NotRegular,
                        MedicalHistoryId = medicalHistoryId
                    },
                    new PhysicalExaminationDto
                    {
                        Id = 3,
                        Description = "Самостоятельный дома",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        PhysicalExaminationType = PhysicalExaminationTypeEnum.Pre_medical,
                        MedicalHistoryId = medicalHistoryId
                    }
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить медосмотр по идентификатору
        /// </summary>
        /// <returns>Транспортная модель медосмотра</returns>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<PhysicalExaminationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<PhysicalExaminationDto> GetById([FromRoute]int id)
        {
            return new JsonResult<PhysicalExaminationDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new PhysicalExaminationDto
                {
                    Id = id,
                    Description = "Утренний медосмотр",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow,
                    PhysicalExaminationType = PhysicalExaminationTypeEnum.Commmon,
                    MedicalHistoryId = 1
                },
                Message = null
            };
        }

        /// <summary>
        /// Создать новый медосмотр
        /// </summary>
        /// <returns>Идентификатор созанного медосмотра</returns>
        /// <response code="201">Успешное создание медосмотра</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найдена история болезни</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки медосмотр к истории болезни указывается внешний ключ в поле MedicalHistoryId
        /// </remarks>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] PhysicalExaminationDto examination)
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
        /// Привязать медосмотр к истории болезни
        /// </summary>
        /// <param name="id">Идентификатор истории болезни</param>
        /// <param name="examination">Медосмотр</param>
        /// <returns>Идентификатор созданной связи</returns>
        /// <response code="201">Успешная привязка медосмотра к истории болезни</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найдена история болезни</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки медосмотра к истории болезни указывается внешний ключ в поле MedicalHistoryId
        /// </remarks>
        [HttpPost("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult LinkFieldToCatalog([FromRoute]int id, [FromBody] PhysicalExaminationDto examination)
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
        /// Редактировать медосмотр
        /// </summary>
        /// <param name="id">Идентификатор медосмотра</param>
        /// <param name="examination">Медосмотр</param>
        /// <response code="200">Успешное редактирование медосмотра</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Медосмотра с заданным идентификатором не найдено</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] PhysicalExaminationDto examination)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Поменить медосмотр удаленным
        /// </summary>
        /// <param name="id">Идентификатор медосмотра</param>
        /// <response code="200">Успешное удаление медосмотра</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Медосмотра с заданным идентификатором не найдено</response>
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
