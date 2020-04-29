using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Пол
    /// </summary>
    public enum GenderEnum
    {
        /// <summary>
        /// Информация отсутствует
        /// </summary>
        [Description("Отсутствует")]
        None = 0,

        /// <summary>
        /// Мужской
        /// </summary>
        [Description("Мужской")]
        Male = 1,

        /// <summary>
        /// Женский
        /// </summary>
        [Description("Женский")]
        Female = 2
    }
}
