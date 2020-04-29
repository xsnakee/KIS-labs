using System;
using System.Threading.Tasks;
using Common.Exceptions;
using Common.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace UMIS.BLL.Contracts.Handlers
{
    public interface IExceptionHandler
    {
        /// <summary>
        /// Обертка для вызова метода с обработкой ошибок
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        IActionResult InternalExecuteAction(Func<IActionResult> func);

        /// <summary>
        /// Обертка для вызова ассинхронного метода с обработкой ошибок
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<IActionResult> InternalExecuteActionAsync(Func<Task<IActionResult>> func);

        /// <summary>
        /// Преобразование исключения к стандартному ответу API
        /// </summary>
        /// <returns>Стандартный ответ API</returns>
        JsonVoidResult ConvertCustomExceptionToResult<T>(T ex) where T : CustomException;

        /// <summary>
        /// Преобразование исключения к стандартному ответу API
        /// </summary>
        /// <returns>Стандартный ответ API</returns>
        JsonVoidResult ConvertExceptionToResult<T>(T ex) where T : Exception;
    }
}
