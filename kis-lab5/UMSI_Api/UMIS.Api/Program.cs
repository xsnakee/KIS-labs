using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using UMIS.DAL.DbSeed;

namespace UMIS.Api
{
    /// <summary>
    /// Точка входа в приложение
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args);

            // Выполнять сидинг данных только в случае указания параметра запуска
            if (CommonConfigurator.GetAppSettingsValue("SystemSeed:UseSeeding", false))
            {
                host.SeedSystemIdentity();
            }

            host.Run();
        }

        /// <summary>
        /// Создание хоста и заполнение конфигурации
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            IWebHostBuilder builder = WebHost.CreateDefaultBuilder(args);
            string entryAssemblyLocation = Assembly.GetEntryAssembly()?.Location;
            var rootDir = string.IsNullOrWhiteSpace(entryAssemblyLocation)
                ? Path.GetDirectoryName(entryAssemblyLocation)
                : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config
                    .SetBasePath(rootDir)
                    .AddJsonFile("Configs/appsettings.json", false, false)
                    .AddJsonFile($"Configs/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, false);
            });

            return builder
                .UseStartup<Startup>()
                .Build();
        }
    }
}
