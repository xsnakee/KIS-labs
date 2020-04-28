using System;
using Common.Enums;
using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;
using System.Collections.Generic;

namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// Медицинское обследование
    /// </summary>
    public class MedicalExaminationDto : BaseCommonDto
    {
        public MedicalExaminationDto()
        {
            MedicalTestResults = new List<MedicalTestResultDto>();
        }

        /// <summary>
        /// Тип обследования
        /// </summary>
        public MedicalExaminationTypeEnum MedicalExaminationType { get; set; }

        ///// <summary>
        ///// История болезни
        ///// </summary>
        //public MedicalHistoryDto MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }

        public IList<MedicalTestResultDto> MedicalTestResults { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
