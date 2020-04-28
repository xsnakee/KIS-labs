using Common.Enums;
using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Назначение
    /// </summary>
    public class Assignment : BaseCommonEntity
    {
        /// <summary>
        /// Тип назначения
        /// </summary>
        public AssignmentTypeEnum AssignmentType { get; set; }

        /// <summary>
        /// История болезни
        /// </summary>
        public MedicalHistory MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }

        /// <summary>
        /// Результат анализа
        /// </summary>
        public MedicalTestResult MedicalTestResult { get; set; }

        public int? MedicalTestResultId { get; set; }

        /// <summary>
        /// Результат обследования
        /// </summary>
        public MedicalExamination MedicalExaminationResult { get; set; }

        public int? MedicalExaminationId { get; set; }

        /// <summary>
        /// Результат осмотра
        /// </summary>
        public PhysicalExamination PhysiologicalExaminationResult { get; set; }

        public int? PhysiologicalExaminationId { get; set; }

        /// <summary>
        /// Результат снятия физиологических показаний
        /// </summary>
        public PhysiologicalIndication PhysiologicalIndicationResult { get; set; }

        public int? PhysiologicalIndicationId { get; set; }
    }
}
