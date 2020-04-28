using System.ComponentModel;
using Common.Attributes;

namespace Common.Enums
{
    /// <summary>
    /// Перечисление возможных действий над сущностями
    /// </summary>
    public enum PermissionsActionEnum
    {
        /// <summary>
        /// Информация о пользователе
        /// </summary>
        [Description("Просмотр")]
        View = 0,

        /// <summary>
        /// Информация о пользователе
        /// </summary>
        [Description("Просмотр")]
        DeepView = 1,

        /// <summary>
        /// Создание сущности
        /// </summary>
        [Description("Создание")]
        Create = 2,

        /// <summary>
        /// Добавление информации о сущности
        /// </summary>
        [Description("Обновление")]
        Update = 3,

        /// <summary>
        /// Редактирование сущности
        /// </summary>
        [Description("Редактирование")]
        Edit = 4,

        /// <summary>
        /// Удаление сущности
        /// </summary>
        [Description("Удаление")]
        SoftDelete = 5,

        /// <summary>
        /// Удаление сущности
        /// </summary>
        [OnlyForOwner]
        [Description("Полное удаление")]
        Delete = 6
    }
}
