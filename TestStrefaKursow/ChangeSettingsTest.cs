using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStrefaKursow
{
    internal class ChangeSettingsTest
    {
        private IWebDriver driver;
        private LoginPage login;
        private HomePage home;
        private SettingsPage settings;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://strefakursow.pl/");

            login = new LoginPage(driver);
            home = new HomePage(driver);
            settings = new SettingsPage(driver);

            login.GoToPrivacyPolicy();
            login.GoToNewsletter();
            login.GoToLogin();
            login.LoginToApp("automationtestik@gmail.com", "Selenium123@");

        }
        [Test]
        public void ChangeSettings()
        {
            home.NavigateToSettingsPage();
            settings.FillDataToFV("Firma Krzak","9090909090","Poznańska","24","45-455","Poznań"); 

            settings.CheckSaveChanges();
            
            var actualResult = "Zmiany zapisane";
            var expectedResult = settings.PopUPSaveChangeToText;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }

}
