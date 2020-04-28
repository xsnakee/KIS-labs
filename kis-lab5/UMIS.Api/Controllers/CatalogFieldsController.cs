using System;
using System.Collections.Generic;
using System.Net;
using Common.Enums;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Common.Catalogs;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с полями справочников
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogFieldsController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int CatalogFieldId { get; set; } = 0;

        /// <summary>
        /// Получить список полей справочников
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок полей справочников</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<CatalogFieldDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<CatalogFieldDto>> Get()
        {
            return new JsonResult<List<CatalogFieldDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<CatalogFieldDto>()
                {
                    new CatalogFieldDto
                    {
                        Id = 1,
                        Name = "Тестовое поле 1 справочника 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        DataType = DataTypeEnum.String,
                        CatalogToCatalogFieldId = 1
                    },
                    new CatalogFieldDto
                    {
                        Id = 2,
                        Name = "Тестовое поле 2 справочника 1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        DataType = DataTypeEnum.RangeDouble,
                        CatalogToCatalogFieldId = 1
                    },
                    new CatalogFieldDto
                    {
                        Id = 3,
                        Name = "Тестовое поле 1 справочника 2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow,
                        DataType = DataTypeEnum.Integer,
                        CatalogToCatalogFieldId = 2
                    },
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить поле справочника по идентификатору
        /// </summary>
        /// <returns>Транспортная модель поля справочника</returns>
        /// <param name="id">Идентификатор поля справочника</param>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<CatalogFieldDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<CatalogFieldDto> GetById([FromRoute]int id)
        {
            return new JsonResult<CatalogFieldDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new CatalogFieldDto
                {
                    Id = id,
                    Name = "Тестовое поле справочника",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow,
                    DataType = DataTypeEnum.RangeString,
                    CatalogToCatalogFieldId = 2
                },
                Message = null
            };

        }

        /// <summary>
        /// Создать новое поле для справочника
        /// </summary>
        /// <returns>Идентификатор созанного поля</returns>
        /// <response code="201">Успешное создание поля справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найден справочник</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки поля к справочнику указывается внешний ключ в поле CatalogToCatalogFieldId
        /// </remarks>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] CatalogFieldDto value)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = CatalogFieldsController.CatalogFieldId++,
                Message = null
            };
        }


        /// <summary>
        /// Привязать поле к справочнику
        /// </summary>
        /// <param name="id">Идентификатор справочника</param>
        /// <param name="catalogField">Поле справочника</param>
        /// <returns>Идентификатор созанной связи</returns>
        /// <response code="201">Успешная привязка поля к справочнику</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найден справочник</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки поля к справочнику указывается внешний ключ в поле CatalogToCatalogFieldId
        /// </remarks>
        [HttpPost("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult LinkFieldToCatalog([FromRoute]int id, [FromBody] CatalogFieldDto catalogField)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = CatalogFieldsController.CatalogFieldId++,
                Message = null
            };
        }

        /// <summary>
        /// Редактировать поле справочника
        /// </summary>
        /// <param name="id">Идентификатор поля справочника</param>
        /// <param name="catalogField">Поле справочника</param>
        /// <response code="200">Успешное редактирование поля справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Поле справочника с заданным идентификатором не найдено</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] CatalogFieldDto catalogField)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Поменить поле справочника удаленным
        /// </summary>
        /// <param name="id">Идентификатор поля справочника</param>
        /// <response code="200">Успешное удаление поля справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Поле справочника с заданным идентификатором не найдено</response>
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
