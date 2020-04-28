namespace UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels
{
    public class PermissionsToWorkgroupRole
    {
        /// <summary>
        /// Роль в рабочнй группе
        /// </summary>
        public virtual RoleToWorkgroup RoleToWorkgroup { get; set; }
        public int RoleToWorkgroupId { get; set; }

        /// <summary>
        /// Разрешеное действие
        /// </summary>
        public virtual Permission Permission { get; set; }
        public int PermissionId { get; set; }
    }
}
