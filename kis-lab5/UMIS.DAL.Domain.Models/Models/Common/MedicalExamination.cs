using System.Collections.Generic;
using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Медицинское обследование
    /// </summary>
    public class MedicalExamination : BaseCommonEntity
    {
        public MedicalExamination()
        {
            MedicalTestResults = new List<MedicalTestResult>();
        }

        /// <summary>
        /// Тип обследования
        /// </summary>
        public MedicalExaminationTypeEnum MedicalExaminationType { get; set; }

        /// <summary>
        /// История болезни
        /// </summary>
        public MedicalHistory MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }

        public IList<MedicalTestResult> MedicalTestResults { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
