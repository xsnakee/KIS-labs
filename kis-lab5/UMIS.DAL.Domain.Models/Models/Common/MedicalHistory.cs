using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// История болезни
    /// </summary>
    public class MedicalHistory : BaseCommonEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MedicalHistory()
        {
            MedicalAnamneses = new List<MediacalAnamnesis>();
            PhysiologicalIndications = new List<PhysiologicalIndication>();
            MedicalExaminations = new List<MedicalExamination>();
            PhysicalExaminations = new List<PhysicalExamination>();
            Diagnoses = new List<Diagnosis>();
            Notes = new List<MedicalHistoryNote>();
            Assignments = new List<Assignment>();
        }

        /// <summary>
        /// Пациент
        /// </summary>
        public Patient Patient { get; set; }
        public int? PatientId { get; set; }

        /// <summary>
        /// Анамнезы
        /// </summary>
        public IList<MediacalAnamnesis> MedicalAnamneses { get; set; }

        /// <summary>
        /// Физиологические показания
        /// </summary>
        public IList<PhysiologicalIndication> PhysiologicalIndications { get; set; }

        /// <summary>
        /// Обследования
        /// </summary>
        public IList<MedicalExamination> MedicalExaminations { get; set; }

        /// <summary>
        /// Осмотры
        /// </summary>
        public IList<PhysicalExamination> PhysicalExaminations { get; set; }

        /// <summary>
        /// Диагнозы
        /// </summary>
        public IList<Diagnosis> Diagnoses { get; set; }

        /// <summary>
        /// Заметки
        /// </summary>
        public IList<MedicalHistoryNote> Notes { get; set; }

        /// <summary>
        /// Назначения
        /// </summary>
        public IList<Assignment> Assignments { get; set; }
    }
}