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
        private IWebElement LoginError => driver.FindElement(By.XPath("//button[@class='error-button']"));
        private IWebElement LoginErrorForLockedOutUser => driver.FindElement(By.XPath("//h3[text() = 'Epic sadface: Sorry, this user has been locked out.']"));
        #endregion

        #region Actions

        public void GoTo()
        {
            driver.Navigate().GoToUrl(Config.AppOneURL);
            Thread.Sleep(500);
        }
        public void Login(string username, string password)
        {
            Thread.Sleep(500);
            Username.SendKeys(username);
            Thread.Sleep(500);
            Password.SendKeys(password);
            Thread.Sleep(500);
            LoginButton.Click();
            Thread.Sleep(500);
        }
        public bool LoginFail()
        {
            try
            {
                Thread.Sleep(500);
                return LoginError.Displayed;
            }
            catch
            {
                return false;
            }
            
        }
        public bool LoginLockedOutUser()
        {
            try
            {
                Thread.Sleep(500);
                return LoginErrorForLockedOutUser.Displayed;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
