using OpenQA.Selenium;
using TestingAutomation.Driver.Interfaces;
using TestingAutomation.Settings;

namespace TestingAutomation.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        private IWebDriver driver;
        private readonly IBrowserDriverType browserDriverType;
        private readonly TestSettings testSettings;

        public IWebDriver Driver => driver;

        public DriverFixture(TestSettings testSettings, IBrowserDriverType browserDriverType)
        {
            this.browserDriverType = browserDriverType;
            this.testSettings = testSettings;
            this.driver = GetWebDriver();
        }

        private IWebDriver GetWebDriver()
        {
            return testSettings.BrowserType switch
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
