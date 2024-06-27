using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStrefaKursow
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private By name = By.CssSelector("div[class='b-user-section-user u-mr-30']");
        public IWebElement Name => driver.FindElement(name);

        public string NameToText => Name.Text;

        private By arrowDown = By.CssSelector("i[class='a-arrow-down--blue']");
        private IWebElement BtnArrow => driver.FindElement(arrowDown);
                
        private By settings = By.XPath("//*[@class='b-user-menu-dropdown']/ul/a[2]");
        private IWebElement BtnSettings => driver.FindElement(settings);


        public void GoToUserName()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(c => c.FindElement(name));
        }

        public void NavigateToSettingsPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(c => c.FindElement(arrowDown));
            BtnArrow.Click();
            BtnSettings.Click();
        }

    }
}
