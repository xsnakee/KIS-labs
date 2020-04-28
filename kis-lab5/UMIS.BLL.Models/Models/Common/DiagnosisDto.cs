using System;
using Common.Enums;
using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;

namespace UMIS.BLL.Contracts.Models.Common
{
    public class DiagnosisDto : BaseCommonDto
    {
        /// <summary>
        /// Тип анамнеза
        /// </summary>
        public DiagnosisTypeEnum AnamnesisType { get; set; }

        ///// <summary>
        ///// История болезни
        ///// </summary>
        //public MedicalHistoryDto MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }

        /// <summary>
        /// Словесное описание
        /// </summary>
        public string Description { get; set; }
    }
}
