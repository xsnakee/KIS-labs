using System.Collections.Generic;

namespace Common.Models.Results
{
    /// <summary>
    /// Результат валидации с накоплением ошибок
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// Признак успешности валидации
        /// </summary>
        bool IsFailed { get; }

        /// <summary>
        /// Добавить ошибку
        /// </summary>
        /// <param name="key">Ключ добавления</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        void AddError(string key, string errorMessage);

        /// <summary>
        /// Словарь ошибок валидации
        /// </summary>
        Dictionary<string, List<string>> Errors { get; }
    }
}
