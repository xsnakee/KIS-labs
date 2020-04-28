using System;
using System.Collections.Generic;
using System.Text;
using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Auth
{
    /// <summary>
    /// Модель связи ролей рабочих групп и пермиссий
    /// </summary>
    public class WorkgroupRolePermissionDto : BaseDto
    {
        /// <summary>
        /// Роль
        /// </summary>
        public RoleDto Role { get; set; }

        /// <summary>
        /// Рабочая группа
        /// </summary>
        public WorkgroupDto Workgroup { get; set; }

        /// <summary>
        /// Список пермиссий
        /// </summary>
        public List<PermissionDto> Permissions { get; set; }
    }
}
