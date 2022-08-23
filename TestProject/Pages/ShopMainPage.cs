using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
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
        private IList<IWebElement> Prices => driver.FindElements(By.XPath("//div[@class='inventory_item_price']"));

        private IList<IWebElement> Description => driver.FindElements(By.XPath("//div[@class='inventory_item_desc']"));
        private IList<IWebElement> AddToCartBtn => driver.FindElements(By.XPath("//button[@class='btn btn_primary btn_small btn_inventory']"));

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
        public bool LoginTakesTooLong(int seconds)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            Thread.Sleep(seconds);

            sw.Stop();
            if (IsAtMainPage())
                return false;
            else return true;

        }
        public bool CheckPrices()
        {
            foreach (var item in Prices)
            {
                var text = item.Text;
                if (IsParsePrices(text) == false)   
                return false;
                  
            }
            return true;

        }
        private bool IsParsePrices(string priceToParse)
        {
            priceToParse = priceToParse.Remove(0, 1);
            float price = 0;
            var textToFloat = float.TryParse(priceToParse, out price);
            if (textToFloat)
                return true;
            else return false;
        }
        public bool CheckDescription()
        {
            foreach(var item in Description)
            {
                if (item.Text == string.Empty)
                    return false;

            }
            return true;
        }
        public bool CheckAddToCartBtnNumber()
        {
            if (AddToCartBtn.Count == 6)
                return true;
            else
                return false;
        }

        #endregion
    }
}
