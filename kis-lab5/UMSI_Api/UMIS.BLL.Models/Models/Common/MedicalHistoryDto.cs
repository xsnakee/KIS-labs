using System;
using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;
using System.Collections.Generic;

namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// История болезни
    /// </summary>
    public class MedicalHistoryDto : BaseCommonDto
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MedicalHistoryDto()
        {
            MedicalAnamneses = new List<MediacalAnamnesisDto>();
            PhysiologicalIndications = new List<PhysiologicalIndicationDto>();
            MedicalExaminations = new List<MedicalExaminationDto>();
            PhysicalExaminations = new List<PhysicalExaminationDto>();
            Diagnoses = new List<DiagnosisDto>();
            Notes = new List<MedicalHistoryNoteDto>();
            Assignments = new List<AssignmentDto>();
        }

        /// <summary>
        /// Пациент
        /// </summary>
      //public PatientDto Patient { get; set; }
        public int? PatientId { get; set; }

        /// <summary>
        /// Анамнезы
        /// </summary>
        public IList<MediacalAnamnesisDto> MedicalAnamneses { get; set; }

        /// <summary>
        /// Физиологические показания
        /// </summary>
        public IList<PhysiologicalIndicationDto> PhysiologicalIndications { get; set; }

        /// <summary>
        /// Обследования
        /// </summary>
        public IList<MedicalExaminationDto> MedicalExaminations { get; set; }

        /// <summary>
        /// Осмотры
        /// </summary>
        public IList<PhysicalExaminationDto> PhysicalExaminations { get; set; }

        /// <summary>
        /// Диагнозы
        /// </summary>
        public IList<DiagnosisDto> Diagnoses { get; set; }

        /// <summary>
        /// Заметки
        /// </summary>
        public IList<MedicalHistoryNoteDto> Notes { get; set; }

        /// <summary>
        /// Назначения
        /// </summary>
        public IList<AssignmentDto> Assignments { get; set; }
    }
}
