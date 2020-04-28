﻿using System;
using System.Linq;
using Common.Exceptions;
using Common.Models.Results;
using Microsoft.AspNetCore.Mvc.Filters;
using UMIS.BLL.Contracts.Handlers;

namespace UMIS.Api.Filters
{
    /// <summary>
    /// Фильтр обработки исключений
    /// </summary>
    public class ExceptionToVoidResultFilter : Attribute, IExceptionFilter
    {
        private readonly IExceptionHandler _exceptionHandler;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="excpetionHandler">Менеджер обработки исключений</param>
        public ExceptionToVoidResultFilter(IExceptionHandler excpetionHandler)
        {
            _exceptionHandler = excpetionHandler;
        }

        /// <summary>
        /// Обработчик исключений
        /// </summary>
        /// <param name="context">Контекс исключений</param>
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ValidationException exception:
                    {
                        string message = string.Join(';', exception.ValidationResult.Errors.Select(e => $"{e.Key} : {string.Join(',', e.Value)}"));
                        context.Result = new JsonResult<ValidationException>(exception, exception.StatusCode, message);
                        break;
                    }
                case CustomException exception:
                    {
                        context.Result = _exceptionHandler.ConvertCustomExceptionToResult(exception);
                        break;
                    }
                default:
                    {
                        context.Result = _exceptionHandler.ConvertExceptionToResult(context.Exception);
                        break;
                    }
            }

            context.ExceptionHandled = true;
        }
    }
}
