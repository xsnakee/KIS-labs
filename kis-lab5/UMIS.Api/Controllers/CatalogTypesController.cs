using System;
using System.Collections.Generic;
using System.Net;
using Common.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMIS.Api.Controllers.Base;
using UMIS.BLL.Contracts.Models.Common.Catalogs;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с типами типов справочников
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogTypesController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int CatalogTypeId { get; set; } = 0;

        /// <summary>
        /// Получить список типов справочников
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок типов справочников</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<CatalogTypeDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<CatalogTypeDto>> Get()
        {
            return new JsonResult<List<CatalogTypeDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<CatalogTypeDto>()
                {
                    new CatalogTypeDto
                    {
                        Id = 1,
                        Name = "Тестовый тип справочника1",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow
                    },
                        new CatalogTypeDto
                    {
                        Id = 2,
                        Name = "Тестовый тип справочника2",
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow
                    },

                },
                Message = null
            };
        }

        /// <summary>
        /// Получить типа справочника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор типа справочника</param>
        /// <returns>Транспортная модель типа справочника</returns>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<CatalogTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<CatalogTypeDto> GetById([FromRoute]int id)
        {
            return new JsonResult<CatalogTypeDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new CatalogTypeDto
                {
                    Id = id,
                    Name = "Тестовый тип справочник",
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow
                },
                Message = null
            };

        }

        /// <summary>
        /// Создать новый тип справочника
        /// </summary>
        /// <param name="catalogType">Тип справочника</param>
        /// <returns>Идентификатор созанного типа справочника</returns>
        /// <response code="201">Успешное создание типа справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] CatalogTypeDto catalogType)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = CatalogTypesController.CatalogTypeId++,
                Message = null
            };
        }

        /// <summary>
        /// Редактировать тип справочника
        /// </summary>
        /// <param name="id">Идентификатор типа справочника</param>
        /// <param name="catalogType">Тип справочника</param>
        /// <response code="200">Успешное редактирование типа справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Справочник с заданным идентификатором не найден</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute]int id, [FromBody] CatalogTypeDto catalogType)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Пометить тип справочника удаленным
        /// </summary>
        /// <param name="id">Идентификатор типа справочника</param>
        /// <response code="200">Успешное удаление типа справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Справочник с заданным идентификатором не найден</response>
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
