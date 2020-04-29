using System;
using System.Net;
using System.Runtime.Serialization;
using Common.Enums;

namespace Common.Exceptions
{
    /// <summary>
    /// Тип исключения при неудачном поиск сущности
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : CustomException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public EntityNotFoundException()
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public EntityNotFoundException(string message) 
            : base(message)
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public EntityNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public EntityNotFoundException(string message
            , int? entityId = null
            , EntityTypeEnum? entityType = null
            , HttpStatusCode? statusCode = HttpStatusCode.NotFound) 
            : base(message, entityId, entityType, statusCode)
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
