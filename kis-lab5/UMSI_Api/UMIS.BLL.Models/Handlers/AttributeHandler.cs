using System;
using System.Threading.Tasks;
using Common.Attributes;

namespace UMIS.BLL.Contracts.Handlers
{
    public interface IAttributeHandler
    {
        /// <summary>
        /// Обработка атрибутов вызываемого метода без возвращаемого значения
        /// </summary>
        /// <param name="func">Метод</param>
        void HandleAttributes(Action action);

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        void HandleAttributes<T>(Func<T> func);

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        void HandleAttributes<TIn, TOut>(Func<TIn, TOut> func);

        /// <summary>
        /// Обработка атрибутов вызываемого метода без возвращаемого значения
        /// </summary>
        /// <param name="func">Метод</param>
        Task HandleAttributesAsync(Func<Task> func);

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        Task HandleAttributesAsync<T>(Func<Task<T>> func);

        /// <summary>
        /// Обработка атрибутов вызываемого метода c возвращаемым значением
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого методом значения</typeparam>
        /// <param name="func">Метод</param>
        Task HandleAttributesAsync<TIn, TOut>(Func<TIn, Task<TOut>> func);

        void HandleMethodCustomAttributes(object[] attributes);

        Task HandleMethodCustomAttributesAsync(object[] attributes);

        /// <summary>
        /// Перегрузка метода обработки атрибутов
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        void Handle(ICustomAttribute attribute);

        /// <summary>
        /// Перегрузка метода обработки атрибутов
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        Task HandleAsync(ICustomAttribute customAttribute);
    }
}
