using OpenQA.Selenium;
using TestFramework.Configuration;

namespace TestingAutomation.Driver.Interfaces
{
    public interface IDriverFixture
    {
        public IWebDriver Driver { get; }
    }
}
