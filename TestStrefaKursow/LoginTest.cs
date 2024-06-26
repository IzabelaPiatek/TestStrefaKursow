using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestStrefaKursow
{
    public class LoginTest
    {

        private IWebDriver driver;
        private LoginPage login;
        private HomePage home;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://strefakursow.pl/");

            login = new LoginPage(driver);
            home = new HomePage(driver);
           
            

        }

        [Test]
        public void Login()
        {
            
            login.GoToPrivacyPolicy();
            login.GoToNewsletter();
            login.GoToLogin();
            login.LoginToApp("automationtestik@gmail.com", "Selenium123@");

            home.GoToUserName();
            var actualResult = "Test Test";
            var expectedResult = home.NameToText;

            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }
    }
}