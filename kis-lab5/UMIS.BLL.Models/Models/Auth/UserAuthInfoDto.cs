using System.Collections.Generic;
using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Auth
{
    /// <summary>
    /// Учетные данные пользователя 
    /// </summary>
    public class UserAuthInfoDto : BaseDto
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UserAuthInfoDto()
        {
            Permissions = new List<PermissionDto>();
            Roles = new List<RoleDto>();
            Workgroups = new List<WorkgroupDto>();
        }

        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Список привелегий
        /// </summary>
        public List<PermissionDto> Permissions { get; set; }

        /// <summary>
        /// Роли
        /// </summary>
        public List<RoleDto> Roles { get; set; }

        /// <summary>
        /// Рабочие группы
        /// </summary>
        public List<WorkgroupDto> Workgroups { get; set; }
    }
}
