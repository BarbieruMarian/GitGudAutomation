using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;
using TestProject.Pages;
using Xunit;

namespace TestProject.TestsMainPage
{
    public class MainPageCart
    {
        private readonly IWebDriver driver;
        public MainPageCart(IDriverFixture driverFixture)
        {
            this.driver = driverFixture.Driver;
        }

        [Fact]
        public void ProductsAddedToCart()
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

            //step 4 verify that Add to Cart button number is 6
            mainPage.ClickAddToCart();
            var areProductsInCart = mainPage.CheckIfAddToCartWasPressed();

            Assert.True(areProductsInCart, "there are no products added in cart");

        }
        [Fact]
        public void ProductsRemovedFromCart()
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

            //step 4 verify that Add to Cart button number is 6
            mainPage.ClickAddToCart();
            mainPage.ClickRemoveToCart();
            var areProductsRemovedFromCart = mainPage.CheckIfRemoveButtonWasPressed();

            Assert.True(areProductsRemovedFromCart, "there are no products added in cart");

        }

    }

}
