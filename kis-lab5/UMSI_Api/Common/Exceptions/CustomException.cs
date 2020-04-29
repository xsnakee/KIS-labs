using System;
using System.Net;
using System.Runtime.Serialization;
using Common.Enums;

namespace Common.Exceptions
{
    /// <summary>
    /// Базовый тип исключений АПИ
    /// </summary>
    [Serializable]
    public class CustomException : Exception
    {
        /// <summary>
        /// Возвращаемый код ошибки
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        /// <summary>
        /// Идентификатор сущности связанной с исключением
        /// </summary>
        public int? EntityId { get; set; }

        /// <summary>
        /// Тип сущности
        /// </summary>
        public EntityTypeEnum? EntityType { get; set; }

        public CustomException()
        {
        }

        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message,
            int? entityId = null,
            EntityTypeEnum? entityType = null,
            HttpStatusCode? statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            EntityId = entityId;
            EntityType = entityType;
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
