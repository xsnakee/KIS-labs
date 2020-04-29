using System;
using System.Runtime.Serialization;
using Common.Enums;
using Common.Models.Results;

namespace Common.Exceptions
{
    /// <summary>
    /// Валидационное исключение
    /// </summary>
    [Serializable]
    public class ValidationException : CustomException
    {
        /// <summary>
        /// Результат валидации
        /// </summary>
        public IValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ValidationException()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ValidationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ValidationException(string message, Exception innerException) :
            base(message, innerException)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ValidationException(string message, int? entityId = null, EntityTypeEnum? entityType = null) :
            base(message, entityId, entityType)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ValidationException(IValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
