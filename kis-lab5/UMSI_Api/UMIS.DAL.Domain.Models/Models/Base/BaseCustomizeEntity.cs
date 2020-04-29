namespace UMIS.DAL.Domain.Contracts.Models.Base
{
    /// <summary>
    /// Базовая сущность с метками даты и владельцем
    /// </summary>
    public class BaseCustomizeEntity : BaseEntityWithTimestamp, IBaseCustomizeEntity
    {
        /// <summary>
        /// Идентификатор создателя сущности
        /// </summary>
        public int OwnerId { get; set; } = 1; // Id - 1, зарезервированно администратором

        /// <summary>
        /// Сущность является системной
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Пометка удаления
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// Имеет доступ только создатель сущности
        /// </summary>
        public bool AllowedOnlyForOwner { get; set; }
    }
}
