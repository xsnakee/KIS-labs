using System;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Domain.Models.Helpers
{
    /// <summary>
    /// Helper для заполнения полей
    /// </summary>
    public static class EntityPropertyFillHelper
    {
        /// <summary>
        /// Заполняет дату создания и модификации текщей датой
        /// </summary>
        /// <returns>исходную сущность</returns>
        public static T FillCreateDate<T>(this T entity)
        {
            IBaseEntityWithTimestamp withTimestamp = entity as IBaseEntityWithTimestamp;
            if (withTimestamp != null)
            {
                withTimestamp.CreateDate = withTimestamp.LastModificationDate = DateTime.UtcNow;
            }

            return entity;
        }

        /// <summary>
        /// Заполняет дату модификации текущей датой
        /// </summary>
        /// <returns>исходную сущность</returns>
        public static T FillModificationDate<T>(this T entity)
        {
            IBaseEntityWithTimestamp withTimestamp = entity as IBaseEntityWithTimestamp;
            if (withTimestamp != null)
            {
                withTimestamp.LastModificationDate = DateTime.UtcNow;
            }

            return entity;
        }
    }
}
