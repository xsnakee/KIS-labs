using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Common
{
    /// <summary>
    /// Класс позволяющий получить доступ к файлу appsettings.json 
    /// В проекте, котором необходимо получить конфигурцию, должна быть добавлена ссылка на файла appsettings.json
    /// </summary>
    public static class CommonConfigurator
    {
        public static readonly IConfiguration Configuration;

        static CommonConfigurator()
        {
            var entryAssemblyLocation = Assembly.GetEntryAssembly()?.Location;
            var rootDir = string.IsNullOrWhiteSpace(entryAssemblyLocation)
                ? Path.GetDirectoryName(entryAssemblyLocation)
                : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Configuration = new ConfigurationBuilder()
                .SetBasePath(rootDir)
                .AddJsonFile("Configs/appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"Configs/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, false)
                .Build();
        }

        /// <summary>
        /// Возвращает значение элемента в секции appSettings с указаным ключом или значение <paramref name="defaultValue"/>, если элемент не найден.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
        /// <param name="defaultValue">Значение по умолчанию.</param>
        /// <param name="key">Ключ.</param>
        /// <returns>Значение.</returns>
        public static T GetAppSettingsValue<T>(string key, T defaultValue)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            dynamic value = null;
            // В случае отсутствия ключа, в файле конфигураций, к примеру Get<int>(key)- возвращается 0.
            // поэтому используется метод ConverTo<T>
            try
            {
                value = Configuration[key];
            }
            finally
            {
                value = value == null
                    ? defaultValue
                    : ConvertTo<T>(value);
            }

            return value;
        }

        /// <summary>
        /// Конвертирует строку в указанный тип, используя инвариантную культуру.
        /// </summary>
        /// <typeparam name="T">Тип, в который будет сконвертирована строка.</typeparam>
        /// <param name="value">Строка.</param>
        /// <returns>Результат конвертации.</returns>
        private static T ConvertTo<T>(string value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(value);
        }
    }
}
