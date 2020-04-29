using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Результаты анализа
    /// </summary>
    public class MedicalTestResult : BaseCommonEntity
    {
        /// <summary>
        /// Обследование
        /// </summary>
        public MedicalExamination MedicalExamination { get; set; }
        public int MedicalExaminationId { get; set; }

        /// <summary>
        /// Пациент
        /// </summary>
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
