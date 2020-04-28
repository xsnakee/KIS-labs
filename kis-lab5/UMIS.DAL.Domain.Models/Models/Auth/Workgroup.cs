using System.Collections.Generic;
using UMIS.DAL.Domain.Contracts.Models.Auth.RelationsEntityModels;
using UMIS.DAL.Domain.Contracts.Models.Base;

namespace UMIS.DAL.Domain.Contracts.Models.Auth
{
    /// <summary>
    /// Рабочая группа
    /// </summary>
    public class Workgroup : BaseCustomizeEntity
    {
        public Workgroup()
        {
            RoleToWorkgroup = new List<RoleToWorkgroup>();
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Роли рабочей группы (характеризует должности отделений)
        /// </summary>
        public virtual List<RoleToWorkgroup> RoleToWorkgroup { get; set; }
    }
}
