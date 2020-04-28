namespace UMIS.DAL.Domain.Contracts.Models.Base
{
    public interface IBaseEntity<T>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        T Id { get; set; }
    }
}
