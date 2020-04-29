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
    /// Контроллер для работы с физиологическими показаниями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PhysiologicalIndicationsController : BaseApiController
    {
        /// <summary>
        /// Получить список физиологических показаний по идентификатору истории болезни
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок физиологических показаний истории болезни</returns>
        [HttpGet("medicalHistory/{medicalHistoryId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<PhysiologicalIndicationDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<PhysiologicalIndicationDto>> GetByMedicalHistoryId([FromRoute]int medicalHistoryId)
        {
            return new JsonResult<List<PhysiologicalIndicationDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<PhysiologicalIndicationDto>()
                {
                    new PhysiologicalIndicationDto
                    {
                        Id = 1,
                        Note = "Утренние замеры",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        MedicalHistoryId = medicalHistoryId
                    },
                    new PhysiologicalIndicationDto
                    {
                        Id = 2,
                        Note = "Предоперационные замеры",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        MedicalHistoryId = medicalHistoryId
                    },
                    new PhysiologicalIndicationDto
                    {
                        Id = 3,
                        Note = "Замеры под нагрузкой",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        MedicalHistoryId = medicalHistoryId
                    }
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить физиологические показания по идентификатору
        /// </summary>
        /// <returns>Транспортная модель физиологических показаний</returns>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<PhysiologicalIndicationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<PhysiologicalIndicationDto> GetById([FromRoute]int id)
        {
            return new JsonResult<PhysiologicalIndicationDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new PhysiologicalIndicationDto
                {
                    Id = id,
                    Note = "Утренние замеры",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow,
                    MedicalHistoryId = 1
                },
                Message = null
            };
        }

        /// <summary>
        /// Создать новые физиологические показания
        /// </summary>
        /// <returns>Идентификатор созанных физиологических показаний</returns>
        /// <response code="201">Успешное создание физиологических показаний</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найдена история болезни</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки физиологических показаний к истории болезни указывается внешний ключ в поле MedicalHistoryId
        /// </remarks>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] PhysiologicalIndicationDto examination)
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
        /// Привязать физиологические показания к истории болезни
        /// </summary>
        /// <param name="id">Идентификатор истории болезни</param>
        /// <param name="examination">Физиологические показания</param>
        /// <returns>Идентификатор созданной связи</returns>
        /// <response code="201">Успешная привязка физиологических показаний к истории болезни</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найдена история болезни</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки физиологических показаний к истории болезни указывается внешний ключ в поле MedicalHistoryId
        /// </remarks>
        [HttpPost("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult LinkFieldToCatalog([FromRoute]int id, [FromBody] PhysiologicalIndicationDto examination)
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
        /// Редактировать физиологические показания
        /// </summary>
        /// <param name="id">Идентификатор физиологических показаний</param>
        /// <param name="examination">Физиологические показания</param>
        /// <response code="200">Успешное редактирование физиологических показаний</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Физиологических показаний с заданным идентификатором не найдено</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] PhysiologicalIndicationDto examination)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Поменить физиологические показания удаленными
        /// </summary>
        /// <param name="id">Идентификатор физиологических показаний</param>
        /// <response code="200">Успешное удаление физиологических показаний</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Физиологических показаний с заданным идентификатором не найдено</response>
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
