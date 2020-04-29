﻿using UMIS.BLL.Contracts.Models.Base;
using UMIS.BLL.Contracts.Models.Common.Catalogs.RelationsEntityDto;

namespace UMIS.BLL.Contracts.Models.Common.Catalogs
{
    /// <summary>
    /// Значение поля справочника
    /// </summary>
    public class CatalogFieldValueDto : BaseDtoWithTimestamp
    {
        /// <summary>
        /// Отношение справочника к полю справочника
        /// </summary>
        public CatalogToCatalogFieldDto CatalogToCatalogField { get; set; }
        public int CatalogToCatalogFieldId { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Значение2 (используется для диапазонов)
        /// </summary>
        public string Value2 { get; set; }

        public int? DianosisId { get; set; }
        public int? MediacalAnamnesisId { get; set; }
        public int? PhysiologicalIndicationId { get; set; }
        public int? PatientId { get; set; }
        public int? MedicalHistoryId { get; set; }
        public int? WorkHistoryId { get; set; }
        public int? AllergyAnamnesisId { get; set; }
        public int? MedicalExaminationId { get; set; }
        public int? DisabilityDescriptionId { get; set; }
        public int? PhysicalExaminationId { get; set; }
        public int? MedicalHistoryNoteId { get; set; }
    }
}
