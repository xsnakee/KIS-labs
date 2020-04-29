using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Осмотр
    /// </summary>
    public class PhysicalExamination : BaseCommonEntity
    {
        /// <summary>
        /// Тип осмотр
        /// </summary>
        public PhysicalExaminationTypeEnum PhysicalExaminationType { get; set; }

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