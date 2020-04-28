using System;
using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;
using Common.Enums;


namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// Описание инвалидности
    /// </summary>
    public class DisabilityDescriptionDto : BaseCommonDto
    {
        /// <summary>
        /// Группа инвалидности
        /// </summary>
        public DisabilityGroupEnum DisabilityGroup { get; set; }

        /// <summary>
        /// Пациент
        /// </summary>
        public int? PatientId { get; set; }

        /// <summary>
        /// Словесное описание
        /// </summary>
        public string Note { get; set; }
    }
}
