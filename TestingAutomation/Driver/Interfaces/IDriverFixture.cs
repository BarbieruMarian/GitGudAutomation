using OpenQA.Selenium;

namespace TestingAutomation.Driver.Interfaces
{
    public interface IDriverFixture
    {
        public IWebDriver Driver { get; }
    }
}
