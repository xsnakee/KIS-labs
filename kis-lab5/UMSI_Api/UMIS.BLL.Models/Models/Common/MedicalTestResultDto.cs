using System;
using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;

namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// Результаты анализа
    /// </summary>
    public class MedicalTestResultDto : BaseCommonDto
    {
        ///// <summary>
        ///// Обследование
        ///// </summary>
        //public MedicalExaminationDto MedicalExamination { get; set; }
        public int MedicalExaminationId { get; set; }

        ///// <summary>
        ///// Пациент
        ///// </summary>
        //public PatientDto Patient { get; set; }
        public int PatientId { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
