using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using UMIS.BLL.Contracts.Handlers;

namespace UMIS.Api.Filters
{
    /// <summary>
    /// Фильтр для обработки пермиссий пользователя выполнябщего запрос
    /// </summary>
    public class PermissionHandleFilter : IActionFilter
    {
        private readonly IAttributeHandler _attributeHandler;

        /// <summary>
        /// ctor
        /// </summary>
        public PermissionHandleFilter(IAttributeHandler attributeHandler)
        {
            _attributeHandler = attributeHandler;
        }

        /// <summary>
        /// Действия после выполнения метода контроллера
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// Действия перед выполнением метода контроллера
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerActionDescriptor controllerActionDescriptor =
                context.ActionDescriptor as ControllerActionDescriptor;

            if (controllerActionDescriptor != null)
            {
                object[] actionAttributes = controllerActionDescriptor
                    .MethodInfo
                    .GetCustomAttributes(inherit: true);
                _attributeHandler.HandleMethodCustomAttributes(actionAttributes);
            }
        }
    }
}
