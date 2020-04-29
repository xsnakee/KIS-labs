using System.Collections.Generic;
using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Auth
{
    /// <summary>
    /// Рабочая группа
    /// </summary>
    public class WorkgroupDto : BaseDto
    {
        /// <summary>
        /// Наименование рабочей группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Роли рабочией группы
        /// </summary>
        public List<RoleDto> Roles { get; set; }
    }
}
