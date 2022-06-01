using OpenQA.Selenium;
using TestingAutomation.Driver.Interfaces;

namespace TestProject
{
    public class TestBase 
    {
        public readonly IWebDriver Driver;
        public TestBase(IDriverFixture driverFixture)
        {
            Driver = driverFixture.Driver;
        }
    }
}
