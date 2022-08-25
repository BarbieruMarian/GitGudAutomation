using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;
using TestProject.Pages;
using Xunit;

namespace TestProject.SanityTests
{
    public class MainPageTests
    {
        private readonly IWebDriver driver;
        public MainPageTests(IDriverFixture driverFixture)
        {
            this.driver = driverFixture.Driver;
        }

        [Fact]
        public void ProductsHavePrices()
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

            //step 4 verify that prices exist
            var isPriceOK = mainPage.CheckPrices();
            Assert.True(isPriceOK, "Price was not a correct format");
        }
        [Fact]
        public void ProductsHaveDescription()
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

            //step 4 verify that product's description exist
            var hasProductDescription = mainPage.CheckDescription();
            Assert.True(hasProductDescription, "The product has no description");
        }
        [Fact]
        public void AddToCartNumber()
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
            var numberofAddToCartBtns = mainPage.CheckAddToCartBtnNumber();
            Assert.True(numberofAddToCartBtns, "The number of Add to cart buttons is less than 6");
        }
        [Fact]
        public void NumberOfImages()
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
            var numberOfImage = mainPage.CheckNumberOfImages();
            var isImageContainsJPG = mainPage.CheckImageContainsJPG();
            Assert.True(numberOfImage, "The number of Images is less than 6");
            Assert.True(isImageContainsJPG, "Image does not exist");
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
