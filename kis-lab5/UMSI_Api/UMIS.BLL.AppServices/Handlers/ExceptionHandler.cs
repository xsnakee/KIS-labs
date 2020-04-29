using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions;
using Common.Models.Results;
using Common.Resources.Messages;
using Microsoft.AspNetCore.Mvc;
using UMIS.BLL.Contracts.Handlers;

namespace UMIS.BLL.AppServices.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        //protected readonly ILogger Logger;

        //public ExceptionHandler(ILogger logger)
        //{
        //    Logger = logger;
        //}

        /// <summary>
        /// Обертка для вызова метода с обработкой ошибок
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public IActionResult InternalExecuteAction(Func<IActionResult> func)
        {
            try
            {
                return func.Invoke();
            }

            catch (ValidationException ex)
            {
                string message = string.Join(';', ex.ValidationResult.Errors.Select(e => $"{e.Key} : {string.Join(',', e.Value)}"));
                return new JsonResult<ValidationException>(null, ex.StatusCode, message);
            }

            catch (CustomException ex)
            {
                return ConvertCustomExceptionToResult(ex);
            }

            catch (Exception ex)
            {
                return ConvertExceptionToResult(ex);
            }
        }

        /// <summary>
        /// Обертка для вызова ассинхронного метода с обработкой ошибок
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<IActionResult> InternalExecuteActionAsync(Func<Task<IActionResult>> func)
        {
            try
            {
                return await func.Invoke();
            }

            catch (ValidationException ex)
            {
                string message = string.Join(';', ex.ValidationResult.Errors.Select(e => $"{e.Key} : {string.Join(',', e.Value)}"));
                return new JsonResult<ValidationException>(ex, ex.StatusCode, message);
            }

            catch (CustomException ex)
            {
                return ConvertCustomExceptionToResult(ex);
            }

            catch (Exception ex)
            {
                return ConvertExceptionToResult(ex);
            }
        }

        /// <summary>
        /// Преобразование исключения к стандартному ответу API
        /// </summary>
        /// <returns>Стандартный ответ API</returns>
        public JsonVoidResult ConvertCustomExceptionToResult<T>(T ex) where T : CustomException
        {
            Dictionary<string, object> ErrorsList = new Dictionary<string, object>()
            {
                {typeof(T).Name, ex }
            };
            return new JsonVoidResult(ex.StatusCode, ex.Message, ErrorsList);
        }

        /// <summary>
        /// Преобразование исключения к стандартному ответу API
        /// </summary>
        /// <returns>Стандартный ответ API</returns>
        public JsonVoidResult ConvertExceptionToResult<T>(T ex) where T : Exception
        {
            Dictionary<string, object> ErrorsList = new Dictionary<string, object>()
            {
                {typeof(T).Name, ex }
            };
            return new JsonVoidResult(HttpStatusCode.InternalServerError, Messages.Exception_Default, ErrorsList);
        }
    }
}
