using System.Collections.Generic;

namespace Common.Models.Results
{
    public class ValidationResult : IValidationResult
    {
        public ValidationResult()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ValidationResult(Dictionary<string, List<string>> errors)
        {
            Errors = errors;
        }

        /// <summary>
        /// Статус валидации
        /// </summary>
        public bool IsFailed { get; set; }

        /// <summary>
        /// Список ошибок
        /// </summary>
        public Dictionary<string, List<string>> Errors { get; set; }

        /// <summary>
        /// Метод добавления ошибок
        /// </summary>
        /// <param name="key"></param>
        /// <param name="errorMessage"></param>
        public void AddError(string key, string errorMessage)
        {
            IsFailed = true;

            if (Errors.TryGetValue(key, out List<string> ErrorsList))
            {
                ErrorsList.Add(errorMessage);
            }
            else
            {
                Errors.TryAdd(key, new List<string>()
                {
                    errorMessage
                });
            }
        }
    }
}
