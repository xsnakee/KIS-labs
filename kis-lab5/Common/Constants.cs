namespace Common
{
    /// <summary>
    /// Константы
    /// </summary>
    public class Constants
    {
        public static string JwtIssuer => CommonConfigurator.GetAppSettingsValue("Auth:Jwt:Issuer", (string)null);
        public static string JwtAudience => CommonConfigurator.GetAppSettingsValue("Auth:Jwt:Audience", (string)null);
        public static double JwtLifeTime => CommonConfigurator.GetAppSettingsValue("Auth:Jwt:LifeTime", 0.0);
        public static string JwtSecret => CommonConfigurator.GetAppSettingsValue("Auth:Jwt:Secret", (string)null);

        /// <summary>
        /// Номер страницы фильра по умолчанию
        /// </summary>
        public static int DefaultPageNumber => 1;

        /// <summary>
        /// Количество записей на странице по умолчанию
        /// </summary>
        public static int DefaultPageSize => 10;

        /// <summary>
        /// Формат даты по умолчанию
        /// </summary>
        public static string DefaultDateTimeFormat = CommonConfigurator.GetAppSettingsValue("Constants:Formats:DefaultDateTimeFormat", "dd-MM-yyyy");
    }
}
