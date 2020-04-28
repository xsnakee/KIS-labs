using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Аллергоанамнез
    /// </summary>
    public class AllergyAnamnesis : BaseCommonEntity
    {
        /// <summary>
        /// Пациент
        /// </summary>
        public Patient Patient { get; set; }
        public int? PatientId { get; set; }

        /// <summary>
        /// Словесное описание
        /// </summary>
        public string Note { get; set; }
    }
}
