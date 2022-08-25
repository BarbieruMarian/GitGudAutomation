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
        private IList<IWebElement> Images => driver.FindElements(By.XPath("//div[@class='inventory_item_img']/a/img"));
        private IWebElement FilterButton => driver.FindElement(By.ClassName("product_sort_container"));
        private IList<IWebElement> InventoryItemNames => driver.FindElements(By.ClassName("inventory_item_name"));


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
            var listOfPrices = new List<string>();
            foreach (var item in Prices)
            {
                listOfPrices.Add(item.Text);
                var text = item.Text;
                if (IsParsePrices(text) == false)   
                return false;
                  
            }
            return true;

        }
        
        private List<string> ListValuesAsStrings(IList<IWebElement> webElements)
        {
            var listOfStrings = new List<string>();
            foreach (var item in webElements)
            {
                listOfStrings.Add(item.Text);

            }
            return listOfStrings;
        }
        public bool CheckNamesAreAToZ() // sortare crescatoare dupa nume
        {
            
            var listOfNamesAToZ = ListValuesAsStrings(InventoryItemNames);
            listOfNamesAToZ.Sort();
            var selectElement = new SelectElement(FilterButton);
            selectElement.SelectByText("Name (A to Z)");
            Thread.Sleep(2000);
            var listOfAscendingNames = ListValuesAsStrings(InventoryItemNames).ToList();
            if (listOfNamesAToZ.SequenceEqual(listOfAscendingNames))
                return true;
            else return false;

        }
        public bool CheckNamesAreZToA() // sortare crescatoare dupa nume
        {

            var listOfNamesZToA = ListValuesAsStrings(InventoryItemNames);
            var descendingListOfNames = listOfNamesZToA.OrderByDescending(x => x);
            var selectElement = new SelectElement(FilterButton);
            selectElement.SelectByText("Name (Z to A)");
            Thread.Sleep(2000);
            var listOfdescendingNames = ListValuesAsStrings(InventoryItemNames).ToList();
            if (descendingListOfNames.SequenceEqual(listOfdescendingNames))
                return true;
            else return false;

        }
        public bool CheckPricesAreLowToHigh() // sa verific ca sunt in ordine crescatoare
        {
            var listOfPricesAsStrings = ListValuesAsStrings(Prices);
            var listOfPrices = ParsePrices(listOfPricesAsStrings);
            listOfPrices.Sort();
            var selectElement = new SelectElement(FilterButton);
            selectElement.SelectByText("Price (low to high)");
            Thread.Sleep(3000);
            var listOfPricesAsStringss = ListValuesAsStrings(Prices);
            var listOfPricess = ParsePrices(listOfPricesAsStringss);
            
            if (listOfPrices.SequenceEqual(listOfPricess))
                return true;
            else return false;

        }
       
        public bool CheckPricesAreHighToLow() // sa verific ca sunt in ordine descrescatoare
        {
            var listOfPricesAsStrings = ListValuesAsStrings(Prices);
            var listOfPrices = ParsePrices(listOfPricesAsStrings);
            var descendingListOfPrices = listOfPrices.OrderByDescending(i => i);            
            var selectElement = new SelectElement(FilterButton);
            selectElement.SelectByText("Price (high to low)");
            Thread.Sleep(3000);
            var listOfPricesAsStringss = ListValuesAsStrings(Prices);
            var listOfPricess = ParsePrices(listOfPricesAsStringss);

            if (descendingListOfPrices.SequenceEqual(listOfPricess))
                return true;
            else return false;

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
        private List<float> ParsePrices(List<string> pricesToParse)
        {
            var pricesAsFloat = new List<float>();  
            foreach (var item in pricesToParse)
            {
                var priceToParse = item.Remove(0, 1);
                var parsedPrice = float.Parse(priceToParse);
                pricesAsFloat.Add(parsedPrice); 
            }
            return pricesAsFloat;
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
        public bool CheckNumberOfImages()
        {
            
            if (Images.Count == 6)
                return true;
            else return false;
        }
        public bool CheckImageContainsJPG()
        {
            foreach (var item in Images)
            {
                var src = item.GetProperty("src");
                if (!src.Contains(".jpg"))
                    return false;

            }
            return true;
        }

        #endregion
    }
}
