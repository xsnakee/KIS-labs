using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;

namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// Аллергоанамнез.
    /// </summary>
    public class AllergyAnamnesisDto : BaseCommonDto
    {

        /// <summary>
        /// Идентификатор пациента.
        /// </summary>
        public int? PatientId { get; set; }

        /// <summary>
        /// Словесное описание.
        /// </summary>
        public string Note { get; set; }
    }
}
