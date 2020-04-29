using UMIS.DAL.Domain.Contracts.Models.Common.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Common
{
    /// <summary>
    /// Заметка для истории болезни
    /// </summary>
    public class MedicalHistoryNote : BaseCommonEntity
    {
        /// <summary>
        /// Тема
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// История болезни
        /// </summary>
        public MedicalHistory MedicalHistory { get; set; }
        public int MedicalHistoryId { get; set; }
    }
}