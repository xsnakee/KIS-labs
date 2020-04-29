using System;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Common;
using System.Collections.Generic;
using System.Net;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с аллергоанамнезом
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyAnamnesisController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int AllergyId { get; set; } = 0;

        /// <summary>
        /// Получить список всех аллергоанамнезов.
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        /// <returns>Cписок всех аллергоанамнезов.</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<AllergyAnamnesisDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<AllergyAnamnesisDto>> Get()
        {
            return new JsonResult<List<AllergyAnamnesisDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<AllergyAnamnesisDto>()
                {
                    new AllergyAnamnesisDto
                    {
                        Id = 1,
                        PatientId = 1,
                        Note = "Словесное описание 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new AllergyAnamnesisDto
                    {
                        Id = 2,
                        PatientId = 2,
                        Note = "Словесное описание 2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new AllergyAnamnesisDto
                    {
                        Id = 3,
                        PatientId = 3,
                        Note = "Словесное описание 3",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить  аллергоанамнез по индетификатору.
        /// </summary>
        /// <returns>Транспортная модель аллергноанамнеза.</returns>
        /// <param name="id">Идентификатор алергнооанамнеза.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<AllergyAnamnesisDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<AllergyAnamnesisDto> GetById([FromRoute]int id)
        {
            return new JsonResult<AllergyAnamnesisDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new AllergyAnamnesisDto
                {
                    Id = id,
                    PatientId = 2,
                    Note = "Словесное описание 2",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow

                },
                Message = null
            };
        }

        /// <summary>
        /// Получить все аллергоанамнезы по индетификатору пациента.
        /// </summary>
        /// <returns>Транспортная модель аллергоанамнеза.</returns>
        /// <param name="id">Идентификатор пациента.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}/patient")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<AllergyAnamnesisDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<AllergyAnamnesisDto>> GetByIdPatient([FromRoute]int id)
        {
            return new JsonResult<List<AllergyAnamnesisDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<AllergyAnamnesisDto>()
                {
                    new AllergyAnamnesisDto
                    {
                        Id = 1,
                        PatientId = id,
                        Note = "Словесное описание 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new AllergyAnamnesisDto
                    {
                        Id = 2,
                        PatientId = id,
                        Note = "Словесное описание 2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                },
                Message = null
            };

        }

        /// <summary>
        /// Пометить аллергоанамнез удаленным
        /// </summary>
        /// <param name="id">Идентификатор аллергоанамнеза</param>
        /// <response code="200">Успешное удаление аллергноанамнеза</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Аллергоанамнез с заданным идентификатором не найден</response>
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
        /// Редактировать аллергоанамнез
        /// </summary>
        /// <param name="id">Идентификатор аллергоанамнеза</param>
        /// <param name="allergy">Аллергноанамнез</param>
        /// <response code="200">Успешное редактирование аллергоанамнеза</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Аллергоанамнез с заданным идентификатором не найден</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] AllergyAnamnesisDto allergy)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать новый аллергоанамнез
        /// </summary>
        /// <param name="allergy">Аллергоанамнез</param>
        /// <returns>Идентификатор созданного аллергоанамнеза</returns>
        /// <response code="201">Успешное создание справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] AllergyAnamnesisDto allergy)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = AllergyId++,
                Message = null
            };
        }
    }
}
