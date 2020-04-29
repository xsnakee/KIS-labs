using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Common.Helpers
{
    /// <summary>
    /// Методы расширения для получения атрибутов
    /// </summary>
    public static class AttributesHelper
    {
        /// <summary>
        /// Получить значение Description атрибута у сущности
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        /// <returns>Опиание сущности из Description атрибута</returns>
        public static string GetDescriptionAttribute<T>(this T entity)
        {
            var entityType = typeof(T);
            string entityFieldName = entityType.GetEnumName(entity);
            FieldInfo entityField = entityType.GetField(entityFieldName);
            DescriptionAttribute entityDescriptionAttribute =
                entityField.GetCustomAttribute(typeof(DescriptionAttribute), true) as DescriptionAttribute;

            return entityDescriptionAttribute.Description;
        }
    }
}
