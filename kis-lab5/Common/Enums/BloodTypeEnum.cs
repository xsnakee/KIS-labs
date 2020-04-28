using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Группа крови/Резус
    /// </summary>
    public enum BloodTypeEnum
    {
        /// <summary>
        /// Отсутствует
        /// </summary>
        [Description("Отсутствует")]
        None = 0,

        /// <summary>
        /// Первая/Резус +
        /// </summary>
        [Description("Первая/Резус +")]
        FirstPositive = 1,

        /// <summary>
        /// Первая/Резус -
        /// </summary>
        [Description("Первая/Резус -")]
        FirstNegative = 2,

        /// <summary>
        /// Вторая/Резус +
        /// </summary>
        [Description("Вторая/Резус +")]
        SecondPositive = 3,

        /// <summary>
        /// Вторая/Резус -
        /// </summary>
        [Description("Вторая/Резус -")]
        SecondNegative = 4,

        /// <summary>
        /// Третья/Резус +
        /// </summary>
        [Description("Третья/Резус +")]
        ThirdPositive = 5,

        /// <summary>
        /// Третья/Резус -
        /// </summary>
        [Description("Третья/Резус -")]
        ThirdNegative = 6,

        /// <summary>
        /// Четвертая/Резус +
        /// </summary>
        [Description("Четвертая/Резус +")]
        FourthPositive = 7,

        /// <summary>
        /// Четвертая/Резус -
        /// </summary>
        [Description("Четвертая/Резус -")]
        FourthNegative = 8
    }
}
