using System;
using Common.Enums;

using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;

namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// Назначение
    /// </summary>
    public class AssignmentDto : BaseCommonDto
    {
        /// <summary>
        /// Тип назначения
        /// </summary>
        public AssignmentTypeEnum AssignmentType { get; set; }

        ///// <summary>
        ///// История болезни
        ///// </summary>
        //public MedicalHistoryDto MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }

        /// <summary>
        /// Результат анализа
        /// </summary>
       // public MedicalTestResultDto MedicalTestResult { get; set; }

        public int? MedicalTestResultId { get; set; }

        /// <summary>
        /// Результат обследования
        /// </summary>
      //  public MedicalExaminationDto MedicalExaminationResult { get; set; }

        public int? MedicalExaminationId { get; set; }

        /// <summary>
        /// Результат осмотра
        /// </summary>
    //    public PhysicalExaminationDto PhysiologicalExaminationResult { get; set; }

        public int? PhysiologicalExaminationId { get; set; }

        /// <summary>
        /// Результат снятия физиологических показаний
        /// </summary>
     //   public PhysiologicalIndicationDto PhysiologicalIndicationResult { get; set; }

        public int? PhysiologicalIndicationId { get; set; }
    }
}
