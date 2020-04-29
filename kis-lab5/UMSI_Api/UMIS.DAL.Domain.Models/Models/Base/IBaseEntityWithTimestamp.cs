using System;

namespace UMIS.DAL.Domain.Contracts.Models.Base
{
    public interface IBaseEntityWithTimestamp : IBaseEntity<int>
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