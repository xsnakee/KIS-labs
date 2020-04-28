using System;
using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;
using Common.Enums;

namespace UMIS.BLL.Contracts.Models.Common
{
    public class MediacalAnamnesisDto : BaseCommonDto
    {

        /// <summary>
        /// Тип анамнеза
        /// </summary>
        public MedicalAnamnesisTypeEnum AnamnesisType { get; set; }

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
