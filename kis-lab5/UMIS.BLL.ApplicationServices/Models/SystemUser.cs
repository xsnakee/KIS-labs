namespace UMIS.DbSeed.Models
{
    /// <summary>
    /// Модель для добавления системных пользователей
    /// </summary>
    public class SystemUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
