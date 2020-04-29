using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Трудовой анамнез
    /// </summary>
    public class WorkHistory : BaseCommonEntity
    {
        /// <summary>
        /// Пациент
        /// </summary>
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        /// <summary>
        /// Заметка
        /// </summary>
        public string Note { get; set; }
    }
}
