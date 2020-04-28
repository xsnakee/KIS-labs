using UMIS.BLL.Contracts.Models.Base;

namespace UMIS.BLL.Contracts.Models.Auth
{
    /// <summary>
    /// Сущность для регистрации пользователей
    /// </summary>
    public class UserRegistrationDto : BaseDto
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// E-mail пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Идентификаторы ролей рабочих групп
        /// </summary>
        //public List<int> WorkgroupRoleIds { get; set; }
    }
}
