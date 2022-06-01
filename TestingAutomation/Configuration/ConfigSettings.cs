using Newtonsoft.Json;

namespace TestFramework.Configuration
{
    public class ConfigSettings
    {
        [JsonProperty("url")]
        public string? AppOneURL { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}
