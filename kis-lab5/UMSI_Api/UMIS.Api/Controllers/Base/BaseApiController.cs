using System;
using System.Threading.Tasks;
using Common.Models.Results;
using Mvc = Microsoft.AspNetCore.Mvc;

namespace UMIS.Api.Controllers.Base
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    public abstract class BaseApiController : Mvc.ControllerBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        protected BaseApiController()
        {
        }

        /// <summary>
        /// Выполнить метод без возвращаемого результата
        /// </summary>
        /// <param name="action">Функция/лямбда выражение</param>
        protected Mvc.IActionResult ExecuteAction(Action action)
        {
            action.Invoke();
            return new JsonVoidResult();
        }

        /// <summary>
        /// Выполнить метод ассинхронно, без возвращаемого результата
        /// </summary>
        /// <param name="func">Ассинхронная функция/лямбда выражение</param>
        protected async Task<Mvc.IActionResult> ExecuteActionAsync(Func<Task> func)
        {
            await func.Invoke();
            return new JsonVoidResult();
        }

        /// <summary>
        /// Выполнить метод и вернуть результат
        /// </summary>
        /// <param name="func">Функция/лямбда выражение</param>
        /// <returns>Результат в обертке JSON</returns>
        protected Mvc.IActionResult ExecuteActionWithResult<T>(Func<T> func)
        {
            T result = func.Invoke();
            return new JsonResult<T>(result);
        }

        /// <summary>
        /// Выполнить метод ассинхронно и вернуть результат
        /// </summary>
        /// <param name="func">Ассинхронная функция/лямбда выражение</param>
        /// <returns>Результат в обертке JSON</returns>
        protected async Task<Mvc.IActionResult> ExecuteActionWithResultAsync<T>(Func<Task<T>> func)
        {
            T result = await func.Invoke();
            return new JsonResult<T>(result);
        }
    }
}