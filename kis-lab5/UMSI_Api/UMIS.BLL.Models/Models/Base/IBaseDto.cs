namespace UMIS.BLL.Contracts.Models.Base
{
    /// <summary>
    /// Базовый транспортный объект
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IBaseDto<TKey>
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        TKey Id { get; set; }
    }
}
