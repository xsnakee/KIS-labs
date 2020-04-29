using System;
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

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с медицинским анамнезом
    /// </summary>
    [Route("api/[controller]")]
    public class MediacalAnamnesisController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int MedicalAnamnesistionId { get; set; } = 0;


        /// <summary>
        /// Получить список всех медицинских анамнезов.
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        /// <returns>Cписок всех медицинских анамнезов.</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<MediacalAnamnesisDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<MediacalAnamnesisDto>> Get()
        {
            return new JsonResult<List<MediacalAnamnesisDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<MediacalAnamnesisDto>()
                {
                    new MediacalAnamnesisDto
                    {
                        Id = 1,
                        MedicalHistoryId = 1,
                        AnamnesisType = MedicalAnamnesisTypeEnum.Regular,
                        Description = "Словесное описание 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                   new MediacalAnamnesisDto
                    {
                        Id = 2,
                        MedicalHistoryId = 2,
                        AnamnesisType = MedicalAnamnesisTypeEnum.Regular,
                        Description = "Словесное описание 2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить медицинский анамнез по идентификатору.
        /// </summary>
        /// <returns>Транспортная модель медицинского обследования.</returns>
        /// <param name="id">Идентификатор медицинского обследования.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<MediacalAnamnesisDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<MediacalAnamnesisDto> GetByMedicalAnamnesId([FromRoute]int id)
        {

            return new JsonResult<MediacalAnamnesisDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new MediacalAnamnesisDto
                {
                    Id = id,

                    AnamnesisType = MedicalAnamnesisTypeEnum.Regular,
                    Description = "Словесное описание 1",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow
                },
                Message = null
            };
        }

        /// <summary>
        /// Пометить медицинский анамнез удаленным
        /// </summary>
        /// <param name="id">Идентификатор медицинского анамнеза.</param>
        /// <response code="200">Успешное удаление аллергноанамнеза.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">Медицинский анамнез с заданным идентификатором не найден.</response>
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
        /// Редактировать медицинский анамнез.
        /// </summary>
        /// <param name="id">Идентификатор медицинского анамнеза.</param>
        /// <param name="mediacalAnamnesis">Медицинский анамнез.</param>
        /// <response code="200">Успешное редактирование медицинского анамнеза.</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Медицинский анамнез с заданным идентификатором не найден.</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] MediacalAnamnesisDto mediacalAnamnesis)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать новый медицинский анамнез.
        /// </summary>
        /// <param name="mediacalAnamnesis">Медицинский анамнез.</param>
        /// <returns>Идентификатор созданного медицинского анамнеза.</returns>
        /// <response code="201">Успешное создание справочника.</response>
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
                Data = MedicalAnamnesistionId++,
                Message = null
            };
        }

    }
}
            

