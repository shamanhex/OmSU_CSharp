using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutoScale
{
    class AppSettings
    {
        private static IConfiguration _config = null;
        public static IConfiguration Config
        {
            get
            {
                return _config;
            }
        }

        static AppSettings()
        {
            // Установка имени переменной среды
            const string environmentVariableName = "ASPNETCORE_ENVIRONMENT";
            // Получение значения переменной среды
            var environmentName =
                Environment.GetEnvironmentVariable(environmentVariableName);

            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                // Добавление json-файла для среды environmentName
                .AddJsonFile($"appsettings.{environmentName}.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public static int MaxHeight
        {
            get
            {
                string s = AppSettings.Config.GetSection("ScaleSettings")?.GetSection("MaxHeight")?.Value;
                int val = 0;
                if (!int.TryParse(s, out val))
                {
                    throw new InvalidOperationException("Ошибка чтения конфигурации. Секция ScaleSettings.MaxHeight должна содержать целое число.");
                }
                return val;
            }
        }

        public static int MaxWidth
        {
            get
            {
                string s = AppSettings.Config.GetSection("ScaleSettings")?.GetSection("MaxWidth")?.Value;
                int val = 0;
                if (!int.TryParse(s, out val))
                {
                    throw new InvalidOperationException("Ошибка чтения конфигурации. Секция ScaleSettings.MaxWidth должна содержать целое число.");
                }
                return val;
            }
        }

    }
}
