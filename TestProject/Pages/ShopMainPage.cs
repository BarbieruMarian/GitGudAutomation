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
        private IWebElement AddToCartBoltShirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        private IWebElement RemoveButton => driver.FindElement(By.XPath("//button[text() = 'Remove']"));

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
        public bool IsAddToCartNotWorking()
        {
            try
            {
                Thread.Sleep(2000);
                AddToCartBoltShirt.Click();
                Thread.Sleep(2000);
                return !RemoveButton.Displayed;
            }
            catch
            {
                return true;
            }

        }

        #endregion
    }
}
