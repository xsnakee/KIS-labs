using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Группы инвалидности
    /// </summary>
    public enum DisabilityGroupEnum
    {
        /// <summary>
        /// Информация отсутствует
        /// </summary>
        [Description("Отсутствует")]
        None = 0,

        /// <summary>
        /// Первая
        /// </summary>
        [Description("Первая")]
        First = 1,

        /// <summary>
        /// Вторая
        /// </summary>
        [Description("Вторая")]
        Second = 2,

        /// <summary>
        /// Третья
        /// </summary>
        [Description("Третья")]
        Third = 3,

        /// <summary>
        /// Третья
        /// </summary>
        [Description("Детская")]
        Child = 4
    }
}
