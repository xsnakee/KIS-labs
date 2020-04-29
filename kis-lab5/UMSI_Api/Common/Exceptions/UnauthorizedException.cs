using System;
using System.Net;
using System.Runtime.Serialization;
using Common.Enums;

namespace Common.Exceptions
{
    /// <summary>
    /// Исключение при ошибке доступа
    /// </summary>
    public class UnauthorizedException : CustomException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UnauthorizedException()
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public UnauthorizedException(string message)
            : base(message)
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public UnauthorizedException(string message,
            Exception innerException)
            : base(message, innerException)
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public UnauthorizedException(string message,
            int? entityId = null,
            EntityTypeEnum? entityType = null,
            HttpStatusCode? statusCode = HttpStatusCode.Unauthorized)
            : base(message, entityId, entityType)
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }
    }
}
