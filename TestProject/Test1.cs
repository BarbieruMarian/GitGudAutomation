using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;
using Xunit;

namespace TestProject
{

    public class Test1 
    {
        private readonly IWebDriver driver;

        public Test1(IDriverFixture driverFixture)
        {
            this.driver = driverFixture.Driver;
        }
     
        [Fact]
        public void Testing()
        {
            driver.Navigate().GoToUrl(Config.AppOneURL);
            Thread.Sleep(5000);
        }
    }
}
