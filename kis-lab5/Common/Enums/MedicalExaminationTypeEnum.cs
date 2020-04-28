using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Тип медицинского обследования
    /// </summary>
    public enum MedicalExaminationTypeEnum
    {
        /// <summary>
        /// Обычное
        /// </summary>
        [Description("Обычное")]
        Common = 0,

        /// <summary>
        /// Экстренное
        /// </summary>
        [Description("Экстренное")]
        Emergency = 1
    }
}
