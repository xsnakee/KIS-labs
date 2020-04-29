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
using UMIS.BLL.Contracts.Models.Common.Catalogs;

namespace UMIS.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с назначениями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : BaseApiController
    {
        /// <summary>
        /// Счетчик идентификаторов
        /// </summary>
        public static int AssignmentId { get; set; } = 0;

        /// <summary>
        /// Получить список всех назначений.
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        /// <returns>Cписок всех назначений.</returns>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<AssignmentDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<AssignmentDto>> Get()
        {
            return new JsonResult<List<AssignmentDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<AssignmentDto>()
                {
                    new AssignmentDto
                    {
                        Id = 1,
                        AssignmentType = AssignmentTypeEnum.MedicalExamination,
                        MedicalTestResultId = 1,
                        MedicalExaminationId = 1,
                        PhysiologicalExaminationId = 1,
                        PhysiologicalIndicationId = 1,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new AssignmentDto
                    {
                        Id = 2,
                        AssignmentType = AssignmentTypeEnum.MedicalTest,
                        MedicalTestResultId = 2,
                        MedicalExaminationId = 2,
                        PhysiologicalExaminationId = 2,
                        PhysiologicalIndicationId = 2,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new AssignmentDto
                    {
                        Id = 3,
                        AssignmentType = AssignmentTypeEnum.Operation,
                        MedicalTestResultId = 3,
                        MedicalExaminationId = 3,
                        PhysiologicalExaminationId = 3,
                        PhysiologicalIndicationId = 3,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить  назначение по индетификатору.
        /// </summary>
        /// <returns>Транспортная модель назначения.</returns>
        /// <param name="id">Идентификатор назначения.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<AssignmentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<AssignmentDto> GetById([FromRoute]int id)
        {
            return new JsonResult<AssignmentDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new AssignmentDto
                {
                    Id = id,
                    AssignmentType = AssignmentTypeEnum.PhysiologicalIndication,
                    MedicalTestResultId = 3,
                    MedicalExaminationId = 3,
                    PhysiologicalExaminationId = 3,
                    PhysiologicalIndicationId = 3,
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow

                },
                Message = null
            };
        }

        /// <summary>
        /// Получить все назначения по индетификатору истории болезни.
        /// </summary>
        /// <returns>Транспортная модель назначения.</returns>
        /// <param name="id">Идентификатор истории болезни.</param>
        /// <response code="200">Успешное выполнение запроса данных.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="500">Возникло исключение на сервере.</response>
        [HttpGet("{id}/medicalhistory")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<AssignmentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<AssignmentDto>> GetByMedicalHistoryId([FromRoute]int id)
        {
            return new JsonResult<List<AssignmentDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<AssignmentDto>()
                {
                    new AssignmentDto
                    {
                        Id = 1,
                        AssignmentType = AssignmentTypeEnum.MedicalExamination,
                        MedicalTestResultId = 1,
                        MedicalExaminationId = 1,
                        PhysiologicalExaminationId = 1,
                        PhysiologicalIndicationId = 1,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new AssignmentDto
                    {
                        Id = 2,
                        AssignmentType = AssignmentTypeEnum.MedicalTest,
                        MedicalTestResultId = 2,
                        MedicalExaminationId = 2,
                        PhysiologicalExaminationId = 2,
                        PhysiologicalIndicationId = 2,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                    new AssignmentDto
                    {
                        Id = 3,
                        AssignmentType = AssignmentTypeEnum.Operation,
                        MedicalTestResultId = 3,
                        MedicalExaminationId = 3,
                        PhysiologicalExaminationId = 3,
                        PhysiologicalIndicationId = 3,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow

                    },
                },
                Message = null
            };

        }

        /// <summary>
        /// Пометить назначение удаленным.
        /// </summary>
        /// <param name="id">Идентификатор назначения.</param>
        /// <response code="200">Успешное удаление назначения.</response>
        /// <response code="401">Ошибка авторизации.</response>
        /// <response code="404">Назначение с заданным идентификатором не найден.</response>
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
        /// Редактировать назначение.
        /// </summary>
        /// <param name="id">Идентификатор назначения.</param>
        /// <param name="assignment">Назначение.</param>
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
        public IActionResult Put([FromRoute]int id, [FromBody] AssignmentDto assignment)
        {
            return new JsonVoidResult
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = null
            };
        }

        /// <summary>
        /// Создать новое назначение
        /// </summary>
        /// <param name="allergy">Назначение</param>
        /// <returns>Идентификатор созданного назначение</returns>
        /// <response code="201">Успешное создание справочника</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] AssignmentDto assignment)
        {
            return new JsonResult<int>
            {
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Data = AssignmentId++,
                Message = null
            };
        }
    }
}
