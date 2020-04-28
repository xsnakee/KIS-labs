using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Описание инвалидности
    /// </summary>
    public class DisabilityDescription : BaseCommonEntity
    {
        /// <summary>
        /// Группа инвалидности
        /// </summary>
        public DisabilityGroupEnum DisabilityGroup { get; set; }

        /// <summary>
        /// Пациент
        /// </summary>
        public Patient Patient { get; set; }
        public int? PatientId { get; set; }

        /// <summary>
        /// Словесное описание
        /// </summary>
        public string Note { get; set; }
    }
}
