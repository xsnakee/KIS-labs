namespace UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels
{
    public class UserToRoleWorkgroup
    {
        /// <summary>
        /// Разрешеное действие
        /// </summary>
        public virtual User User { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public virtual RoleToWorkgroup RoleToWorkgroup { get; set; }
        public int? RoleToWorkgroupId { get; set; }
    }
}
