namespace UMIS.BLL.Contracts.Models.Auth
{
    /// <summary>
    /// Модель пользователя для входа в систему
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Запомнить пользователя (24 часа)
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
