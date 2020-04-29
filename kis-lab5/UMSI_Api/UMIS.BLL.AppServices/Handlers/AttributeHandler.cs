using System;
using System.Threading.Tasks;
using Common.Attributes;
using UMIS.BLL.Contracts.Handlers;
using UMIS.BLL.Contracts.ServicesAbstraction;

namespace UMIS.BLL.AppServices.Handlers
{
    public class AttributeHandler : IAttributeHandler
    {
        private readonly IAuthManager _authManager;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="authManager"></param>
        public AttributeHandler(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        /// <summary>
        /// Обработка атрибутов вызываемого метода без возвращаемого значения
        /// </summary>
        /// <param name="func">Метод</param>
        public void HandleAttributes(Action action)
        {
            var attributes = action.Method.GetCustomAttributes(false);
            HandleMethodCustomAttributes(attributes);
        }

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        public void HandleAttributes<T>(Func<T> func)
        {
            var attributes = func.Method.GetCustomAttributes(false);
            HandleMethodCustomAttributes(attributes);
        }

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        public void HandleAttributes<TIn, TOut>(Func<TIn, TOut> func)
        {
            var attributes = func.Method.GetCustomAttributes(false);
            HandleMethodCustomAttributes(attributes);
        }

        /// <summary>
        /// Обработка атрибутов вызываемого метода без возвращаемого значения
        /// </summary>
        /// <param name="func">Метод</param>
        public async Task HandleAttributesAsync(Func<Task> func)
        {
            var attributes = func.GetType().GetCustomAttributes(false);
            await HandleMethodCustomAttributesAsync(attributes);
        }

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        public async Task HandleAttributesAsync<T>(Func<Task<T>> func)
        {
            var attributes = func.Method.GetCustomAttributes(false);
            await HandleMethodCustomAttributesAsync(attributes);

        }

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        public async Task HandleAttributesAsync<TIn, TOut>(Func<TIn, Task<TOut>> func)
        {
            var attributes = func.Method.GetCustomAttributes(false);
            await HandleMethodCustomAttributesAsync(attributes);
        }

        public void HandleMethodCustomAttributes(object[] attributes)
        {
            foreach (object attr in attributes)
            {
                ICustomAttribute customAttribute = attr as ICustomAttribute;

                if (customAttribute != null)
                {
                    Handle(customAttribute);
                }
            }
        }

        public async Task HandleMethodCustomAttributesAsync(object[] attributes)
        {
            foreach (object attr in attributes)
            {
                ICustomAttribute customAttribute = attr as ICustomAttribute;

                if (customAttribute != null)
                {
                    await HandleAsync(customAttribute);
                }
            }
        }

        /// <summary>
        /// Перегрузка метода обработки атрибутов
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public void Handle(ICustomAttribute customAttribute)
        {
            switch (customAttribute)
            {
                case PermissionsAttribute attribute:
                    {
                        _authManager
                            .CheckCurrentUserPermissionsAsync(attribute.PermissionsIds)
                            .Wait();
                        break;
                    }
            }
        }

        /// <summary>
        /// Перегрузка метода обработки атрибутов
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public async Task HandleAsync(ICustomAttribute customAttribute)
        {
            switch (customAttribute)
            {
                case PermissionsAttribute attribute:
                    {
                        await _authManager
                            .CheckCurrentUserPermissionsAsync(attribute.PermissionsIds);
                        break;
                    }
            }
        }
    }
}
