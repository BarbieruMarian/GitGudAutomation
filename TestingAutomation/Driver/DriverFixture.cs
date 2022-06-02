using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;

namespace TestingAutomation.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        private IWebDriver driver;
        private readonly IDriverType browserDriverType;

        public IWebDriver Driver => driver;

        public DriverFixture(IDriverType browserDriverType)
        {
            ConfigReader.InitializeSettings("DemoBranch");
            this.browserDriverType = browserDriverType;
            this.driver = GetWebDriver();
        }

        private IWebDriver GetWebDriver()
        {
            return Config.BrowserType switch
            {
                BrowserType.Chrome  => browserDriverType.GetChromeDriver(),
                BrowserType.Firefox => browserDriverType.GetFirefoxDriver(),
                _ => browserDriverType.GetChromeDriver()
            };
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
