using Microsoft.Extensions.DependencyInjection;
using TestFramework.Configuration;
using TestFramework.Configuration.Interfaces;
using TestingAutomation.Driver;
using TestingAutomation.Driver.Interfaces;

namespace TestProject.Bootstrap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IBrowserDriverType, BrowserDriverType>();
            services.AddScoped<IConfig, Config>();
        }
    }
}
