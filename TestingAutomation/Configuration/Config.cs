using TestFramework.Configuration.Interfaces;

namespace TestFramework.Configuration
{
    public class Config : IConfig
    {
        public static string? AppOneURL { get; set; }
        public static string? Username { get; set; }
        public static string? Password { get; set; }
    }
}
