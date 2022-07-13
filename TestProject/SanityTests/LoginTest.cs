using OpenQA.Selenium;
using TestFramework.Configuration;
using TestingAutomation.Driver.Interfaces;
using TestProject.Pages;
using Xunit;


namespace TestProjectSwagLabs.SanityTests
{
    public class LoginTest
    {
        private readonly IWebDriver driver;
        public LoginTest(IDriverFixture driverFixture)
        {
            this.driver = driverFixture.Driver;
        }

        [Fact]
        public void Login()
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
        }
        [Fact]
        public void MessageForLoginFailed()
        {
            //step 1 - Go To Website
            var loginPage = new LoginPage(driver);
            loginPage.GoTo();

            //step 2 - Insert wrong Username and Password
            loginPage.Login("sa", "fasfas");

            // step 3 verify login error message appears
            var loginFailed = loginPage.LoginFail();
            Assert.True(loginFailed, "We couldn't find the error message for Login Failed");


        }
        [Fact]
        public void LoginLockedOutUser()
        {

            //step 1 - Go To Website
            var loginPage = new LoginPage(driver);
            loginPage.GoTo();

            //step 2 - Insert Username and Password
            loginPage.Login("locked_out_user", Config.Password);

            //step 3 - Verify that login was indeed sucessfull
            var loginLockedOutUser = loginPage.LoginLockedOutUser();
            Assert.True(loginLockedOutUser, "The userID introduced was other than locked_out_use");

        }
        [Fact]
        public void LoginProblemUser()
        {

            //step 1 - Go To Website
            var loginPage = new LoginPage(driver);
            loginPage.GoTo();

            //step 2 - Insert Username and Password
            loginPage.Login("problem_user", Config.Password);
           
            //step 3 - Verify that login was indeed sucessfull
            var mainPage = new ShopMainPage(driver);
            var wasLoginSucessfull = mainPage.IsAtMainPage();
            Assert.True(wasLoginSucessfull, "We couldn't find a specific element on the main page - Login Failed");

            //step 4 - Verify that the user got some problems
            var isAddToCartWorking = mainPage.IsAddToCartNotWorking();
            Assert.True(isAddToCartWorking, "Add to cart button works - we expected it to fail for problem user");
        }
    }
    
}
