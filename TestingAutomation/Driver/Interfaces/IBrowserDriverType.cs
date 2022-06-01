using OpenQA.Selenium;

namespace TestingAutomation.Driver.Interfaces
{
    public interface IBrowserDriverType
    {
        IWebDriver GetChromeDriver();
        IWebDriver GetFirefoxDriver();
    }
}
