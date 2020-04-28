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
    /// Контроллер для работы с результатами анализов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalTestResultsController : BaseApiController
    {
        /// <summary>
        /// Получить список результатов анализов по идентификатору обследования
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок результатов анализов</returns>
        [HttpGet("MedicalExamination/{medicalExaminationId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<MedicalTestResultDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<MedicalTestResultDto>> GetByMedicalExaminationId([FromRoute]int medicalExaminationId)
        {
            return new JsonResult<List<MedicalTestResultDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<MedicalTestResultDto>()
                {
                    new MedicalTestResultDto
                    {
                        Id = 1,
                        Description = "Резлуьтат анализа 1",
                        PatientId = 1,
                        MedicalExaminationId = medicalExaminationId,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow
                    },
                    new MedicalTestResultDto
                    {
                        Id = 2,
                        Description = "Резлуьтат анализа 2",
                        PatientId = 2,
                        MedicalExaminationId = medicalExaminationId,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow
                    }
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить список результатов анализов по идентификатору пациента
        /// </summary>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <returns>Cписок результатов анализов</returns>
        [HttpGet("patient/{patientId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<List<MedicalTestResultDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<List<MedicalTestResultDto>> GetByPatientId([FromRoute]int patientId)
        {
            return new JsonResult<List<MedicalTestResultDto>>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new List<MedicalTestResultDto>()
                {
                    new MedicalTestResultDto
                    {
                        Id = 1,
                        Description = "Резлуьтат анализа 1",
                        PatientId = patientId,
                        MedicalExaminationId = 1,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow
                    },
                    new MedicalTestResultDto
                    {
                        Id = 2,
                        Description = "Резлуьтат анализа 2",
                        PatientId = patientId,
                        MedicalExaminationId = 2,
                        CreateDate = DateTime.UtcNow,
                        LastModificationDate = DateTime.UtcNow
                    }
                },
                Message = null
            };
        }

        /// <summary>
        /// Получить результат анализа по идентификатору
        /// </summary>
        /// <returns>Транспортная модель результата анализа</returns>
        /// <response code="200">Успешное выполнение запроса данных</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Возникло исключение на сервере</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<MedicalTestResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public JsonResult<MedicalTestResultDto> GetById([FromRoute]int id)
        {
            return new JsonResult<MedicalTestResultDto>()
            {
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Data = new MedicalTestResultDto
                {
                    Id = id,
                    Description = $"Резлуьтат {id} какого-то анализа",
                    PatientId = 1,
                    MedicalExaminationId = 1,
                    CreateDate = DateTime.UtcNow,
                    LastModificationDate = DateTime.UtcNow
                },
                Message = null
            };
        }

        /// <summary>
        /// Привязать результат анализа к обследованию
        /// </summary>
        /// <param name="id">Идентификатор обследования</param>
        /// <param name="medicalTestResult">Результат анализа</param>
        /// <returns>Идентификатор созданной связи</returns>
        /// <response code="201">Успешная привязка результата анализа к обследованию</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Не найдено обследование</response>
        /// <response code="500">Возникло исключение на сервере</response>
        /// <remarks>
        /// Для привязки результата анализа к обследрванию указывается внешний ключ в поле MedicalExaminationId
        /// </remarks>
        [HttpPost("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(JsonResult<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(JsonVoidResult), StatusCodes.Status500InternalServerError)]
        public IActionResult LinkFieldToCatalog([FromRoute]int id, [FromBody] MedicalTestResultDto medicalTestResult)
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
        /// Поменить результат анализа удаленным
        /// </summary>
        /// <param name="id">Идентификатор результата анализа</param>
        /// <response code="200">Успешное удаление результата анализа</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Результата анализа с заданным идентификатором не найдено</response>
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
