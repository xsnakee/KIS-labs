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
    /// Контроллер для работы с инвалидностью
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DisabilityDescriptionController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int DisabilityDescriptionId { get; set; } = 0;

        /// <summary>
        /// Получить список всех пациентов с группой инвалидности.
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        /// <returns>Cписок всех пациенотов с группой инвалидности.</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<DisabilityDescriptionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<DisabilityDescriptionDto>> Get()
        {
            return new JsonResult<List<DisabilityDescriptionDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<DisabilityDescriptionDto>()
                {
                    new DisabilityDescriptionDto
                    {
                        Id = 1,
                        PatientId = 1,
                        DisabilityGroup = Common.Enums.DisabilityGroupEnum.First,
                        Note = "Словесное описание 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new DisabilityDescriptionDto
                    {
                        Id = 2,
                        PatientId = 2,
                        DisabilityGroup = Common.Enums.DisabilityGroupEnum.Second,
                        Note = "Словесное описание 2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new DisabilityDescriptionDto
                    {
                        Id = 3,
                        PatientId = 3,
                        DisabilityGroup = Common.Enums.DisabilityGroupEnum.Third,
                        Note = "Словесное описание 3",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                },
                Message = null
            };
        }

        /// <summary>
        /// Пометить описание инвалидности пациента удаленным
        /// </summary>
        /// <param name="id">Идентификатор инвалидности пациента.</param>
        /// <response code="200">Успешное удаление инвалидности пациента.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">Инвалидность пациента с заданным идентификатором не найден.</response>
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
        /// Редактировать инвалидность определенного пациента.
        /// </summary>
        /// <param name="id">Идентификатор инвалидности определенного пациента.</param>
        /// <param name="DisabilityDescriptionDto">инвалидность определенного пациента.</param>
        /// <response code="200">Успешное редактирование инвалидности определенногоо пациента.</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Инвалидность определенного пациента с заданным идентификатором не найден.</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] DisabilityDescriptionDto disabilityDescription)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать новую инвалидность определенного пациента.
        /// </summary>
        /// <param name="disabilityDescription">Инвалидность определенного пациента.</param>
        /// <returns>Идентификатор созданной инвалидности определенного пациента.</returns>
        /// <response code="201">Успешное создание инвалидности определенного опациента.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] MediacalAnamnesisDto mediacalAnamnesis)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = DisabilityDescriptionId++,
                Message = null
            };
        }
    }
}
