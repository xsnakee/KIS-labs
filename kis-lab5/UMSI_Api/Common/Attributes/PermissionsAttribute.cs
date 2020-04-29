using System;

namespace Common.Attributes
{
    /// <summary>
    /// Фильтр проверки пермиссий
    /// </summary>
    public class PermissionsAttribute : Attribute, ICustomAttribute
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="permissionTypes">Список кортежей сущностей и действий</param>
        public PermissionsAttribute(params int[] permissionsIds)
        {
            PermissionsIds = permissionsIds;
        }

        /// <summary>
        /// Список пермиссий для проверки
        /// </summary>
        public int[] PermissionsIds { get; set; }
    }
}
