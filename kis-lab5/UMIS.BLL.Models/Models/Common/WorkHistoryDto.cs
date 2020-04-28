using System;
using UMIS.BLL.Contracts.Models.Common.Catalogs.Base;

namespace UMIS.BLL.Contracts.Models.Common
{
    /// <summary>
    /// Трудовой анамнез.
    /// </summary>
    public class WorkHistoryDto : BaseCommonDto
    {
        /// <summary>
        /// Идентификатор пациента.
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Заметка.
        /// </summary>
        public string Note { get; set; }
    }
}
