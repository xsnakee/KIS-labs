using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;

namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// Физиологические показания
    /// </summary>
    public class PhysiologicalIndicationDto : BaseCommonDto
    {
        ///// <summary>
        ///// История болезни
        ///// </summary>
        //public MedicalHistoryDto MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }

        /// <summary>
        /// Словесное описание
        /// </summary>
        public string Note { get; set; }
    }
}
