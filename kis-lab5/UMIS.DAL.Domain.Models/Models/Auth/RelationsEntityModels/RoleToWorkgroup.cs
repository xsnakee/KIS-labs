using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels
{
    /// <summary>
    /// Роли и рабочей группы
    /// </summary>
    public class RoleToWorkgroup : BaseCustomizeEntity, IBaseCustomizeEntity
    {
        public RoleToWorkgroup()
        {
            UserToRoleWorkgroup = new List<UserToRoleWorkgroup>();
            Permissions = new List<PermissionsToWorkgroupRole>();
        }

        public virtual Workgroup Workgroup { get; set; }
        public int? WorkgroupId { get; set; }

        public virtual Role Role { get; set; }
        public int? RoleId { get; set; }

        public virtual List<UserToRoleWorkgroup> UserToRoleWorkgroup { get; set; }

        /// <summary>
        /// Пермиссии роли
        /// </summary>
        public virtual List<PermissionsToWorkgroupRole> Permissions { get; set; }
    }
}
