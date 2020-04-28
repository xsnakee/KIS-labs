using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Auth
{
    /// <summary>
    /// Роль
    /// </summary>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// Наименование роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Имеет доступ только создатель сущности
        /// </summary>
        public bool AllowedOnlyForOwner { get; set; }
    }
}
