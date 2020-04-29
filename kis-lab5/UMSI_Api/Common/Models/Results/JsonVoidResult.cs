using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Common.Models.Results
{
    /// <summary>
    /// Стандартный HTTP Ответ
    /// </summary>
    public class JsonVoidResult : IActionResult
    {
        /// <summary>
        /// Encoding по умолчанию
        /// </summary>
        protected readonly Encoding DefaultEncoding = Encoding.UTF8;
        /// <summary>
        /// Content-Type по умолчанию
        /// </summary>
        protected readonly string DefaultContentType = "application/json";
        /// <summary>
        /// Настройки для JSON сериализатора
        /// </summary>
        protected readonly JsonSerializerSettings JsonSerializerSettings;

        /// <summary>
        /// Код ответа http
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Результаты валидации
        /// </summary>
        public Dictionary<string, object> Errors { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public JsonVoidResult(HttpStatusCode code = HttpStatusCode.OK,
            string message = "",
            Dictionary<string, object> errors = null)
        {
            JsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>()
            };
            StatusCode = code;
            Message = message;
            Errors = errors;

        }

        /// <summary>
        /// Обработчик ответа
        /// </summary>
        /// <param name="context">Контекст выполнения запроса</param>
        public virtual async Task ExecuteResultAsync(ActionContext context)
        {
            // NOTE: При создании кастомных объектов, не забывать помечать атрибутом [Serializeble]
            string responseContent = JsonConvert.SerializeObject(this, JsonSerializerSettings);
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = DefaultContentType; // string.Join(';', );
            response.StatusCode = (int)StatusCode;

            await response.WriteAsync(responseContent, DefaultEncoding);

        }
    }
}
