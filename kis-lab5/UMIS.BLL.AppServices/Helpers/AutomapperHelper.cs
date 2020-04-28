using System.Collections.Generic;
using AutoMapper;
using Common.Models.Results;
using Microsoft.AspNetCore.Identity;

namespace UMIS.BLL.AppServices.Helpers
{
    public static class AutomapperHelper
    {
        /// <summary>
        /// Конвертация постраничного результата
        /// </summary>
        /// <typeparam name="T1">Исходный тип</typeparam>
        /// <typeparam name="T2">Возвращаемый тип</typeparam>
        /// <param name="source">Источник</param>
        /// <param name="mapper">ИНстанс автомаппера</param>
        /// <returns>Постраничный результат <see cref="T2"/></returns>
        public static PaginationResult<T2> Convert<T1, T2>(this PaginationResult<T1> source, IMapper mapper)
        {
            return new PaginationResult<T2>
            {
                CurrentPage = source.CurrentPage,
                Items = mapper.Map<List<T2>>(source.Items),
                TotalPages = source.TotalPages,
                TotalRecords = source.TotalRecords
            };
        }

        /// <summary>
        /// Маппинг IdentityError в словарь для ValidationResult
        /// </summary>
        /// <param name="errors">Коллекция Identity Error</param>
        /// <returns>Словарь ошибок для ValidationResult</returns>
        public static Dictionary<string, List<string>> ConvertToValidationResult(this IEnumerable<IdentityError> errors)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            if (errors != null)
            {
                foreach (IdentityError error in errors)
                {
                    if (result.TryGetValue(error.Code, out List<string> ErrorsList))
                    {
                        ErrorsList.Add(error.Description);
                    }
                    else
                    {
                        result.TryAdd(error.Code, new List<string>()
                        {
                            error.Description
                        });
                    }
                }

                return result;
            }

            return result;
        }
    }
}
