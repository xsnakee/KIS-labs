namespace UMIS.DAL.Domain.Contracts.Models.Base
{
    public interface IBaseCustomizeEntity : IBaseEntityWithTimestamp
    {
        /// <summary>
        /// Идентификатор создателя сущности
        /// </summary>

        int OwnerId { get; set; } // Id - 1, зарезервированно администратором

        /// <summary>
        /// Сущность является системной
        /// </summary>
        bool IsSystem { get; set; }

        /// <summary>
        /// Пометка удаления
        /// </summary>
        bool IsRemoved { get; set; }

        /// <summary>
        /// Имеет доступ только создатель сущности
        /// </summary>
        bool AllowedOnlyForOwner { get; set; }
    }
}
