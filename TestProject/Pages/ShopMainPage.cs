using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;
using Xunit;
namespace TestProject.Pages
{
    public class ShopMainPage
    {
        private readonly IWebDriver driver;
        public ShopMainPage(IWebDriver Driver)
        {
            this.driver = Driver;
        }

        #region Elements
        private IWebElement ProductsText => driver.FindElement(By.XPath("//span[text() = 'Products']"));

        #endregion

        #region Actions
        public bool IsAtMainPage()
        {
            try
            {
                Thread.Sleep(2000);
                return ProductsText.Displayed;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
