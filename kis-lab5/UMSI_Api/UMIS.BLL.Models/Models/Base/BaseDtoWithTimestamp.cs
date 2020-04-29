using System;

namespace UMIS.BLL.Contracts.Models.Base
{
    /// <summary>
    /// Базовая сущность c датами создания и модификации
    /// </summary>
    public class BaseDtoWithTimestamp : BaseDto, IBaseDtoWithTimestamp
    {
        /// <summary>
        /// Дата создания объекта
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        public DateTime LastModificationDate { get; set; }
    }
}
