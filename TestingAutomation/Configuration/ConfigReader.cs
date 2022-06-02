using Microsoft.Extensions.Configuration;
using TestingAutomation.Driver;

namespace TestFramework.Configuration
{
    public class ConfigReader
    {
        public static void InitializeSettings(string jsonSection)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json");

            IConfigurationRoot configurationRoot = builder.Build();

            Config.AppOneURL = configurationRoot.GetSection(jsonSection).Get<ConfigSettings>().AppOneURL;
            Config.Username = configurationRoot.GetSection(jsonSection).Get<ConfigSettings>().Username;
            Config.Password = configurationRoot.GetSection(jsonSection).Get<ConfigSettings>().Password;
            var browserType = configurationRoot.GetSection(jsonSection).Get<ConfigSettings>().BrowserType;
            switch (browserType)
            {
                case "Chrome":
                    Config.BrowserType = BrowserType.Chrome;
                    break;

                case "Firefox":
                    Config.BrowserType = BrowserType.Firefox;
                    break;

                default:
                    Config.BrowserType = BrowserType.Chrome;
                    break;
            }

        }
    }
}
