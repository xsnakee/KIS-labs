using System;
using System.Collections.Generic;
using System.Net;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Common;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с заметками истории болезни
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryNotesController : BaseApiController
    {
        /// <summary>
        /// Получить список заметок по идентификатору истории болезни
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок заметок истории болезни</returns>
        [HttpGet("medicalHistory/{medicalHistoryId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<MedicalHistoryNoteDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<MedicalHistoryNoteDto>> GetByMedicalHistoryId([FromRoute]int medicalHistoryId)
        {
            return new JsonResult<List<MedicalHistoryNoteDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<MedicalHistoryNoteDto>()
                {
                    new MedicalHistoryNoteDto
                    {
                        Id = 1,
                        Content = "Заметка 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        Subject = "Заголовок заметки 1",
                        MedicalHistoryId = medicalHistoryId
                    },
                    new MedicalHistoryNoteDto
                    {
                        Id = 2,
                        Content = "Заметка 2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        Subject = "Заголовок заметки 2",
                        MedicalHistoryId = medicalHistoryId
                    },
                    new MedicalHistoryNoteDto
                    {
                        Id = 3,
                        Content = "Заметка 3",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        Subject = "Заголовок заметки 3",
                        MedicalHistoryId = medicalHistoryId
                    }
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить заметку по идентификатору
        /// </summary>
        /// <returns>Транспортная модель заметки</returns>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<MedicalHistoryNoteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<MedicalHistoryNoteDto> GetById([FromRoute]int id)
        {
            return new JsonResult<MedicalHistoryNoteDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new MedicalHistoryNoteDto
                {
                    Id = id,
                    Content = $"Заметка {id}",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow,
                    Subject = $"Заголовок заметки{id}",
                    MedicalHistoryId = 1
                },
                Message = null
            };
        }

        /// <summary>
        /// Создать новую заметку
        /// </summary>
        /// <returns>Идентификатор созанной заметки</returns>
        /// <response code="201">Успешное создание заметки</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найдена история болезни</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки заметки к истории болезни указывается внешний ключ в поле MedicalHistoryId
        /// </remarks>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] MedicalHistoryNoteDto note)
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
        /// Привязать заметку к истории болезни
        /// </summary>
        /// <param name="id">Идентификатор истории болезни</param>
        /// <param name="note">Заметка</param>
        /// <returns>Идентификатор созанной связи</returns>
        /// <response code="201">Успешная привязка заметки к истории болезни</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найдена история болезни</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки заметки к истории болезни указывается внешний ключ в поле MedicalHistoryId
        /// </remarks>
        [HttpPost("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult LinkFieldToCatalog([FromRoute]int id, [FromBody] MedicalHistoryNoteDto note)
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
        /// Редактировать заметку истории болезни
        /// </summary>
        /// <param name="id">Идентификатор заметки</param>
        /// <param name="note">Заметка</param>
        /// <response code="200">Успешное редактирование заметки</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Заметки с заданным идентификатором не найдено</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] MedicalHistoryNoteDto note)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Поменить заметку удаленной
        /// </summary>
        /// <param name="id">Идентификатор заметки</param>
        /// <response code="200">Успешное удаление заметки</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Заметки с заданным идентификатором не найдено</response>
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
