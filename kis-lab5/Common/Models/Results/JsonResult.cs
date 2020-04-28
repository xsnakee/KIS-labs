using System.Collections.Generic;
using System.Net;

namespace Common.Models.Results
{
    /// <summary>
    /// стандартный Http ответ с данными 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonResult<T> : JsonVoidResult
    {
        /// <summary>
        /// Данные
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public JsonResult(
            T data = default(T),
            HttpStatusCode code = HttpStatusCode.OK,
            string message = "",
            Dictionary<string, object> errors = null) : base(code, message, errors)
        {
            Data = data;
        }
    }
}
