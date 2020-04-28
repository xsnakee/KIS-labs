namespace UMIS.DAL.Domain.Contracts.Models.Base
{
    public class BaseEntity : IBaseEntity<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
    }
}
