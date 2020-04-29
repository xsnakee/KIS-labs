namespace UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels
{
    /// <summary>
    /// Связь пользователя и ролей
    /// </summary>
    public class UserToWorkgroup
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual Workgroup Workgroup { get; set; }
        public int WorkgroupId { get; set; }
    }
}
