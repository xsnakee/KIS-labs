using System;

namespace UMIS.DAL.Domain.Contracts.Models.Base
{
    /// <summary>
    /// Базовая сущность с временными метками
    /// </summary>
    public class BaseEntityWithTimestamp : BaseEntity, IBaseEntityWithTimestamp
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
