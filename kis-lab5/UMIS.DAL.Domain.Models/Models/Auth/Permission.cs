using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Auth
{
    /// <summary>
    /// Привелегия
    /// </summary>
    public class Permission : BaseCustomizeEntity
    {
        public Permission()
        {
            PermissionsToWorkgroupRole = new List<PermissionsToWorkgroupRole>();
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Роли в рабочих группах с данной пермиссией
        /// </summary>
        public virtual List<PermissionsToWorkgroupRole> PermissionsToWorkgroupRole { get; set; }

        /// <summary>
        /// Типа сущности
        /// </summary>
        public int? EntityTypeNum { get; set; }

        /// <summary>
        /// Тип действия
        /// </summary>
        public int? ActionTypeNum { get; set; }
    }
}
