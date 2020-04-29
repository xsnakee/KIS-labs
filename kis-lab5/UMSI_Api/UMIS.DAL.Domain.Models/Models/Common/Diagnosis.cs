using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    public class Diagnosis : BaseCommonEntity
    {
        /// <summary>
        /// Тип анамнеза
        /// </summary>
        public DiagnosisTypeEnum AnamnesisType { get; set; }

        /// <summary>
        /// История болезни
        /// </summary>
        public MedicalHistory MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }

        /// <summary>
        /// Словесное описание
        /// </summary>
        public string Description { get; set; }
    }
}
