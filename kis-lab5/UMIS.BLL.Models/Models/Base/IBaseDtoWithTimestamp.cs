using System;

namespace UMIS.BLL.Contracts.Models.Base
{
    /// <summary>
    /// Базовая сущность в датами создания и модификации
    /// </summary>
    public interface IBaseDtoWithTimestamp
    {
        /// <summary>
        /// Дата создания объекта
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        DateTime LastModificationDate { get; set; }
    }
}
