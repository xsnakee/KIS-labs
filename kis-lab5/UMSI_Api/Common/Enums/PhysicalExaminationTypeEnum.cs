using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Типы осмотров
    /// </summary>
    public enum PhysicalExaminationTypeEnum
    {
        /// <summary>
        /// Очередной (регулярный)
        /// </summary>
        [Description("Регулярный")]
        Regular = 0,

        /// <summary>
        /// Первичный
        /// </summary>
        [Description("Первичный")]
        Primary = 1,

        /// <summary>
        /// Обычный
        /// </summary>
        [Description("Обычный")]
        Commmon = 2,

        /// <summary>
        /// Экстренный
        /// </summary>
        [Description("Экстренный")]
        Emergency = 3,

        /// <summary>
        /// Внеочередной
        /// </summary>
        [Description("Внеочередной")]
        NotRegular = 4,

        /// <summary>
        /// Доврачебный
        /// </summary>
        [Description("Доврачебный")]
        Pre_medical = 5
    }
}
