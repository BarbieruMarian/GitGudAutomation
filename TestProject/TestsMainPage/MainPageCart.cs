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
        [Fact]
        public void ProductsNumberCartShopping()
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

            mainPage.ClickAddToCartBtn(5);
            var areProductsInCartEqualToBtn = mainPage.CheckIfNotifIsNumberOfProducts(5);

            Assert.True(areProductsInCartEqualToBtn, "there are no products added in cart");

        }
        [Fact]
        public void CheckFbButton()
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

            var fbBtn = mainPage.CheckFbButton();

            Assert.True(fbBtn, "there was no fb page found");

        }
        [Fact]
        public void CheckTwitterButton()
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

            var twitterBtn = mainPage.CheckTwitterButton();

            Assert.True(twitterBtn, "there was no twitter page found");

        }
        [Fact]
        public void CheckFooterTxt()
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

            var footerTxt = mainPage.CheckFooterTxt();

            Assert.True(footerTxt, "the footer is wrong");

        }
        [Fact]
        public void CheckTopBtnWorks()
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

            var topBtn = mainPage.CheckLeftTopBtnWorks();
            var closeBtn = mainPage.CheckCloseBtnWorks();
            Assert.True(topBtn, "the top btn doesnt work");
            Assert.True(closeBtn, "the opened window has not been closed");

        }
        [Fact]
        public void CheckAboutBtnWorks()
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

            var abtBtn = mainPage.CheckAboutBtn();
            
            Assert.True(abtBtn, "the page didn't open");
           

        }
        [Fact]
        public void CheckLogoutBtn()
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

            var logOutBtn = mainPage.CheckLogoutBtn();

            Assert.True(logOutBtn, "the logout didn't work");


        }

    }

}
