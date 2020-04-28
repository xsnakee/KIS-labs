namespace UMIS.BLL.Contracts.Models.Base
{
    /// <summary>
    /// Базовый транспортный объект
    /// </summary>
    public class BaseDto : IBaseDto<int>
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public int Id { get; set; }
    }
}
