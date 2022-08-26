using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;
using TestProject.Pages;
using Xunit;

namespace TestProject.TestsMainPage
{
    public class MainPageFilter
    {
        private readonly IWebDriver driver;
        public MainPageFilter(IDriverFixture driverFixture)
        {
            this.driver = driverFixture.Driver;
        }
        [Fact]
        public void NumberListedFromLowToHigh()
        {
            //step 1 - Go To Website
            var loginPage = new LoginPage(driver);
            loginPage.GoTo();

            //step 2 - Insert Username and Password
            loginPage.Login(Config.Username, Config.Password);


            //step 3 - Verify that login was indeed sucessfull
            var mainPage = new ShopMainPage(driver);
            var wasLoginSucessfull = mainPage.IsAtMainPage();
            Assert.True(wasLoginSucessfull, "We couldn't find a specific element on the main page - Login Failed");

            //step 4 verify that Add to Cart buton number is 6
            var areNumbersLowToHigh = mainPage.CheckPricesAreLowToHigh();

            Assert.True(areNumbersLowToHigh, "The numbers aren't listed from low to high");

        }
        [Fact]
        public void NumberListedFromHighToLow()
        {
            //step 1 - Go To Website
            var loginPage = new LoginPage(driver);
            loginPage.GoTo();

            //step 2 - Insert Username and Password
            loginPage.Login(Config.Username, Config.Password);


            //step 3 - Verify that login was indeed sucessfull
            var mainPage = new ShopMainPage(driver);
            var wasLoginSucessfull = mainPage.IsAtMainPage();
            Assert.True(wasLoginSucessfull, "We couldn't find a specific element on the main page - Login Failed");

            //step 4 verify that Add to Cart buton number is 6
            var areNumbersHighToLow = mainPage.CheckPricesAreHighToLow();

            Assert.True(areNumbersHighToLow, "The numbers aren't listed from high to low");

        }
        [Fact]
        public void NamesListedFromAToZ()
        {
            //step 1 - Go To Website
            var loginPage = new LoginPage(driver);
            loginPage.GoTo();

            //step 2 - Insert Username and Password
            loginPage.Login(Config.Username, Config.Password);


            //step 3 - Verify that login was indeed sucessfull
            var mainPage = new ShopMainPage(driver);
            var wasLoginSucessfull = mainPage.IsAtMainPage();
            Assert.True(wasLoginSucessfull, "We couldn't find a specific element on the main page - Login Failed");

            //step 4 verify that Add to Cart buton number is 6
            var areNamesListedAToZ = mainPage.CheckNamesAreAToZ();

            Assert.True(areNamesListedAToZ, "The product names aren't listed from A to Z");

        }
        [Fact]
        public void NamesListedFromZToA()
        {
            //step 1 - Go To Website
            var loginPage = new LoginPage(driver);
            loginPage.GoTo();

            //step 2 - Insert Username and Password
            loginPage.Login(Config.Username, Config.Password);


            //step 3 - Verify that login was indeed sucessfull
            var mainPage = new ShopMainPage(driver);
            var wasLoginSucessfull = mainPage.IsAtMainPage();
            Assert.True(wasLoginSucessfull, "We couldn't find a specific element on the main page - Login Failed");

            //step 4 verify that Add to Cart buton number is 6
            var areNamesListedZToA = mainPage.CheckNamesAreZToA();

            Assert.True(areNamesListedZToA, "The names aren't listed from Z to A");
        }
    }
}
