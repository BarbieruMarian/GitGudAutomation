using Microsoft.Extensions.Configuration;

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

        }
    }
}
