using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;
using Xunit;

namespace TestProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver Driver)
        {
            this.driver = Driver;
        }

        #region Elements
        private IWebElement Username => driver.FindElement(By.Id("user-name"));
        private IWebElement Password => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        #endregion

        #region Actions

        public void GoTo()
        {
            driver.Navigate().GoToUrl(Config.AppOneURL);
            Thread.Sleep(2000);
        }
        public void Login(string username, string password)
        {
            Thread.Sleep(2000);
            Username.SendKeys(username);
            Thread.Sleep(2000);
            Password.SendKeys(password);
            Thread.Sleep(2000);
            LoginButton.Click();
            Thread.Sleep(2000);
        }
        #endregion
    }
}
