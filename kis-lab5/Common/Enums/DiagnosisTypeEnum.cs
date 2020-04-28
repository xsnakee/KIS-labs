using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Типы диагнозов
    /// </summary>
    public enum DiagnosisTypeEnum
    {
        /// <summary>
        /// Неопределен
        /// </summary>
        [Description("Неопределен")]
        Undefined = 0,

        /// <summary>
        /// Предположительный
        /// </summary>
        [Description("Предположительный")]
        Estimated = 1,

        /// <summary>
        /// Подтвержденный
        /// </summary>
        [Description("Подтвержденный")]
        Confirmed = 2,

        /// <summary>
        /// Несколько диагнозов(смешанный)
        /// </summary>
        [Description("Смешанный")]
        Some = 3
    }
}
